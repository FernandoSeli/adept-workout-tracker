using Adept.Data.Model;

namespace Adept.Data.Repository
{
    public interface IExerciseRepository : IGenericRepository<Exercise>
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<int> GetExercisesCountAsync();
    }
}
