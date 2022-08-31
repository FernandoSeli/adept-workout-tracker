using Adept.Data.Extension;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    [Index(nameof(RoutineId), nameof(Name), IsUnique = true)]
    public class WorkoutTemplate
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
        public List<WorkoutTemplateSingleExercise>? WorkoutTemplateSingleExercises { get; set; } = new List<WorkoutTemplateSingleExercise>();
        public List<WorkoutTemplateMultiExercise>? WorkoutTemplateMultiExercises { get; set; } = new List<WorkoutTemplateMultiExercise>();

        [NotMapped]
        public List<WorkoutTemplateExercise> WorkoutTemplateExercises =>
            WorkoutTemplateSingleExercises.Cast<WorkoutTemplateExercise>()
            .Concat(WorkoutTemplateMultiExercises.Cast<WorkoutTemplateExercise>())
            .ToList();

        public IEnumerable<int> GetTemplateExerciseOrders() =>
            WorkoutTemplateSingleExercises.Select(x => x.Order)
            .Concat(WorkoutTemplateMultiExercises.Select(x => x.Order))
            .ToList();
        public int GetNextTemplateExerciseOrder() => GetTemplateExerciseOrders().GetFirstAvailableInt();
    }
}