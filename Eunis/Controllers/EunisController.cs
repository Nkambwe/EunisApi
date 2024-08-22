using AutoMapper;
using Eunis.Helpers;
using Eunis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("")]
        public IActionResult Greet() {
            return Ok($"Welcome to Eunis");
        }

    }
}
