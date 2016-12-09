using System;
using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes.Move
{
    public abstract class SingleGameMove
    {
        public const int FinishedColumn = -2;
        public const int EatenColumn = -1;

        public int SourceColumn { get; }
        public int DestinationColumn { get; }

        protected SingleGameMove(int sourceColumn, int destinationColumn)
        {
            SourceColumn = sourceColumn;
            DestinationColumn = destinationColumn;
        }

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
