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
        public LogExerciseContainer(int order, bool isMultiExercise)
        {
            IsMultiExercise = isMultiExercise;
            Order = order;
            if (isMultiExercise)
            {

                LogMultiExercises.Add(new LogMultiExercise(1));
            }
            else
            {

                LogSingleExercise = new LogSingleExercise
                {
                    ExerciseId = 1,
                    LogSets = new List<LogSingleExerciseSet> { new LogSingleExerciseSet { Order = 1,
                        Repetition =1, Weight = 1,
                        RepsAchieved = 1, WeightAchieved = 1 } }
                };
            }
        }
        public LogExerciseContainer(TemplateExerciseContainer templateExerciseContainer)
        {
            IsMultiExercise = templateExerciseContainer.IsMultiExercise;
            Order = templateExerciseContainer.Order;
            LogSingleExercise = new LogSingleExercise(templateExerciseContainer.TemplateSingleExercise);
            LogMultiExercises = templateExerciseContainer.TemplateMultiExercises
                .Select(x => new LogMultiExercise(x)).ToList();
        }

        private IEnumerable<int> GetMultiExerciseOrders() => LogMultiExercises.Select(x => x.Order);
        private int GetNextOrder() => GetMultiExerciseOrders().GetFirstAvailableInt();
    }
}