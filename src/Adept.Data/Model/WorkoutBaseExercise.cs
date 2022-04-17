using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adept.Data.Model
{
    public class WorkoutBaseExercise
    {
        [Key]
        public int Id { get; set; }

        public string? Note { get; set; }

        public int Order { get; set; }

        public bool IsMultiExercise { get; set; }

        public int? ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }

        [NotMapped]
        public string Name => "Exercise " + Order;
    }

    public class WorkoutTemplateExercise : WorkoutBaseExercise
    {
        public List<WorkoutTemplateExerciseSet>? ExerciseSets { get; set; } = new List<WorkoutTemplateExerciseSet>();

        public int? WorkoutTemplateId { get; set; }
        public WorkoutTemplate? WorkoutTemplate { get; set; }

        public List<WorkoutTemplateExercise>? ChildTemplateExercises { get; set; } = new  List<WorkoutTemplateExercise> ();
        public int? ParentTemplateExerciseId { get; set; }
        public WorkoutTemplateExercise? ParentTemplateExercise { get; set; }
    }

    public class WorkoutLogExercise : WorkoutBaseExercise
    {
        private List<WorkoutLogExerciseSet>? ExerciseSets { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog? WorkoutLog { get; set; }

        public List<WorkoutLogExercise>? ChildLogExercises { get; set; }
        public int ParentLogExerciseId { get; set; }
        public WorkoutLogExercise? ParentLogExercise { get; set; }
    }
}