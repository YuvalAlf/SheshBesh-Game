using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes
{
    public sealed class Board
    {
        private ColumnChunk[] ColumnChunks { get; }
        private Dictionary<GameColor, int> EatenDisks { get; } 
        private Board(ColumnChunk[] columnChunks, Dictionary<GameColor, int> eatenDisks)
        {
            ColumnChunks = columnChunks;
            EatenDisks = eatenDisks;
        }

        public int NumOfDisksEaten(GameColor color) => EatenDisks[color];
        public ColumnChunk this[int index]
        {
            get
            {
                index.CheckIfInRangeIncluding(0, 3);
                return ColumnChunks[index];
            }
        }

        public static Board StartingBoard
        {
            get
            {
                var upperLeftChunk = new ColumnChunk(new[]
                {
                    new Column(2, GameColor.White), 
                    Column.Empty, 
                    Column.Empty, 
                    Column.Empty, 
                    Column.Empty,
                    new Column(5, GameColor.Black)
                });
                var upperRightChunk = new ColumnChunk(new[]
                {
                    Column.Empty,
                    new Column(3, GameColor.Black), 
                    Column.Empty, 
                    Column.Empty, 
                    Column.Empty,
                    new Column(5, GameColor.White)
                });
                var downRightChunk = new ColumnChunk(new[]
                {
                    new Column(5, GameColor.Black), 
                    Column.Empty, 
                    Column.Empty, 
                    Column.Empty,
                    new Column(3, GameColor.White),
                    Column.Empty
                });
                var downLeftChunk = new ColumnChunk(new[]
                {
                    new Column(5, GameColor.White),
                    Column.Empty, 
                    Column.Empty, 
                    Column.Empty, 
                    Column.Empty,
                    new Column(2, GameColor.Black)
                });
                return new Board(new[]
                {upperLeftChunk, upperRightChunk, downRightChunk, downLeftChunk},
                    new Dictionary<GameColor, int> {{GameColor.Black, 0}, {GameColor.White, 0}});
            }
        }

    }
}
