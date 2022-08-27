using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AdeptDatabaseContext _context;

        public GenericRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory)
        {
            _context = DbContextFactory.CreateDbContext();
        }

        public async Task<int> RemoveAsync(T test)
        {
            _context.Remove(test);
            await _context.SaveChangesAsync();

            _context.Entry(test).State = EntityState.Detached;
            return 0;
        }
    }
}