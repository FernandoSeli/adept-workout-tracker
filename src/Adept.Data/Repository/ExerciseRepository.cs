using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        private AdeptDatabaseContext _context;

        public ExerciseRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory): base(DbContextFactory)
        {
        }

        public async Task<int> AddExerciseAsync(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return _context.Exercises.AsNoTracking();
        }
    }
}
