using System;

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
    }
}
