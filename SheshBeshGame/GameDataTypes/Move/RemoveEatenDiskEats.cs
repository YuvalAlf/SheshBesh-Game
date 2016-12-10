using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;

namespace SheshBeshGame.GameDataTypes.Move
{
    class RemoveEatenDiskEats : SingleGameMove
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
    }
}
