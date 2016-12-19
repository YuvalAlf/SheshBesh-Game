using System.Linq;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class RegularMove : SingleGameMove
    {
        public int SourceColumn { get; }
        public int DestinationColumn { get; }

        public RegularMove(int sourceColumn, int destinationColumn)
        {
            SourceColumn = sourceColumn;
            DestinationColumn = destinationColumn;
        }

        public override BoardState DoMove(BoardState boardState)
        {
            return boardState
                .CloneToBuilder()
                .LessDiskAt(SourceColumn)
                .AddDiskAt(DestinationColumn)
                .ToColorAt(DestinationColumn, boardState[SourceColumn].Color)
                .ToBoardState();
        }
        public override DiskElement GetDiskAtSourceColumn(VisualDiskBoard disksVisualState)
        {
            return disksVisualState.DisksAtColumn[SourceColumn].First();
        }
        public override string ToString() => "Move " + SourceColumn + " to " + DestinationColumn;
    }
}
