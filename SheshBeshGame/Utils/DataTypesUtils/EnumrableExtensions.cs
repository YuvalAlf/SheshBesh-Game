using System;
using System.Collections.Generic;
using System.Linq;

namespace SheshBeshGame.Utils.DataTypesUtils
{
    public static class EnumrableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> @this) => !@this.Any();
        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> @this) => new LinkedList<T>(@this);

        public static IEnumerable<T> AsEnumerable<T>(this T @this)
        {
            yield return @this;
        }
        public static void Iter<T>(this IEnumerable<T> @this, Action<T> act)
        {
            foreach (var item in @this)
                act.Invoke(item);
        }

    }
}
