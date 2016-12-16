using System;
using System.Linq;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class RemoveEatenDiskEats : SingleGameMove
    {
        public int DestinationColumn { get; }

        public RemoveEatenDiskEats(int destinationColumn)
        {
            DestinationColumn = destinationColumn;
        }

        public override BoardState DoMove(BoardState boardState)
        {
            var diskColor = EatColumnColor(DestinationColumn);
            var eatenWhites = boardState.eatenWhites - (diskColor == GameColor.White).AsInt();
            var eatenBlacks = boardState.eatenBlacks - (diskColor == GameColor.Black).AsInt();
            eatenWhites += (diskColor == GameColor.Black).AsInt();
            eatenBlacks += (diskColor == GameColor.White).AsInt();

            var newColumns = boardState.columns.Copy();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].AddDisk();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].ToColor(diskColor);

            return new BoardState((byte)eatenWhites, (byte)eatenBlacks, newColumns);
        }
        public override DiskElement GetDiskAtSourceColumn(VisualDiskBoard disksVisualState)
        {
            var diskColor = EatColumnColor(DestinationColumn);
            switch (diskColor)
            {
                case GameColor.White:
                    return disksVisualState.EatenWhites.First();
                case GameColor.Black:
                    return disksVisualState.EatenBlacks.First();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString() => "Remove eaten to " + DestinationColumn + " and eat";
    }
}
