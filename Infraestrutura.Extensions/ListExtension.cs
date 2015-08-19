using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Extensions
{
    public static class ListExtension
    {
        public static void AddIfNot(this List<object> list, List<object> others)
        {
            foreach (var item in others)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
        }
        public static void AddIfNot(this List<object> list, object item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }

        }
    }
}
