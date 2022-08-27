using Adept.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Blazor.Services
{
    public interface IRoutineService
    {
        Task<IEnumerable<Routine>> GetRoutinesAsync();
        Task<int> GetRoutinesCountAsync();
        Task<Routine?> GetRoutineAsync(int routineId);
        Task<int> AddRoutineAsync(Routine routine);
        Task<int> AddOrUpdateRoutineAsync(Routine routine);
        Task<int> AddOrUpdateCurrentRoutine(int routineId);
        Task<Routine?> GetCurrentRoutineAsync();
    }
}
