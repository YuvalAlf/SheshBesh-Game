namespace SheshBeshGame.GameDataTypes.GamePlayer
{
    public enum GameColor
    {
        White, Black
    }

    public static class GameColorExtensions
    {
        public static int RelativeColumnIndex(this GameColor color, int index) 
            => color == GameColor.Black ? index : 23 - index;
        public static GameColor Opposite(this GameColor color) 
            => color == GameColor.Black ? GameColor.White : GameColor.Black;
    }
}
