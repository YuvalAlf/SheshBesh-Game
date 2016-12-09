using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class RegularMove : SingleGameMove
    {
        public RegularMove(int sourceColumn, int destinationColumn)
            : base(sourceColumn, destinationColumn)
        { }

        public override Board DoMove(Board board)
        {
            var newColumns = board.columns.Copy();
            newColumns[SourceColumn] = newColumns[SourceColumn].LessDisk();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].AddDisk();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].ToColor(newColumns[SourceColumn].Color);
            return new Board(board.eatenWhites, board.eatenBlacks, newColumns);
        }
    }
}
