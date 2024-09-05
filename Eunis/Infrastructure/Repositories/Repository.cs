using Eunis.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Eunis.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : DomainEntity {

        private readonly DbContext _context;
        private readonly DbSet<T> _entities;
        public Repository(DbContext context) {
            _context = context;
            _entities = context.Set<T>();
        }

        public T Get(long id) {
            return _entities.SingleOrDefault(t => t.Id == id);
        }

        public async Task<T> GetAsync(long id)
            => await _entities.SingleOrDefaultAsync(t => t.Id == id);

        public T Get(Expression<Func<T, bool>> expression)
            => _entities.FirstOrDefault(expression);

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => await _entities.FirstOrDefaultAsync(expression);

        public T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _entities;

            if (includes.Any()) {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            
            return query.FirstOrDefault(expression);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _entities;
            if (includes.Any()) {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync(expression);
        }

        public IList<T> GetAll()
            => _entities.ToList();

        public async Task<IList<T>> GetAllAsync()
            => await _entities.ToListAsync();


        public IList<T> GetAll(Expression<Func<T, bool>> expression)
            => _entities.Where(expression).ToList();

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression)
             => await _entities.Where(expression).ToListAsync();

        public bool Insert(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Add(entity);
           return _context.SaveChanges() > 0;
        }

        public async Task<bool> InsertAsync(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            await _entities.AddAsync(entity);
           return await _context.SaveChangesAsync() > 0;
        }

        public bool Update(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
           return _context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task UpdateCredentialAsync(Expression<Func<T, bool>> expression, bool isActive) {
        //    var affectedRows = await _entities.Where(expression)
        //         .ExecuteUpdateAsync(updates =>
        //    updates.SetProperty(p => p.IsActive, isActive));

        //    return affectedRows == 0 ? Results.NotFound() : Results.NoContent();
        //}

        public bool Delete(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Delete(Expression<Func<T, bool>> expression)
            => _entities.Where(expression).ExecuteDelete() > 0;

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
             => await _entities.Where(expression).ExecuteDeleteAsync() > 0;

        public bool Exists(Expression<Func<T, bool>> expression)
            => _entities.FirstOrDefault(expression) != null;

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
            => await _entities.FirstOrDefaultAsync(expression) != null;
    }
}
