using AutoMapper;
using Eunis.Data.Models;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Services {
    public class BankAccountService : IBankAccountService {

        private readonly IBankAccountRepository _bankAccounts;
        private IServiceLogger logger { get; set; }
        private IMapper mapper { get; set; }
        public BankAccountService(IBankAccountRepository bankAccounts) {
            _bankAccounts = bankAccounts;
        }

        void IService.Adapter(IMapper mapper, IServiceLogger logger) {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public BankAccount FindByAccount(Expression<Func<BankAccount, bool>> expression) {
            logger.LogToFile($"Retrieve bank accounts where {expression.Body}");
            return _bankAccounts.Get(expression);
        }

        public async Task<BankAccount> FindByAccountAsync(Expression<Func<BankAccount, bool>> expression) {
            logger.LogToFile($"Retrieve bank accounts where {expression.Body}");
            return await _bankAccounts.GetAsync(expression);
        }

        public BankAccount FindByAccount(Expression<Func<BankAccount, bool>> expression, params Expression<Func<BankAccount, object>>[] includes) {
            logger.LogToFile($"Retrieve bank accounts where '{expression.Body}'");
            return _bankAccounts.Get(expression, includes);
        }

        public async Task<BankAccount> FindByAccountAsync(Expression<Func<BankAccount, bool>> expression, params Expression<Func<BankAccount, object>>[] includes) {
            logger.LogToFile($"Retrieve bank accounts where '{expression.Body}'");
            return await _bankAccounts.GetAsync(expression, includes);
        }
    }
}
