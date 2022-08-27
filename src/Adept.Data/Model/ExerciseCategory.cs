using System.ComponentModel.DataAnnotations;

namespace Adept.Data.Model
{
    public class ExerciseCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ImagePath { get; set; }

        public List<Exercise>? Exercises { get; set; }
    }
}