using Eunis.Data.Models;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Repositories
{
    public interface IRepository<T> where T : DomainEntity {
        T Get(long id);
        Task<T> GetAsync(long id);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();
        IList<T> GetAll(Expression<Func<T, bool>> expression);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    }
}
