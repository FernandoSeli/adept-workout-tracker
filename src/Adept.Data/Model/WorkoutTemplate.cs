using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public List<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }
    }
}