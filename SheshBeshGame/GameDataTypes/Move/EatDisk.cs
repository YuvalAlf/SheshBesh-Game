﻿using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class EatDisk : SingleGameMove
    {
        public EatDisk(int sourceColumn, int destinationColumn)
            : base(sourceColumn, destinationColumn)
        { }

        public override Board DoMove(Board board)
        {
            var newColumns = board.columns.Copy();
            newColumns[SourceColumn] = newColumns[SourceColumn].LessDisk();
            newColumns[DestinationColumn] = newColumns[DestinationColumn].ToColor(newColumns[SourceColumn].Color);
            var eatenWhites = board.eatenWhites + (board.columns[DestinationColumn].Color == GameColor.White).AsInt();
            var eatenBlacks = board.eatenBlacks + (board.columns[DestinationColumn].Color == GameColor.Black).AsInt();
            return new Board((byte)eatenWhites, (byte)eatenBlacks, newColumns);
        }
    }
}
