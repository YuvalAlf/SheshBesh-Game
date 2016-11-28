using System;
using System.Collections.Generic;
using System.Linq;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.Move;

namespace SheshBeshGame.GameDataTypes
{
    public sealed class Board
    {
        internal readonly byte eatenWhites;
        internal readonly byte eatenBlacks;
        internal readonly Column[] columns;

        internal Board(byte eatenWhites, byte eatenBlacks, Column[] columns)
        {
            this.eatenWhites = eatenWhites;
            this.eatenBlacks = eatenBlacks;
            this.columns = columns;
        }


        [Obsolete("Not finished function", false)]
        public IEnumerable<SingleGameMove> MoveOptions(int diceRoll, GameColor player)
        {
            yield break;
            /*
            if (EatenDisksExist(player))
            {
                var columnIndex = GetColumn(diceRoll - 1, player);
                var column = columns[columnIndex];
                if (column.IsEmpty || column.Color == player)
                    yield return new RemoveEatenDisk(columnIndex);
            }
            else
            {
                bool diskNotInHome;
                for (int i = 0; i < columns.Length - 6; i++)
                {
                    
                }
            }
                */
        }

        public IEnumerable<WholeMove> MoveOptions(DiceRollRawResult diceRoll, GameColor player)
        {
            return null;
            //  return 
            //   diceRoll
            //     .AllMoveOptions()
            // .Select(moves => moves.Select(m => ))
        }

        public Board DoSingleMove(SingleGameMove singleMove)
        {
            return singleMove.DoMove(this);
        }

        public Board DoWholeMove(WholeMove wholeMove)
        {
            return wholeMove.Moves.Aggregate(this, (board, move) => board.DoSingleMove(move));
        }
        public bool EatenDisksExist(GameColor color)
        {
            switch (color)
            {
                case GameColor.White:
                    return eatenWhites > 0;
                case GameColor.Black:
                    return eatenBlacks > 0;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        public int GetColumn(int column, GameColor color)
        {
            if (color == GameColor.Black)
                column = columns.Length - column;
            return column;
        }

        public static Board StartingBoard
        {
            get
            {
                var columns = new Column[6 * 4];
                columns[0] = new Column(numOfDisks: 2, isBlack: true);
                columns[1] = new Column(numOfDisks: 0, isBlack: false);
                columns[2] = new Column(numOfDisks: 0, isBlack: false);
                columns[3] = new Column(numOfDisks: 0, isBlack: false);
                columns[4] = new Column(numOfDisks: 0, isBlack: false);
                columns[5] = new Column(numOfDisks: 5, isBlack: false);

                columns[6] = new Column(numOfDisks: 0, isBlack: false);
                columns[7] = new Column(numOfDisks: 3, isBlack: false);
                columns[8] = new Column(numOfDisks: 0, isBlack: false);
                columns[9] = new Column(numOfDisks: 0, isBlack: false);
                columns[10] = new Column(numOfDisks: 0, isBlack: false);
                columns[11] = new Column(numOfDisks: 5, isBlack: true);

                columns[12] = new Column(numOfDisks: 5, isBlack: false);
                columns[13] = new Column(numOfDisks: 0, isBlack: false);
                columns[14] = new Column(numOfDisks: 0, isBlack: false);
                columns[15] = new Column(numOfDisks: 0, isBlack: false);
                columns[16] = new Column(numOfDisks: 3, isBlack: true);
                columns[17] = new Column(numOfDisks: 0, isBlack: false);

                columns[18] = new Column(numOfDisks: 5, isBlack: true);
                columns[19] = new Column(numOfDisks: 0, isBlack: false);
                columns[20] = new Column(numOfDisks: 0, isBlack: false);
                columns[21] = new Column(numOfDisks: 0, isBlack: false);
                columns[22] = new Column(numOfDisks: 0, isBlack: false);
                columns[23] = new Column(numOfDisks: 2, isBlack: false);
                return new Board(0, 0, columns);
            }
        }
    }
}
