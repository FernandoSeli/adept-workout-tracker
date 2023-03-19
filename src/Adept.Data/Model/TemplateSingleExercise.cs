using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Adept.Data.Model
{
    public class TemplateSingleExercise
    {
        public TemplateSingleExercise()
        { }

        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public virtual int GetNextSetOrder() => GetSetOrders().GetFirstAvailableInt();
        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int TemplateExerciseContainerId { get; set; }
        public TemplateExerciseContainer TemplateExerciseContainer { get; set; }

        public List<TemplateSingleExerciseSet> TemplateSets { get; set; } = new List<TemplateSingleExerciseSet>();


        public  IEnumerable<int> GetSetOrders() => TemplateSets.Select(x => x.Order);

        //public  string GetExerciseName() => "Exercise " + Order;
    }

}