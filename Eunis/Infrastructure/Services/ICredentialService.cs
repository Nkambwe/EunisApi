using Eunis.Data.Models;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Services {
    public interface ICredentialService : IService {
        Credentials FindCredentials(Expression<Func<Credentials, bool>> expression);
        Task<Credentials> FindCredentialsAsync(Expression<Func<Credentials, bool>> expression);
    }
}
