using AutoMapper;
using Eunis.Data.Models;
using Eunis.Helpers;
using Eunis.Infrastructure.Repositories;
using System.Linq.Expressions;

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

        public Credentials FindCredentials(Expression<Func<Credentials, bool>> expression) {
            try {
                return _credentials.Get(expression);
            } catch(Exception ex) {
                logger.LogToFile($"[{DateTime.Now:yyyy-MM-dd HH:mm.ss}] {ex.Message}", "SYSTEM ERROR");
                logger.LogToFile($"{ex.StackTrace}");
                return null;
            }
        }

        public async Task<Credentials> FindCredentialsAsync(Expression<Func<Credentials, bool>> expression) {
            try {
                return await _credentials.GetAsync(expression);
            } catch (Exception ex) {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                logger.LogToFile($"[{timestamp}] Method: FindCredentialsAsync - Error: {ex.Message}", "SYSTEM ERROR");
                logger.LogToFile($"{ex.StackTrace}");
                return await Task.FromResult<Credentials>(null);
            }
            
        }
    }
}
