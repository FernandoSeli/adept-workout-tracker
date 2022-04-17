using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseExerciseSet
    {
        [Key]
        public int Id { get; set; }

        public int Repetition { get; set; }
        public int Rest { get; set; }
        public int Weight { get; set; }
        public int Order { get; set; }
        public string? Note { get; set; }

        [NotMapped]
        public string Name => "Set " + Order;
    }

    public class WorkoutTemplateExerciseSet : WorkoutBaseExerciseSet
    {
        //public int ParentTemplateExercisetSetId { get; set; }
        //public WorkoutTemplateExerciseSet? ParentTemplateExerciseSet { get; set; }
        //public List<WorkoutTemplateExerciseSet> DropSets { get; set; } = new List<WorkoutTemplateExerciseSet>();

        public int WorkoutTemplateExerciseId { get; set; }
        public WorkoutTemplateExercise? WorkoutTemplateExercise { get; set; }
    }

    public class WorkoutLogExerciseSet : WorkoutBaseExerciseSet
    {
        public int RepsAchieved { get; set; }
        public int WeightAchieved { get; set; }

        //public int ParentSetId { get; set; }
        //public WorkoutLogExerciseSet ParentLogExerciseSet { get; set; }
        //public List<WorkoutTemplateExerciseSet> ChildLogExerciseSets { get; set; }

        public int WorkoutLogExerciseId { get; set; }
        public WorkoutLogExercise? WorkoutLogExercise { get; set; }
    }
}