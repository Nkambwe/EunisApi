using AutoMapper;
using Eunis.Data.Models;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Services {
    public class ClientService : IClientService {

        private readonly IClientRepository _clients;
        private IServiceLogger logger { get; set; }
        private IMapper mapper { get; set; }

        public ClientService(IClientRepository clients) {
            _clients = clients;
        }

        void IService.Adapter(IMapper mapper, IServiceLogger logger) {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Client FindClient(Expression<Func<Client, bool>> expression) {
            throw new NotImplementedException();
        }

        public async Task<Client> FindClientAsync(Expression<Func<Client, bool>> expression) {
            throw new NotImplementedException();
        }
    }
}
