using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Adept.Data.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; }

        public List<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
        public int ExerciseCategoryId { get; set; }
    }
}