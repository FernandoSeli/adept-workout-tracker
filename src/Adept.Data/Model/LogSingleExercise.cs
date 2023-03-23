using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Adept.Data.Model
{
    public class LogSingleExercise
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }

        public LogSingleExercise()
        { }


        public List<LogSingleExerciseSet> LogSets { get; set; } = new List<LogSingleExerciseSet>();

        public LogSingleExercise(TemplateSingleExercise workoutTemplateSingleExercise)
        {
            ExerciseId = workoutTemplateSingleExercise.ExerciseId;
            Exercise = workoutTemplateSingleExercise.Exercise;
            LogSets = workoutTemplateSingleExercise.TemplateSets
                .Select(x => new LogSingleExerciseSet(x)).ToList();
            //SetPropertiesFromWorkoutTemplate(workoutTemplateSingleExercise);
        }

        public  IEnumerable<int> GetSetOrders() => LogSets.Select(x => x.Order);

        public int GetNextSetOrder() => GetSetOrders().GetFirstAvailableInt();
        public  string GetExerciseName() => "Exercise " ;
    }
}