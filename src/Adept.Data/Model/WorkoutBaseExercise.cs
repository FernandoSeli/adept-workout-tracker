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
            var setOrder = GetNextTemplateExerciseSetOrder();
            Exercise = new Exercise();
            Sets.Add(new WorkoutTemplateSet(setOrder));
        }
        public List<WorkoutTemplateSet>? Sets { get; set; } = new List<WorkoutTemplateSet>();

        public int? WorkoutTemplateId { get; set; }
        public WorkoutTemplate? WorkoutTemplate { get; set; }



        public IEnumerable<int> GetTemplateExerciseSetOrders() => Sets.Select(x => x.Order);
        public int GetNextTemplateExerciseSetOrder() => GetTemplateExerciseSetOrders().GetFirstAvailableInt();
    }

    public class WorkoutLogExercise : WorkoutBaseExercise
    {
        private List<WorkoutLogSet>? Sets { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog? WorkoutLog { get; set; }

    }
}