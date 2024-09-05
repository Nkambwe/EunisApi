using AutoMapper;
using Eunis.Api;
using Eunis.Enums;
using Eunis.Exceptions;
using Eunis.Helpers;
using Eunis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using System.Net;

namespace Eunis.Controllers {

    [ApiController]
    [Route("eunis")]
    public class EunisController : EunisBaseController {

        private readonly ITransactionService _transactions;
        private readonly IClientService _clients;
        private readonly IBankAccountService _bankAccounts;
        public EunisController(IMapper mapper, 
            IServiceLogger serviceLogger, 
            ISettingService Settings,
            ICredentialService credentials,
            ITransactionService transactions,
            IClientService clients,
            IBankAccountService bankAccounts)
            : base(mapper, serviceLogger, Settings, credentials) {
            _transactions = transactions;
            _transactions.Adapter(mapper, serviceLogger);
            _clients = clients;
            _clients.Adapter(mapper, serviceLogger);
            _bankAccounts = bankAccounts;
            _bankAccounts.Adapter(mapper, serviceLogger);
        }

        [HttpPost("enquiry")]
        [Produces("application/json")]
        public async Task<IActionResult> AccountEnquiry([FromHeader]RequestHeader header, [FromBody]EnquiryRequest request) {
            EuinisResponse response = null;
            DateTime today = DateTime.UtcNow;
            try {

                if(request == null) {
                    ClientException error = new("Invalid Request! Request cannot be null or empty");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message}", "CLIENT ERROR");
                    return BadRequest(response);
                }

                //...validate request header
                string validationMsg = Validator.ValidateRequestHeader(header, request.ClientId);
                if (!string.IsNullOrEmpty(validationMsg)) {
                    ClientException error = new(validationMsg);
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message}", "CLIENT ERROR");
                    return BadRequest(response);
                }

                //..get credentials
                var credentials = await Credentials.FindCredentialsAsync(c => c.ClientId == request.ClientId);
                if(credentials == null) {
                    SecurityException error = new($"Unauthorized access! No security credentials found for User ID '{request.ClientId}'");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message}", "SECURITY ERROR");
                    return Unauthorized(response);
                }

                //check username and password
                if (string.IsNullOrWhiteSpace(credentials.Username)) {
                    SecurityException error = new($"Server Error! No username set for Client ID '{request.ClientId}'");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message}", "SERVER ERROR");
                    return Unauthorized(response);
                }

                if (!credentials.Username.Trim().Equals(header.XUserId.Trim())) {
                    SecurityException error = new($"Uanthorized Access! Invalid username");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message} for client ID '{request.ClientId}'", "SERVER ERROR");
                    return Unauthorized(response);
                }

                if (string.IsNullOrWhiteSpace(credentials.Password)) {
                    SecurityException error = new($"Server Error! No password set for Client ID '{request.ClientId}'");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message}", "SECURITY ERROR");
                    return Unauthorized(response);
                }

                var password = Secure.DecryptString(credentials.Password.Trim(), Utils.PassKey);
                if (!password.Equals(header.Password.Trim())) {
                    SecurityException error = new($"Uanthorized Access! Password provided is not correct");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message} for client ID '{request.ClientId}'", "SECURITY ERROR");
                    return Unauthorized(response);
                }

                //check action
                if (!request.Data.Action.Equals(Enum.GetName(typeof(Actions), Actions.Enquiry))){
                    ClientException error = new("Invalid Action. Expected an Enquiry action");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] {error.Message}", "CLIENT ERROR");
                    return BadRequest(response);
                }

                //..get certificate
                var certPath = await Settings.FindByParameterAsync(Enum.GetName(typeof(Params), Params.APICERTIFICATE));
                if (certPath == null) {
                    SecurityException error = new($"Server Error! Certificate is either invalid or not found'");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] Certificate path is not set in the database ", "SERVER ERROR");
                    return Unauthorized(response);
                }

                //..get public key
                var certKeyPath = await Settings.FindByParameterAsync(Enum.GetName(typeof(Params), Params.PUBLICKEY));
                if (certPath == null) {
                    SecurityException error = new($"Server Error! Security key is either invalid or not found");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] Public key path is not set in the database", "SERVER ERROR");
                    return Unauthorized(response);
                }

                //..get API key
                var apiKey = await Settings.FindByParameterAsync(Enum.GetName(typeof(Params), Params.APIKEY));
                if (certPath == null) {
                    SecurityException error = new($"Server Error! Security key is either invalid or not found'");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] API key not set in the database", "SERVER ERROR");
                    return Unauthorized(response);
                }

                //..serialize request
                ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] Account lookup from Client ID {request.ClientId}");
                string incomingJson = JsonConvert.SerializeObject(request);

                //..get customer account info
                var data = request.Data;
                if (string.IsNullOrWhiteSpace(data.AccountNumber)) {
                    ClientException error = new($"Invalid account number. Account number is required");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] Client account number not provided", "CLIENT ERROR");
                    return Unauthorized(response);
                }

                var account = await _bankAccounts.FindByAccountAsync(a => a.AccountNumber.Equals(data.AccountNumber), a => a.Bank);
                if (account == null) {
                    AccountNotFoundException error = new($"Account number '{data.AccountNumber}' not found");
                    response = new() {
                        StatusCode = error.ExceptionCode,
                        Message = error.Message,
                    };

                    ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] Client account number not provided", "CLIENT ERROR");
                    return Unauthorized(response);
                }

                var bank = account.Bank;
                EnquiryResponse enquiry = new() {
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Successfull",
                    Data = new() {
                        BankCode = bank?.SortCode ?? "",
                        BankName = bank?.BankName ?? "",
                        AccountName = account.AccountName,
                        AccountNumber = account.AccountNumber,
                        Currency = "UGX",
                        IsDebitable = account.CanWithdraw,
                        IsCreditable = account.CanDeposit,
                        Naration = account.Type.GetDescription()
                    }
                };

                return Ok(enquiry);
            } catch (Exception ex) {
                EuniSystemException error = new("System Error! Critical error has occurred. Cannot process request");
                response = new() { 
                    StatusCode = error.ExceptionCode, 
                    Message = error.Message,
                };

                ServiceLogger.LogToFile(ex.Message, "SYSTEM ERROR");
                ServiceLogger.LogToFile(ex.StackTrace, "INFO");
                return StatusCode(500, response);
            }
        }

        [HttpGet]
        public IActionResult Greet() {
            return Ok($"Welcome to Our API");
        }
        
    }
}
