using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Model
{

    [Index(nameof(Name), IsUnique = true)]
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Url { get; set; }


        public List<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
        public int ExerciseCategoryId { get; set; }


    }
}
