using Eunis.Data;
using Eunis.Data.Models;

namespace Eunis.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<EuniceTransaction>, ITransactionRepository {
        public TransactionRepository(EunisDbContext context)
            : base(context) {
        }
    }
}
