using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public int Weight { get; set; }
        public int Order { get; set; }
        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        [NotMapped]
        public string Name => "Exercise " + Order;
    }

    public class WorkoutTemplateExerciseSet : WorkoutBaseExerciseSet
    {
        public WorkoutTemplateExerciseSet()
        {

        }
        public WorkoutTemplateExerciseSet(int setOrder)
        {
            Order = setOrder;
        }


        public int WorkoutTemplateMultiExerciseSetId { get; set; }
        public WorkoutTemplateMultiExerciseSet WorkoutTemplateMultiExerciseSet { get; set; }
    }

    public class WorkoutLogExerciseSet : WorkoutBaseExerciseSet
    {
        public int RepsAchieved { get; set; }
        public int WeightAchieved { get; set; }

        public int WorkoutLogMultiExerciseSetId { get; set; }
        public WorkoutLogMultiExerciseSet? WorkoutLogMultiExerciseSet { get; set; }
    }
}