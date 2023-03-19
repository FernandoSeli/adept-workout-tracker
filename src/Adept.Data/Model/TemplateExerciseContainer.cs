using Adept.Data.Extension;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class TemplateExerciseContainer
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public int Order { get; set; }

        public bool IsMultiExercise { get; set; }

        public TemplateSingleExercise? TemplateSingleExercise { get; set; } = new TemplateSingleExercise();
        public List<TemplateMultiExercise>? TemplateMultiExercises { get; set; } = new List<TemplateMultiExercise>();

        //public int GetNextTemplateExerciseOrder() => GetTemplateExerciseOrders().GetFirstAvailableInt();
    }
}