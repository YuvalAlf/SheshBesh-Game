﻿using System;
using System.Linq;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.Utils.DataTypesUtils;
using static SheshBeshGame.GameDataTypes.GamePlayer.GameColor;

namespace SheshBeshGame.GameDataTypes.SheshBeshBoard
{
    public sealed partial class BoardState
    {
        internal readonly byte eatenWhites;
        internal readonly byte eatenBlacks;
        internal readonly Column[] columns;

        internal BoardState(byte eatenWhites, byte eatenBlacks, Column[] columns)
        {
            this.eatenWhites = eatenWhites;
            this.eatenBlacks = eatenBlacks;
            this.columns = columns;
        }

        public Column this[int index] => columns[index];

        public BoardState DeepClone() => new BoardState(eatenWhites, eatenBlacks, columns.Copy());  

        public BoardState DoSingleMove(SingleGameMove singleMove) => singleMove.DoMove(this);

        public BoardState DoWholeMove(WholeMove wholeMove) => wholeMove.Moves.Aggregate(this, (board, move) => board.DoSingleMove(move));

        public bool EatenDisksExist(GameColor color) => color == White ? eatenWhites > 0 : eatenBlacks > 0;

        private int RelativeColumnIndex(GameColor color, int index) => color == Black ? index : 23 - index;

        public static BoardState StartingBoardState
        {
            get
            {
                var columns = new Column[6*4];
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
                return new BoardState(0, 0, columns);
            }
        }
    }
}
