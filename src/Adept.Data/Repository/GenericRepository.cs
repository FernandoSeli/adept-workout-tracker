using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AdeptDatabaseContext _context;

        public GenericRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory)
        {
            _context = DbContextFactory.CreateDbContext();
        }

        public async Task<int> AddAsync(T entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(List<T> entities)
        {
            _context.AddRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveRangeAsync(List<T> entities)
        {
            _context.RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddOrUpdateAsync(T entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddOrUpdateRangeAsync(List<T> entities)
        {
            _context.UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }
    }
}