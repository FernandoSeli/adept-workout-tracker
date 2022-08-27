using Adept.Data;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class RoutineRepository : GenericRepository<Routine>, IRoutineRepository
    {
        public RoutineRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory) : base(DbContextFactory)
        {
        }

        //private AdeptDatabaseContext _context;

        //public RoutineRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory)
        //{
        //    _context = DbContextFactory.CreateDbContext();
        //}

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
            return await _context.Routines
                .Include(r => r.CurrentRoutine)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.Exercise)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.Sets)
                .Include(r => r.WorkoutTemplates)
                    .ThenInclude(template => template.WorkoutTemplateExercises)
                        .ThenInclude(templateExercise => templateExercise.MultiExerciseSets)
                            .ThenInclude(templateMultiExercise => templateMultiExercise.ExerciseSets)
                                .ThenInclude(exerciseSet => exerciseSet.Exercise)
                 .ToListAsync();
        }

        public async Task<int> GetRoutinesCountAsync()
        {
            return await _context.Routines.CountAsync();
        }

    }
}