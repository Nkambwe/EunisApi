using AutoMapper;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;

namespace Eunis.Infrastructure.Services {
    public class TransactionService : ITransactionService {
        private readonly ITransactionRepository _transactions;
        private IServiceLogger logger { get; set; }
        private IMapper mapper { get; set; }
        public TransactionService(ITransactionRepository transactions) {
            _transactions = transactions;
        }

        public void Adapter(IMapper mapper, IServiceLogger logger) {
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}
