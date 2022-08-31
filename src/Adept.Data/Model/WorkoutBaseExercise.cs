using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public WorkoutBaseExercise()
        { }

        public WorkoutBaseExercise(int order)
        {
            Order = order;
        }

        public virtual string GetExerciseName() => "Exercise " + Order;

        public virtual IEnumerable<int> GetSetOrders() => new List<int>();

        public virtual int GetNextSetOrder() => GetSetOrders().GetFirstAvailableInt();
    }

    public abstract class WorkoutTemplateExercise : WorkoutBaseExercise
    {
        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }

        public WorkoutTemplateExercise()
        { }

        public WorkoutTemplateExercise(int order) : base(order)
        {
        }
    }

    public class WorkoutTemplateSingleExercise : WorkoutTemplateExercise
    {
        public List<WorkoutTemplateSet> TemplateSets { get; set; } = new List<WorkoutTemplateSet>();

        public WorkoutTemplateSingleExercise()
        { }

        public WorkoutTemplateSingleExercise(int order) : base(order)
        {
            Exercise = new Exercise();
        }

        public override IEnumerable<int> GetSetOrders() => TemplateSets.Select(x => x.Order);

        public override string GetExerciseName() => "Exercise " + Order;
    }

    public class WorkoutTemplateMultiExercise : WorkoutTemplateExercise
    {
        public List<WorkoutTemplateMultiExerciseSet> MultiExerciseSets { get; set; } = new List<WorkoutTemplateMultiExerciseSet>();

        public WorkoutTemplateMultiExercise()
        { }

        public WorkoutTemplateMultiExercise(int order) : base(order)
        {
        }

        public override IEnumerable<int> GetSetOrders() => MultiExerciseSets.Select(x => x.Order);

        public override string GetExerciseName() => "Multi Exercise " + Order;
    }

    public class WorkoutLogExercise : WorkoutBaseExercise
    {
        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }

        public WorkoutLogExercise()
        { }

        public WorkoutLogExercise(int order) : base(order)
        {
        }

        protected void SetPropertiesFromWorkoutTemplate(WorkoutTemplateExercise workoutTemplateExercise)
        {
            Note = workoutTemplateExercise.Note;
            Order = workoutTemplateExercise.Order;
            IsMultiExercise = workoutTemplateExercise.IsMultiExercise;
        }
    }

    public class WorkoutLogSingleExercise : WorkoutLogExercise
    {
        private List<WorkoutLogSet> LogSets { get; set; } = new List<WorkoutLogSet>();

        public WorkoutLogSingleExercise()
        { }

        public WorkoutLogSingleExercise(int order) : base(order)
        {
        }

        public WorkoutLogSingleExercise(WorkoutTemplateSingleExercise workoutTemplateSingleExercise)
        {
            ExerciseId = workoutTemplateSingleExercise.ExerciseId;
            Exercise = workoutTemplateSingleExercise.Exercise;
            LogSets = workoutTemplateSingleExercise.TemplateSets
                .Select(x => new WorkoutLogSet(x)).ToList();
            SetPropertiesFromWorkoutTemplate(workoutTemplateSingleExercise);
        }

        public override IEnumerable<int> GetSetOrders() => LogSets.Select(x => x.Order);

        public override string GetExerciseName() => "Exercise " + Order;
    }

    public class WorkoutLogMultiExercise : WorkoutLogExercise
    {
        public List<WorkoutLogMultiExerciseSet> MultiExerciseSets { get; set; }
            = new List<WorkoutLogMultiExerciseSet>();

        public WorkoutLogMultiExercise()
        { }

        public WorkoutLogMultiExercise(int order) : base(order)
        {
        }

        public WorkoutLogMultiExercise(WorkoutTemplateMultiExercise workoutTemplateMultiExercise)
        {
            MultiExerciseSets = workoutTemplateMultiExercise.MultiExerciseSets
                .Select(x => new WorkoutLogMultiExerciseSet(x)).ToList();
            SetPropertiesFromWorkoutTemplate(workoutTemplateMultiExercise);
        }

        public override IEnumerable<int> GetSetOrders() => MultiExerciseSets.Select(x => x.Order);

        public override string GetExerciseName() => "Multi Exercise " + Order;
    }
}