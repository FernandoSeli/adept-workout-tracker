using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Model
{
    public class Setting
    {
        [DefaultValue("1")]
        [Key]
        public int Id { get; set; } = 1;

        public bool DarkMode { get; set; }
        public bool UnitIsKg { get; set; }
    }
}
