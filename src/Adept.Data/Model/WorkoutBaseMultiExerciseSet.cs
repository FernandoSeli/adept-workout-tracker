using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseMultiExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Order { get; set; }
        public string? Note { get; set; }

        [NotMapped]
        public string Name => "Multi Set " + Order;
    }

    public class WorkoutTemplateMultiExerciseSet : WorkoutBaseMultiExerciseSet
    {
        public WorkoutTemplateMultiExerciseSet()
        {

        }
        public WorkoutTemplateMultiExerciseSet(int setOrder)
        {
            Order = setOrder;
        }

        public List<WorkoutTemplateExerciseSet> ExerciseSets { get; set; } = new List<WorkoutTemplateExerciseSet>();

        public int WorkoutTemplateMultiExerciseId { get; set; }
        public WorkoutTemplateMultiExercise WorkoutTemplateMultiExercise { get; set; }

        public IEnumerable<int> GetExerciseSetOrders() => ExerciseSets.Select(x => x.Order);
        public int GetNextExerciseSetOrder() => GetExerciseSetOrders().GetFirstAvailableInt();
    }

    public class WorkoutLogMultiExerciseSet : WorkoutBaseMultiExerciseSet
    {
        public List<WorkoutLogExerciseSet> ExerciseSets { get; set; } = new List<WorkoutLogExerciseSet>();
        public int WorkoutLogExerciseId { get; set; }
        public WorkoutLogExercise? WorkoutLogExercise { get; set; }
    }
}