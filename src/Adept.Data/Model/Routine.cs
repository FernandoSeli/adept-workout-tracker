using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Model
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}
