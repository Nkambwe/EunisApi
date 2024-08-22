using AutoMapper;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;

namespace Eunis.Infrastructure.Services {
    public class CredentialService : ICredentialService {
        private readonly ICredentialsRepository _credentials;
        private IServiceLogger logger { get; set; }
        private IMapper mapper { get; set; }
        public CredentialService(ICredentialsRepository credentials) {
            _credentials = credentials;
        }

        public void Adapter(IMapper mapper, IServiceLogger logger) {
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
