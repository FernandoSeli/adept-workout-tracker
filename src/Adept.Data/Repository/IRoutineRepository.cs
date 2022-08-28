using Adept.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Repository
{
    public interface IRoutineRepository : IGenericRepository<Routine>
    {
        Task<List<Routine>> GetRoutinesAsync();
        Task<int> GetRoutinesCountAsync();
        Task<Routine?> GetRoutineAsync(int routineId);
        Task<int> AddOrUpdateCurrentRoutine(int routineId);
        Task<Routine?> GetCurrentRoutineAsync();
    }
}
