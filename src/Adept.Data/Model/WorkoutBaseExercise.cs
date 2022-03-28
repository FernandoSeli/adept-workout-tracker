using System.ComponentModel.DataAnnotations;

namespace Adept.Data.Model
{
    public class WorkoutBaseExercise
    {
        [Key]
        public int Id { get; set; }

        public string Note { get; set; }

        public int Order { get; set; }

        public bool IsMultiExercise { get; set; }
    }

    public class WorkoutTemplateExercise : WorkoutBaseExercise
    {
        private List<WorkoutTemplateExerciseSet> ExerciseSets { get; set; }

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        private List<WorkoutTemplateExercise> ChildTemplateExercises { get; set; }
        public int ParentTemplateExerciseId { get; set; }
        public WorkoutTemplateExercise ParentTemplateExercise { get; set; }
    }

    public class WorkoutLogExercise : WorkoutBaseExercise
    {
        private List<WorkoutLogExerciseSet> ExerciseSets { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        private List<WorkoutLogExercise> ChildLogExercises { get; set; }
        public int ParentLogExerciseId { get; set; }
        public WorkoutLogExercise ParentLogExercise { get; set; }
    }
}