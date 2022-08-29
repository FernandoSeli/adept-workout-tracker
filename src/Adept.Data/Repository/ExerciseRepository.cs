using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory): base(DbContextFactory)
        {
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<int> GetExercisesCountAsync()
        {
            return await _context.Exercises.CountAsync();
        }
    }
}
