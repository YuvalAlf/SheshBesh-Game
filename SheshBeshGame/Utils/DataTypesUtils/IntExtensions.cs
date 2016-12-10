namespace SheshBeshGame.Utils.DataTypesUtils
{
    public static class IntExtensions
    {
        public static bool IsInRangeIncluding(this int @this, int lower, int upper)
        {
            return @this >= lower && @this <= upper;
        }
    }
}
