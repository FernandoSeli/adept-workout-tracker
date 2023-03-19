using Adept.Data.Extension;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Adept.Data.Model
{
    public class TemplateMultiExercise
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }
        public int Order { get; set; }

        public List<TemplateMultiExerciseSet>? MultiExerciseSets { get; set; } = new List<TemplateMultiExerciseSet>();

        public int TemplateExerciseContainerId { get; set; }
        public TemplateExerciseContainer TemplateExerciseContainer { get; set; }
        public TemplateMultiExercise()
        { }


        public IEnumerable<int> GetSetOrders() => MultiExerciseSets.Select(x => x.Order);

        public int GetNextExerciseSetOrder() => GetSetOrders().GetFirstAvailableInt();
        public string GetExerciseName() => "Multi Exercise " ;
    }
}