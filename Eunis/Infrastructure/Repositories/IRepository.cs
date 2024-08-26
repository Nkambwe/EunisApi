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
        bool Insert(T entity);
        Task<bool> InsertAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        bool Delete(Expression<Func<T, bool>> expression);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    }
}
