using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;

namespace Adept.Data.Model
{
    public class WorkoutLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? Note { get; set; }

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }

        public List<LogExerciseContainer> LogExerciseContainers = new List<LogExerciseContainer>();
        public WorkoutLog()
        {

        }
        public WorkoutLog(WorkoutTemplate workoutTemplate)
        {
            WorkoutTemplateId = workoutTemplate.Id;
            Date = DateTime.Now;
            LogExerciseContainers = workoutTemplate.TemplateExerciseContainers.Select(x => new LogExerciseContainer(x)).ToList();
        }

        public IEnumerable<int> GetLogExerciseOrders() =>
            LogExerciseContainers.Select(x => x.Order)
            .ToList();

        public int GetNextLogExerciseOrder() => GetLogExerciseOrders().GetFirstAvailableInt();


    }
}