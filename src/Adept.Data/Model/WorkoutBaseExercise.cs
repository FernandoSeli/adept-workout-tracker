using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        List<WorkoutTemplateExerciseSet> ExerciseSets { get; set; }

        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }


        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }


        List<WorkoutTemplateExercise> ChildTemplateExercises { get; set; }
        public int ParentTemplateExerciseId { get; set; }
        public WorkoutTemplateExercise ParentTemplateExercise { get; set; }

    }


    public class WorkoutLogExercise : WorkoutBaseExercise
    {

        List<WorkoutLogExerciseSet> ExerciseSets { get; set; }

        public int WorkoutLogId { get; set; }
        public WorkoutLog WorkoutLog { get; set; }


        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }


        List<WorkoutLogExercise> ChildLogExercises { get; set; }
        public int ParentLogExerciseId { get; set; }
        public WorkoutLogExercise ParentLogExercise { get; set; }

    }
}
