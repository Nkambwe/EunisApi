using AutoMapper;
using Eunis.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eunis.Controllers {

    [ApiController]
    [Route("eunis")]
    public class EunisController : EunisBaseController {

        private readonly IMapper _mapper;
        public EunisController(IServiceLogger serviceLogger, IMapper mapper)
            : base(serviceLogger) {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("")]
        public IActionResult Greet() {
            return Ok($"Welcome to Eunis");
        }
    }
}
