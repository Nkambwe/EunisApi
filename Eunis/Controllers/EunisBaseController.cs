using Eunis.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eunis.Controllers {
    public class EunisBaseController : ControllerBase {

        public IServiceLogger ServiceLogger;

        public EunisBaseController(IServiceLogger serviceLogger) {
            ServiceLogger = serviceLogger ?? throw new ArgumentNullException(nameof(serviceLogger));
        }

    }
}
