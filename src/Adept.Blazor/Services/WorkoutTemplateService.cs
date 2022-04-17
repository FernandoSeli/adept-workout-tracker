using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Blazor.Services
{
    public class WorkoutTemplateService : IWorkoutTemplateService
    {
        private AdeptDatabaseContext _context;

        public WorkoutTemplateService(IDbContextFactory<AdeptDatabaseContext> DbContextFactory)
        {
            _context = DbContextFactory.CreateDbContext();
        }


        public async Task<int> AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
        {
            await _context.WorkoutTemplates.AddAsync(workoutTemplate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate)
        {
            _context.WorkoutTemplates.Update(workoutTemplate);
            return await _context.SaveChangesAsync();
        }
    }
}
