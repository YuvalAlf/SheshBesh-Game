using System;
using System.Text;

namespace SheshBeshGame.Utils.DataTypesUtils
{
    public static class ArrayExtensions
    {
        public static T ChooseRandomly<T>(this T[] @this, Random rnd)
        {
            return @this[rnd.Next(0, @this.Length)];
        }
        public static T[] Copy<T>(this T[] @this)
        {
            return @this.Clone() as T[];
        }

        public static string MkString<T>(this T[] @this, string seperator, string start = "", string end = "")
        {
            StringBuilder str = new StringBuilder();

            str.Append(start);

            for (int i = 0; i < @this.Length - 1; i++)
                str.Append(@this[i] + seperator);

            str.Append(@this[@this.Length - 1] + end);

            return str.ToString();
        }
        public static T MinBy<T, S>(this T[] @this, Func<T, S> by)
            where S : IComparable<S>
        {
            T minItem = @this[0];
            S minValue = by(minItem);
            for (int i = 1; i < @this.Length; i++)
                if (by(@this[i]).CompareTo(minValue) < 0)
                {
                    minItem = @this[i];
                    minValue = by(@this[i]);
                }
            return minItem;
        }
    }
}
