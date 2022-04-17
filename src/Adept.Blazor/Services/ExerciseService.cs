using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Blazor.Services
{
    public class ExerciseService : IExerciseService
    {
        private AdeptDatabaseContext _context;

        public ExerciseService(IDbContextFactory<AdeptDatabaseContext> DbContextFactory)
        {
            _context = DbContextFactory.CreateDbContext();
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
