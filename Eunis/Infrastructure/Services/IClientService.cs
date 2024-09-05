using Eunis.Data.Models;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Services {
    public interface IClientService : IService {
       
        Client FindClient(Expression<Func<Client, bool>> expression);
        Task<Client> FindClientAsync(Expression<Func<Client, bool>> expression);
    }
}
