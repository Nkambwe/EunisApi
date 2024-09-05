using AutoMapper;
using Eunis.Data.Models;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;

namespace Eunis.Infrastructure.Services {
    public class SettingService : ISettingService {
        private readonly ISettingsRepository _settings;
        private IServiceLogger logger { get; set; }
        private IMapper mapper { get; set; }
        public SettingService(ISettingsRepository settings) {
            _settings = settings;
        }

        public void Adapter(IMapper mapper, IServiceLogger logger) {
            this.logger = logger;
            this.mapper = mapper;
        }

        public Settings FindByParameter(string parameterName)
           => _settings.Get(s => s.ParamName.Equals(parameterName));

        public async Task<Settings> FindByParameterAsync(string parameterName)
             => await _settings.GetAsync(s => s.ParamName.Equals(parameterName.Trim()));
    }
}
