using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adept.Data.Extension
{
    public static class IEnumerableExtension
    {
        public static int GetFirstAvailableInt(this IEnumerable<int> intList)
        {
            var value = Enumerable.Range(1, int.MaxValue)
                                .Except(intList)
                                .FirstOrDefault();
            return value == default ? 1 : value;
        }
    }
}
