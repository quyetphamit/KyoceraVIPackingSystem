using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoceraVIPackingSystem.Business
{
   public static class EnumerableMethods
    {
        public static List<T> MakeList<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return new List<T>(source);
        }
    }
}
