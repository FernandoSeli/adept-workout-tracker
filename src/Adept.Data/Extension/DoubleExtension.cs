using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Extension
{
    public static class DoubleExtension
    {
        public static double RoundToNearestPoint5(this double weight)
        {
            return Math.Round(weight * 2, MidpointRounding.ToEven) / 2;
        }
    }
}
