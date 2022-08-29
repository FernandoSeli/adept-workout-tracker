using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public abstract class WorkoutBaseExercise
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public int Order { get; set; }

        public bool IsMultiExercise { get; set; }


        [NotMapped]
        public string Name => "Exercise " + Order;
        //[NotMapped]
        public virtual string GetExerciseName() => "Exercise " + Order;
    }

    public abstract class WorkoutTemplateExercise  : WorkoutBaseExercise
    {
        public WorkoutTemplateExercise()
        {

        }

        public WorkoutTemplateExercise(int order)
        {
            Order = order;
        }

        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }


    }
    public class WorkoutTemplateSingleExercise : WorkoutTemplateExercise
    {
        public WorkoutTemplateSingleExercise()
        {

        }

        public WorkoutTemplateSingleExercise(int order) :base(order)
        {
            Exercise = new Exercise();
        }


        public List<WorkoutTemplateSet> TemplateSets { get; set; } = new List<WorkoutTemplateSet>();

        public IEnumerable<int> GetSetOrders() => TemplateSets.Select(x => x.Order);
        public int GetNextSetOrder() => GetSetOrders().GetFirstAvailableInt();
        public override string GetExerciseName() => "Multi Exercise " + Order;
    }
    public class WorkoutTemplateMultiExercise : WorkoutTemplateExercise
    {
        public WorkoutTemplateMultiExercise()
        {

        }

        public WorkoutTemplateMultiExercise(int order) :base(order)
        {
        }


        public List<WorkoutTemplateMultiExerciseSet> MultiExerciseSets { get; set; } = new List<WorkoutTemplateMultiExerciseSet>();

        public IEnumerable<int> GetMultiExerciseSetOrder() => MultiExerciseSets.Select(x => x.Order);
        public int GetNextMultiExerciseSetOrder() => GetMultiExerciseSetOrder().GetFirstAvailableInt();
    }

    public class WorkoutLogExercise : WorkoutBaseExercise
    {
        private List<WorkoutLogSet>? Sets { get; set; }
        //public List<WorkoutLogMultiExerciseSet>? MultiExerciseSets { get; set; } = new List<WorkoutLogMultiExerciseSet>();

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }

    }
}