
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class TemplateSingleExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public int Rest { get; set; }

        //todo change to float
        public double Weight { get; set; }

        public int Order { get; set; }
        public string? Note { get; set; }

        [NotMapped]
        public string Name => "Set " + Order;

        public int TemplateSingleExerciseId { get; set; }
        public TemplateSingleExercise TemplateSingleExercise { get; set; }
        public TemplateSingleExerciseSet()
        { }

        public TemplateSingleExerciseSet(int order)
        {
            Order = order;
        }

    }
}