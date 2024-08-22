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

        public IList<T> GetAll()
            => _entities.ToList();

        public async Task<IList<T>> GetAllAsync()
            => await _entities.ToListAsync();


        public IList<T> GetAll(Expression<Func<T, bool>> expression)
            => _entities.Where(expression).ToList();

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression)
             => await _entities.Where(expression).ToListAsync();

        public void Insert(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public async Task InsertAsync(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T entity) {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        //public void Delete(Expression<Func<T, bool>> expression)
        //    => _entities.Where(expression).ExecuteDelete();

        //public async Task DeleteAsync(Expression<Func<T, bool>> expression) {
        //    if (entity == null) {
        //        throw new ArgumentNullException(nameof(entity));
        //    }
        //    _entities.Remove(entity);
        //    await _context.SaveChangesAsync();
        //}

        public bool Exists(Expression<Func<T, bool>> expression)
            => _entities.FirstOrDefault(expression) != null;

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
            => await _entities.FirstOrDefaultAsync(expression) != null;
    }
}
