using Eunis.Data.Models;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Repositories
{
    public interface IRepository<T> where T : DomainEntity {
        public T Get(long id);
        public Task<T> GetAsync(long id);
        public T Get(Expression<Func<T, bool>> expression);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression);
        public T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        public IList<T> GetAll();
        public Task<IList<T>> GetAllAsync();
        public IList<T> GetAll(Expression<Func<T, bool>> expression);
        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        public bool Insert(T entity);
        public Task<bool> InsertAsync(T entity);
        public bool Update(T entity);
        public Task<bool> UpdateAsync(T entity);
        public bool Delete(T entity);
        public Task<bool> DeleteAsync(T entity);
        public bool Delete(Expression<Func<T, bool>> expression);
        public Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        public bool Exists(Expression<Func<T, bool>> expression);
        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    }
}
