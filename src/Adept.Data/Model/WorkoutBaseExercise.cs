using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseExercise
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public int Order { get; set; }

        public bool IsMultiExercise { get; set; }

        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        [NotMapped]
        public string Name => "Exercise " + Order;
    }

    public class WorkoutTemplateExercise : WorkoutBaseExercise
    {
        public WorkoutTemplateExercise()
        {

        }

        public WorkoutTemplateExercise(int order)
        {
            Order = order;
            Exercise = new Exercise();
        }

        public List<WorkoutTemplateSet>? Sets { get; set; } = new List<WorkoutTemplateSet>();
        public List<WorkoutTemplateMultiExerciseSet>? MultiExerciseSets { get; set; } = new List<WorkoutTemplateMultiExerciseSet>();

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }


        public string GetExerciseName()
        {
            if (IsMultiExercise)
            {
                return string.Join(", ", MultiExerciseSets?.Select(x => x.Name));
            }
            return Name;
        }

        public IEnumerable<int> GetSetOrders() => Sets.Select(x => x.Order);
        public int GetNextSetOrder() => GetSetOrders().GetFirstAvailableInt();
        public IEnumerable<int> GetMultiExerciseSetOrders() => MultiExerciseSets.Select(x => x.Order);
        public int GetNextMultiExerciseSetOrder() => GetMultiExerciseSetOrders().GetFirstAvailableInt();
    }

    public class WorkoutLogExercise : WorkoutBaseExercise
    {
        private List<WorkoutLogSet>? Sets { get; set; }
        public List<WorkoutLogMultiExerciseSet>? MultiExerciseSets { get; set; } = new List<WorkoutLogMultiExerciseSet>();

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }

    }
}