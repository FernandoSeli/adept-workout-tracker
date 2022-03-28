using System.ComponentModel.DataAnnotations;

namespace Adept.Data.Model
{
    public class WorkoutLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Note { get; set; }

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }
        public List<WorkoutLog> WorkoutTemplateExercises { get; set; }
    }
}