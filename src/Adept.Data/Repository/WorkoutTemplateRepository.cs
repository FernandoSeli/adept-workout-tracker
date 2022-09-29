using Adept.Data;
using Adept.Data.Extension;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class WorkoutTemplateRepository : GenericRepository<WorkoutTemplate>, IWorkoutTemplateRepository
    {
        public WorkoutTemplateRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory): base(DbContextFactory)
        {
        }

        public async Task<List<WorkoutTemplate>> GetWorkoutTemplatesAsync()
        {
            return await _context.WorkoutTemplates.IncludeExerciseTree().AsNoTracking().ToListAsync();
        }
    }
}
