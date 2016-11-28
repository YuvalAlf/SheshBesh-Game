using System;
using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes.Move
{
    public abstract class SingleGameMove
    {
        public abstract Board DoMove(Board board);

        protected static GameColor EatColumnColor(int column)
        {
            if (column.IsInRangeIncluding(0, 5))
                return GameColor.Black;
            if (column.IsInRangeIncluding(18, 23))
                return GameColor.White;
            throw new Exception("Eating to illegal cell");
        }
    }
}
