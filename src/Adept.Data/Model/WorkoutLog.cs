using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Adept.Data.Model
{
    public class WorkoutLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? Note { get; set; }

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }

        public List<WorkoutLogSingleExercise>? WorkoutLogSingleExercises { get; set; } = new List<WorkoutLogSingleExercise>();
        public List<WorkoutLogMultiExercise>? WorkoutLogMultiExercises { get; set; } = new List<WorkoutLogMultiExercise>();

        [NotMapped]
        public List<WorkoutLogExercise> WorkoutLogExercises =>
            WorkoutLogSingleExercises.Cast<WorkoutLogExercise>()
            .Concat(WorkoutLogMultiExercises.Cast<WorkoutLogExercise>())
            .ToList();

        public WorkoutLog() { }

        public WorkoutLog(WorkoutTemplate workoutTemplate)
        {
            WorkoutTemplateId = workoutTemplate.Id;
            Date = DateTime.Now;
            WorkoutLogSingleExercises = workoutTemplate.WorkoutTemplateSingleExercises
                .Select(x => new WorkoutLogSingleExercise(x)).ToList();
            WorkoutLogMultiExercises = workoutTemplate.WorkoutTemplateMultiExercises
                .Select(x => new WorkoutLogMultiExercise(x)).ToList();
        }

        public IEnumerable<int> GetTemplateExerciseOrders() =>
            WorkoutLogSingleExercises.Select(x => x.Order)
            .Concat(WorkoutLogMultiExercises.Select(x => x.Order))
            .ToList();

        public int GetNextTemplateExerciseOrder() => GetTemplateExerciseOrders().GetFirstAvailableInt();


    }
}