using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class LogSingleExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public int Rest { get; set; }

        public double Weight { get; set; }

        public int Order { get; set; }
        public string? Note { get; set; }

        [NotMapped]
        public string Name => "Set " + Order;

        public int RepsAchieved { get; set; }
        public double WeightAchieved { get; set; }

        public int LogSingleExerciseId { get; set; }
        public LogSingleExercise? LogSingleExercise { get; set; }
        [NotMapped]
        public bool Done { get; set; }

        public LogSingleExerciseSet()
        { }

        public LogSingleExerciseSet(int order)
        {
            Order = order;
        }

        public LogSingleExerciseSet(TemplateSingleExerciseSet workoutTemplateSet)
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