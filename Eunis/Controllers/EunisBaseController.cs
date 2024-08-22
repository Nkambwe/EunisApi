using AutoMapper;
using Eunis.Helpers;
using Eunis.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eunis.Controllers {
    public class EunisBaseController : ControllerBase {
        public IMapper Mapper;
        public IServiceLogger ServiceLogger;
        public ISettingService Settings;
        public ICredentialService Credentials;

        public EunisBaseController(IMapper mapper, 
            IServiceLogger serviceLogger, 
            ISettingService Settings,
            ICredentialService credentials) {
            ServiceLogger = serviceLogger ?? throw new ArgumentNullException(nameof(serviceLogger));
            Mapper = mapper;

            Settings = Settings ?? throw new ArgumentNullException(nameof(Settings));
            Settings.Adapter(mapper, serviceLogger);

            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            Credentials.Adapter(mapper, serviceLogger);

        }

    }
}
