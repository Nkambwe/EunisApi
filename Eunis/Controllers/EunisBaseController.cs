using Eunis.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eunis.Controllers {
    public class EunisBaseController : Controller {

        public IServiceLogger ServiceLogger;

        public EunisBaseController(IServiceLogger serviceLogger) {
            ServiceLogger = serviceLogger;
        }

    }
}
