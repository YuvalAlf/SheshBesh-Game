using System;

namespace SheshBeshGame.Utils
{
    public static class IntExtensions
    {
        public static void CheckIfInRangeIncluding(this int @this, int lower, int upper)
        {
            if (@this < lower || @this > upper)
                throw new Exception("Arguement " + @this + " is not in range " + lower + ".." + upper);
        }
        public static bool IsInRangeIncluding(this int @this, int lower, int upper)
        {
            return @this >= lower && @this <= upper;
        }
    }
}
