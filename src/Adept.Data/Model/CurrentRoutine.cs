using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Model
{
    public class CurrentRoutine
    {
        [DefaultValue("1")]
        [Key]
        public int Id { get; set; } = 1;

        public int? RoutineId { get; set; }
        public Routine Routine { get; set; }
    }
}
