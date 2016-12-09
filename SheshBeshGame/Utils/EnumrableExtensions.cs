using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheshBeshGame.Utils
{
    public static class EnumrableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this T @this)
        {
            yield return @this;
        }
        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> @this)
        {
            return new LinkedList<T>(@this);
        }
        public static void Iter<T>(this IEnumerable<T> @this, Action<T> act)
        {
            foreach (var item in @this)
                act.Invoke(item);
        }
    }
}
