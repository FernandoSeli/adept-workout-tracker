using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public WorkoutBaseMultiExerciseSet()
        { }

        public WorkoutBaseMultiExerciseSet(int order)
        {
            Order = order;
        }

        public virtual IEnumerable<int> GetExerciseSetOrders() => new List<int>();

        public int GetNextExerciseSetOrder() => GetExerciseSetOrders().GetFirstAvailableInt();
    }

    public class WorkoutTemplateMultiExerciseSet : WorkoutBaseMultiExerciseSet
    {
        public List<WorkoutTemplateExerciseSet> ExerciseSets { get; set; } = new List<WorkoutTemplateExerciseSet>();

        public int WorkoutTemplateMultiExerciseId { get; set; }
        public WorkoutTemplateMultiExercise WorkoutTemplateMultiExercise { get; set; }

        public WorkoutTemplateMultiExerciseSet()
        {
        }

        public WorkoutTemplateMultiExerciseSet(int order) : base(order)
        {
        }

        public override IEnumerable<int> GetExerciseSetOrders() => ExerciseSets.Select(x => x.Order);
    }

    public class WorkoutLogMultiExerciseSet : WorkoutBaseMultiExerciseSet
    {
        public List<WorkoutLogExerciseSet> ExerciseSets { get; set; } = new List<WorkoutLogExerciseSet>();
        public int WorkoutLogExerciseId { get; set; }
        public WorkoutLogExercise WorkoutLogExercise { get; set; }

        public WorkoutLogMultiExerciseSet()
        {
        }

        public WorkoutLogMultiExerciseSet(int order) : base(order)
        {
        }

        public WorkoutLogMultiExerciseSet(WorkoutTemplateMultiExerciseSet workoutTemplateMultiExercise)
        {
            Order = workoutTemplateMultiExercise.Order;
            Note = workoutTemplateMultiExercise.Note;
            ExerciseSets = workoutTemplateMultiExercise.ExerciseSets.Select(x => new WorkoutLogExerciseSet(x)).ToList();
        }

        public override IEnumerable<int> GetExerciseSetOrders() => ExerciseSets.Select(x => x.Order);
    }
}