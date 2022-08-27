using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Adept.Data.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Routine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsSelected => CurrentRoutine != null;
        public CurrentRoutine? CurrentRoutine { get; set; }
        public List<WorkoutTemplate> WorkoutTemplates { get; set; } = new List<WorkoutTemplate> ();
    }
}