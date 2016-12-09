using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes.Move
{
    class RemoveEatenDiskEats : SingleGameMove
    {
        public RemoveEatenDiskEats(int destinationColumn)
            : base(EatenColumn, destinationColumn)
        { }

        public override Board DoMove(Board board)
        {
            var newColumns = board.columns.Copy();
            var diskColor = EatColumnColor(DestinationColumn);
            newColumns[DestinationColumn] = newColumns[DestinationColumn].AddDisk();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].ToColor(diskColor);
            var eatenWhites = board.eatenWhites - (diskColor == GameColor.White).AsInt();
            var eatenBlacks = board.eatenBlacks - (diskColor == GameColor.Black).AsInt();
            eatenWhites += (diskColor == GameColor.Black).AsInt();
            eatenBlacks += (diskColor == GameColor.White).AsInt();
            return new Board((byte)eatenWhites, (byte)eatenBlacks, newColumns);
        }
    }
}
