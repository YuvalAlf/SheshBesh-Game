using System.Linq;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class EatDisk : SingleGameMove
    {
        public int SourceColumn { get; }
        public int DestinationColumn { get; }

        public EatDisk(int sourceColumn, int destinationColumn)
        {
            SourceColumn = sourceColumn;
            DestinationColumn = destinationColumn;
        }

        public override BoardState DoMove(BoardState boardState)
        {
            return boardState
                .CloneToBuilder()
                .AddEatenTo(boardState[DestinationColumn].Color)
                .LessDiskAt(SourceColumn)
                .ToColorAt(DestinationColumn, boardState[SourceColumn].Color)
                .ToBoardState();
        }

        public override DiskElement GetDiskAtSourceColumn(VisualDiskBoard disksVisualState)
        {
            return disksVisualState.DisksAtColumn[SourceColumn].First();
        }
        public override string ToString() => "Eat disk at " + DestinationColumn + " from " + SourceColumn;
    }
}
