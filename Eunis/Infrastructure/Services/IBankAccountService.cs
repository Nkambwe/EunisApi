using Eunis.Data.Models;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Services {
    public interface IBankAccountService : IService {

        BankAccount FindByAccount(Expression<Func<BankAccount, bool>> expression);
        BankAccount FindByAccount(Expression<Func<BankAccount, bool>> expression, params Expression<Func<BankAccount, object>>[] includes);
        Task<BankAccount> FindByAccountAsync(Expression<Func<BankAccount, bool>> expression);
        Task<BankAccount> FindByAccountAsync(Expression<Func<BankAccount, bool>> expression, params Expression<Func<BankAccount, object>>[] includes);
    }
}
