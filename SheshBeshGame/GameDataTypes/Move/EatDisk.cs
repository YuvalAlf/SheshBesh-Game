using System.Linq;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;

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
            var eatenWhites = boardState.eatenWhites + (boardState.columns[DestinationColumn].Color == GameColor.White).AsInt();
            var eatenBlacks = boardState.eatenBlacks + (boardState.columns[DestinationColumn].Color == GameColor.Black).AsInt();

            var newColumns = boardState.columns.Copy();
            newColumns[SourceColumn] = newColumns[SourceColumn].LessDisk();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].ToColor(newColumns[SourceColumn].Color);

            return new BoardState((byte)eatenWhites, (byte)eatenBlacks, newColumns);
        }

        public override DiskElement GetDiskAtSourceColumn(VisualDiskBoard disksVisualState)
        {
            return disksVisualState.DisksAtColumn[SourceColumn].First();
        }
        public override string ToString() => "Eat disk at " + DestinationColumn + " from " + SourceColumn;
    }
}
