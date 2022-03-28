using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Model
{
    [Index(nameof(RoutineId), nameof(Name), IsUnique = true)]
    public class WorkoutTemplate
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
        public List<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }
    }
}
