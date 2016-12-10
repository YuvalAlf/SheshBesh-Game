using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;

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
            var newBoard = boardState.DeepClone();
            newBoard.columns[SourceColumn] = newBoard.columns[SourceColumn].LessDisk();
            return newBoard;
        }
    }
}
