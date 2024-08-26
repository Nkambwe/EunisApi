using AutoMapper;
using Eunis.Api;
using Eunis.Exceptions;
using Eunis.Helpers;
using Eunis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eunis.Controllers {

    [ApiController]
    [Route("eunis")]
    public class EunisController : EunisBaseController {

        private readonly ITransactionService _transactions;

        public EunisController(IMapper mapper, 
            IServiceLogger serviceLogger, 
            ISettingService Settings,
            ICredentialService credentials,
            ITransactionService transactions)
            : base(mapper, serviceLogger, Settings, credentials) {
            _transactions = transactions;
            _transactions.Adapter(mapper, serviceLogger);
        }

        [HttpPost("enquiry")]
        public async Task<IActionResult> AccountEnquiry([FromBody] EnquiryRequest request, [FromHeader]RequestHeader header) {
            Response.ContentType = "application/json";
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
                    return Content(JsonConvert.SerializeObject(response));
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
                    return Content(JsonConvert.SerializeObject(response));
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
                    return Content(JsonConvert.SerializeObject(response));
                }

                //..serialize request
                ServiceLogger.LogToFile($"[{today:yyyy-MM-dd HH:mm.ss}] Account lookup from Client ID {request.ClientId}");
                string incomingJson = JsonConvert.SerializeObject(request);

                return Content(JsonConvert.SerializeObject(response));
            } catch (Exception ex) {
                EuniSystemException error = new("System Error! Critical error has occurred. Cannot process request");
                response = new() { 
                    StatusCode = error.ExceptionCode, 
                    Message = error.Message,
                };

                ServiceLogger.LogToFile(ex.Message, "SYSTEM ERROR");
                ServiceLogger.LogToFile(ex.StackTrace, "INFO");
                return Content(JsonConvert.SerializeObject(response));
            }
        }

        [HttpGet]
        public IActionResult Greet() {
            return Ok($"Welcome to Our API");
        }
        
    }
}
