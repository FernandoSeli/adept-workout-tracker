using Adept.Data.Model;

namespace Adept.Blazor.Services
{
    public interface IWorkoutTemplateService
    {
        Task<int> AddWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
        Task<int> AddOrUpdateWorkoutTemplateAsync(WorkoutTemplate workoutTemplate);
    }
}
