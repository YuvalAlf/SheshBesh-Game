using System;
using System.Collections.Generic;
using System.Linq;
using SheshBeshGame.Utils.ImmutableList;

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

        public static ImList<T> ToImList<T>(this IEnumerable<T> @this)
        {
            return ImList<T>.Create(@this);
        }

        public static string MkString<T>(this IEnumerable<T> @this, string seperator, string start = "", string end = "")
            => @this.ToArray().MkString(seperator, start, end);
    }
}
