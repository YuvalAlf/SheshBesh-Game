namespace SheshBeshGame.Utils.DataTypesUtils
{
    public static class BoolExtensions
    {
        public static int AsInt(this bool @this) => @this ? 1 : 0;
    }
}
