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
            return boardState
                .CloneToBuilder()
                .LessEatenTo(EatColumnColor(DestinationColumn))
                .AddEatenTo(EatColumnColor(DestinationColumn).Opposite())
                .ToColorAt(DestinationColumn, EatColumnColor(DestinationColumn))
                .ToBoardState();
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
