using Eunis.Data;
using Eunis.Data.Models;

namespace Eunis.Infrastructure.Repositories {
    public class ClientRepository : Repository<Client>, IClientRepository {
        public ClientRepository(EunisDbContext context)
            : base(context) {
        }
    }
}
