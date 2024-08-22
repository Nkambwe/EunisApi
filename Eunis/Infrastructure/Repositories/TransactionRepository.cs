using Eunis.Data;
using Eunis.Data.Models;

namespace Eunis.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<EunisTransaction>, ITransactionRepository {
        public TransactionRepository(EunisDbContext context)
            : base(context) {
        }
    }
}
