using Eunis.Data;
using Eunis.Data.Models;

namespace Eunis.Infrastructure.Repositories
{
    public class CredentialsRepository : Repository<Credentials>, ICredentialsRepository {
        private readonly EunisDbContext _context;
        public CredentialsRepository(EunisDbContext context) 
            : base(context) {
            _context = context;
        }

    }
}
