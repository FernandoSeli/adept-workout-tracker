using Adept.Data.Model;

namespace Adept.Blazor.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<int> AddExerciseAsync(Exercise exercise);
    }
}
