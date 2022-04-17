using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Blazor.Services
{
    public class RoutineService : IRoutineService
    {
        private AdeptDatabaseContext _context;

        public RoutineService(IDbContextFactory<AdeptDatabaseContext> DbContextFactory)
        {
            _context = DbContextFactory.CreateDbContext();
        }

        public async Task<Routine?> GetCurrentRoutineAsync()
        {
            var currentRoutine = _context.CurrentRoutine.FirstOrDefault();
            if (currentRoutine == null) return null;

            return await _context.Routines
                .Include(r => r.WorkoutTemplates)
                .FirstOrDefaultAsync(x => x.Id == currentRoutine.RoutineId);
        }

        public async Task<Routine?> GetRoutineAsync(int routineId)
        {
            return await _context.Routines
                .Include(r => r.WorkoutTemplates)
                .FirstOrDefaultAsync(x => x.Id == routineId);
        }

        public async Task<IEnumerable<Routine>> GetRoutinesAsync()
        {
            return _context.Routines
                .Include(r => r.CurrentRoutine)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.Exercise)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.ExerciseSets)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                    .ThenInclude(templateExercise => templateExercise.ChildTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.Exercise)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                    .ThenInclude(templateExercise => templateExercise.ChildTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.ExerciseSets);
        }

        public async Task<int> UpdateRoutineAsync(Routine routine)
        {
            _context.Routines.Update(routine);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRoutineAsync(Routine routine)
        {
            await _context.Routines.AddAsync(routine);
            foreach (var template in routine.WorkoutTemplates)
            {
                await _context.WorkoutTemplates.AddAsync(template);
                foreach (var templateExercise in template.WorkoutTemplateExercises)
                {
                    await _context.TemplateExercises.AddAsync(templateExercise);
                    foreach (var templateExerciseSet in templateExercise.ExerciseSets)
                    {
                        await _context.TemplateExerciseSets.AddAsync(templateExerciseSet);
                    }
                    foreach (var childExercise in templateExercise.ChildTemplateExercises)
                    {
                        await _context.TemplateExercises.AddAsync(templateExercise);
                    }
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> GetRoutinesCountAsync()
        {
            return await _context.Routines.CountAsync();
        }

        public async Task<int> AddOrUpdateCurrentRoutine(int routineId)
        {
            var currentRoutine = await _context.CurrentRoutine.FirstOrDefaultAsync();

            if (currentRoutine == null)
            {
                currentRoutine = new CurrentRoutine { RoutineId = routineId };
                await _context.CurrentRoutine.AddAsync(currentRoutine);
            }
            else
            {
                currentRoutine.RoutineId = routineId;
                _context.Update(currentRoutine);
            }

            return await _context.SaveChangesAsync();
        }
    }
}