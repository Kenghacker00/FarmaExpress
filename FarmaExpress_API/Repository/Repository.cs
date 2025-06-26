using FarmaExpress_API.Data;
using FarmaExpress_API.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace FarmaExpress_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FarmaciaDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(FarmaciaDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            return await query.AnyAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
