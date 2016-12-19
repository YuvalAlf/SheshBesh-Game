using System.Linq;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class AcquitDisk : SingleGameMove
    {
        public int SourceColumn { get; }

        public AcquitDisk(int sourceColumn)
        {
            SourceColumn = sourceColumn;
        }

        public override BoardState DoMove(BoardState boardState)
        {
            return boardState
                .CloneToBuilder()
                .LessDiskAt(SourceColumn)
                .ToBoardState();
        }

        public override DiskElement GetDiskAtSourceColumn(VisualDiskBoard disksVisualState)
        {
            return disksVisualState.DisksAtColumn[SourceColumn].First();
        }

        public override string ToString() => "Acquit disk at " + SourceColumn;
    }
}
