using Adept.Data.Extension;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class LogExerciseContainer
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public int Order { get; set; }

        public bool IsMultiExercise { get; set; }

        public LogSingleExercise? LogSingleExercise { get; set; } = new LogSingleExercise();
        public List<LogMultiExercise>? LogMultiExercises { get; set; } = new List<LogMultiExercise>();
        public LogExerciseContainer() { }
        public LogExerciseContainer(TemplateExerciseContainer templateExerciseContainer)
        {
            IsMultiExercise = templateExerciseContainer.IsMultiExercise;
            Order = templateExerciseContainer.Order;
            LogSingleExercise = new LogSingleExercise(templateExerciseContainer.TemplateSingleExercise);
            LogMultiExercises = templateExerciseContainer.TemplateMultiExercises
                .Select(x => new LogMultiExercise(x)).ToList();
        }


        //public int GetNextTemplateExerciseOrder() => GetTemplateExerciseOrders().GetFirstAvailableInt();
    }
}