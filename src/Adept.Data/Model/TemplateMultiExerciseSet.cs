using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Adept.Data.Model
{
    public class TemplateMultiExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public double Weight { get; set; }
        public int Order { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int TemplateMultiExerciseId { get; set; }
        public TemplateMultiExercise TemplateMultiExercise { get; set; }

        [NotMapped]
        public string Name => "Exercise " + Order;

        public TemplateMultiExerciseSet() { }

        public TemplateMultiExerciseSet(int order)
        {
            Order = order;
            Exercise = new Exercise
            {
                Name = ""
            };
        }
    }
}