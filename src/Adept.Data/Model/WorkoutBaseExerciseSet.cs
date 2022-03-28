using System.ComponentModel.DataAnnotations;

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
        public string Note { get; set; }
    }

    public class WorkoutTemplateExerciseSet : WorkoutBaseExerciseSet
    {
        public int ParenTemplateExercisetSetId { get; set; }
        public WorkoutTemplateExerciseSet ParentTemplateExerciseSet { get; set; }
        public List<WorkoutTemplateExerciseSet> ParentTemplateExerciseSets { get; set; }

        public int WorkoutTemplateExerciseId { get; set; }
        public WorkoutTemplateExercise WorkoutTemplateExercise { get; set; }
    }

    public class WorkoutLogExerciseSet : WorkoutBaseExerciseSet
    {
        public int RepsAchieved { get; set; }
        public int WeightAchieved { get; set; }

        public int ParentSetId { get; set; }
        public WorkoutLogExerciseSet ParentLogExerciseSet { get; set; }
        public List<WorkoutTemplateExerciseSet> WorkoutLogExerciseSets { get; set; }

        public int WorkoutLogExerciseId { get; set; }
        public WorkoutLogExercise WorkoutLogExercise { get; set; }
    }
}