using Eunis.Data;
using Eunis.Data.Models;

namespace Eunis.Infrastructure.Repositories {
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository {
        public BankAccountRepository(EunisDbContext context)
            : base(context) {
        }
    }
}
