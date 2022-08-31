using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public int Rest { get; set; }

        //todo change to float
        public decimal Weight { get; set; }

        public int Order { get; set; }
        public string? Note { get; set; }

        [NotMapped]
        public string Name => "Set " + Order;

        public WorkoutBaseSet()
        { }

        public WorkoutBaseSet(int order)
        {
            Order = order;
        }
    }

    public class WorkoutTemplateSet : WorkoutBaseSet
    {
        public int WorkoutTemplateSingleExerciseId { get; set; }
        public WorkoutTemplateSingleExercise WorkoutTemplateSingleExercise { get; set; }

        public WorkoutTemplateSet()
        { }

        public WorkoutTemplateSet(int order) : base(order)
        {
        }
    }

    public class WorkoutLogSet : WorkoutBaseSet
    {
        public int RepsAchieved { get; set; }

        //todo change to float
        public decimal WeightAchieved { get; set; }

        public int WorkoutLogExerciseId { get; set; }
        public WorkoutLogExercise? WorkoutLogExercise { get; set; }

        public WorkoutLogSet()
        { }

        public WorkoutLogSet(int order) : base(order)
        {
        }

        public WorkoutLogSet(WorkoutTemplateSet workoutTemplateSet)
        {
            Repetition = workoutTemplateSet.Repetition;
            RepsAchieved = workoutTemplateSet.Repetition;
            Weight = workoutTemplateSet.Weight;
            WeightAchieved = workoutTemplateSet.Weight;
            Rest = workoutTemplateSet.Rest;
            Order = workoutTemplateSet.Order;
            Note = workoutTemplateSet.Note;
        }
    }
}