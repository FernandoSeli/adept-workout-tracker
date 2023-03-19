using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Adept.Data.Model
{
    public class LogMultiExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public double Weight { get; set; }
        public int Order { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        [NotMapped]
        public string Name => "Exercise " + Order;

        public LogMultiExerciseSet() { }

        public LogMultiExerciseSet(int order)
        {
            Order = order;
            Exercise = new Exercise();
            Exercise.Name = "";
        }
        public int RepsAchieved { get; set; }
        public double WeightAchieved { get; set; }

        public int LogMultiExerciseId { get; set; }
        public LogMultiExercise LogMultiExercise { get; set; }
        [NotMapped]
        public bool Done { get; set; }


        public LogMultiExerciseSet(TemplateMultiExerciseSet workoutTemplateExerciseSet)
        {
            Repetition = workoutTemplateExerciseSet.Repetition;
            RepsAchieved = workoutTemplateExerciseSet.Repetition;
            Weight = workoutTemplateExerciseSet.Weight;
            WeightAchieved = workoutTemplateExerciseSet.Weight;
            ExerciseId = workoutTemplateExerciseSet.ExerciseId;
            Exercise = workoutTemplateExerciseSet.Exercise;
            Order = workoutTemplateExerciseSet.Order;
        }
    }
}