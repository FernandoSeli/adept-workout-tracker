using Adept.Data.Model;

namespace Adept.Data.Repository
{
    public interface IWorkoutTemplateRepository : IGenericRepository<WorkoutTemplate>
    {
        Task<List<WorkoutTemplate>> GetWorkoutTemplatesAsync();
    }
}
