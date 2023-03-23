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

        public string? Url { get; set; }

        public List<LogSingleExercise>? LogSingleExercises { get; set; } = new List<LogSingleExercise>();
        public List<LogMultiExerciseSet>? LogMultiExerciseSets { get; set; } = new List<LogMultiExerciseSet>();
        public List<TemplateSingleExercise>? TemplateSingleExercise { get; set; } = new List<TemplateSingleExercise>();
        public List<TemplateMultiExerciseSet>? TemplateMultiExerciseSets { get; set; } = new List<TemplateMultiExerciseSet>();
        public ExerciseCategory? ExerciseCategory { get; set; }
        public int? ExerciseCategoryId { get; set; }
    }
}