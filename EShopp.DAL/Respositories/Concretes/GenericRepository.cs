using Microsoft.EntityFrameworkCore;
using EShopp.DAL.Context;

namespace EShopp.DAL.Respositories.Concretes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EShoppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(EShoppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
