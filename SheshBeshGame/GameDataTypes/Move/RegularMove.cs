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
            var newBoard = boardState.DeepClone();
            newBoard.columns[SourceColumn] = newBoard.columns[SourceColumn].LessDisk();
            newBoard.columns[DestinationColumn] = newBoard.columns[DestinationColumn].AddDisk();
            newBoard.columns[DestinationColumn] = newBoard.columns[DestinationColumn].ToColor(newBoard.columns[SourceColumn].Color);
            return newBoard;
        }
    }
}
