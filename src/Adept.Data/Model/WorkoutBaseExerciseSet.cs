using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        //todo change to float
        public decimal Weight { get; set; }
        public int Order { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        [NotMapped]
        public string Name => "Exercise " + Order;

        public WorkoutBaseExerciseSet() { }

        public WorkoutBaseExerciseSet(int order)
        {
            Order = order;
        }
    }

    public class WorkoutTemplateExerciseSet : WorkoutBaseExerciseSet
    {
        public int WorkoutTemplateMultiExerciseSetId { get; set; }
        public WorkoutTemplateMultiExerciseSet WorkoutTemplateMultiExerciseSet { get; set; }

        public WorkoutTemplateExerciseSet() { }

        public WorkoutTemplateExerciseSet(int order) : base(order) { }
    }

    public class WorkoutLogExerciseSet : WorkoutBaseExerciseSet
    {
        public int RepsAchieved { get; set; }
        //todo change to float
        public decimal WeightAchieved { get; set; }

        public int WorkoutLogMultiExerciseSetId { get; set; }
        public WorkoutLogMultiExerciseSet WorkoutLogMultiExerciseSet { get; set; }

        public WorkoutLogExerciseSet() { }

        public WorkoutLogExerciseSet(int order) : base(order) { }

        public WorkoutLogExerciseSet(WorkoutTemplateExerciseSet workoutTemplateExerciseSet)
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