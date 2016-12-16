using System;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;

namespace SheshBeshGame.GameDataTypes.Move
{
    public abstract class SingleGameMove
    {
        public abstract BoardState DoMove(BoardState boardState);

        protected static GameColor EatColumnColor(int column)
        {
            if (column.IsInRangeIncluding(0, 5))
                return GameColor.Black;
            if (column.IsInRangeIncluding(18, 23))
                return GameColor.White;
            throw new Exception("Eating to illegal cell");
        }

        public abstract DiskElement GetDiskAtSourceColumn(VisualDiskBoard disksVisualState);
    }
}
