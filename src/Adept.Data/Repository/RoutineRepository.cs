using Adept.Data;
using Adept.Data.Extension;
using Adept.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Adept.Data.Repository
{
    public class RoutineRepository : GenericRepository<Routine>, IRoutineRepository
    {
        public RoutineRepository(IDbContextFactory<AdeptDatabaseContext> DbContextFactory) : base(DbContextFactory)
        {
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

        public async Task<List<Routine>> GetRoutinesAsync()
        {
            return await _context.Routines
                .IncludeWorkoutTemplateTree()
                .Include(r => r.CurrentRoutine)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<int> GetRoutinesCountAsync()
        {
            return await _context.Routines.CountAsync();
        }

    }
}