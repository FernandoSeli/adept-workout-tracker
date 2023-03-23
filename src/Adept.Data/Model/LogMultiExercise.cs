using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Adept.Data.Model
{
    public class LogMultiExercise
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }

        public string? Note { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }

        

        public List<LogMultiExerciseSet> MultiExerciseSets { get; set; }
            = new List<LogMultiExerciseSet>();
        public LogMultiExercise()
        { }
        public LogMultiExercise(int order)
        {
            Order = order;
            MultiExerciseSets = new List<LogMultiExerciseSet> { new LogMultiExerciseSet { Order = 1, Weight = 1, WeightAchieved = 1, 
                Repetition = 1, RepsAchieved = 1, ExerciseId = 1} };
        }
        public LogMultiExercise(TemplateMultiExercise templateMultiExercise)
        {
            Order = templateMultiExercise.Order;
            Note = templateMultiExercise.Note;
            MultiExerciseSets = templateMultiExercise.MultiExerciseSets
                .Select(x => new LogMultiExerciseSet(x)).ToList();
            //SetPropertiesFromWorkoutTemplate(workoutTemplateMultiExercise);
        }

        public IEnumerable<int> GetSetOrders() => MultiExerciseSets.Select(x => x.Order);

        public int GetNextExerciseSetOrder() => GetSetOrders().GetFirstAvailableInt();
        public string GetExerciseName() => "Multi Exercise ";
    }
}