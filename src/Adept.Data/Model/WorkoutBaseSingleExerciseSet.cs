//using Adept.Data.Extension;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Adept.Data.Model
//{
//    public class WorkoutBaseSingleExerciseSet
//    {
//        [Key]
//        public int Id { get; set; }

//        public int Order { get; set; }
//        public string? Note { get; set; }
//        public int ExerciseId { get; set; }
//        public Exercise Exercise { get; set; }

//        [NotMapped]
//        public string Name => "Multi Set " + Order;
//    }

//    public class WorkoutTemplateSingleExerciseSet : WorkoutBaseSingleExerciseSet
//    {
//        public WorkoutTemplateSingleExerciseSet()
//        {

//        }
//        public WorkoutTemplateSingleExerciseSet(int setOrder)
//        {
//            Order = setOrder;
//        }

//        public List<WorkoutTemplateSet>? Sets { get; set; } = new List<WorkoutTemplateSet>();
//        public int WorkoutTemplateExerciseId { get; set; }
//        public WorkoutTemplateExercise WorkoutTemplateExercise { get; set; }

//        public IEnumerable<int> GetSetOrders() => Sets.Select(x => x.Order);
//        public int GetNextSetOrder() => GetSetOrders().GetFirstAvailableInt();
//    }

//    public class WorkoutLogSingleExerciseSet : WorkoutBaseSingleExerciseSet
//    {
//        public List<WorkoutLogExerciseSet> ExerciseSets { get; set; } = new List<WorkoutLogExerciseSet>();
//        public int WorkoutLogExerciseId { get; set; }
//        public WorkoutLogExercise? WorkoutLogExercise { get; set; }
//    }
//}