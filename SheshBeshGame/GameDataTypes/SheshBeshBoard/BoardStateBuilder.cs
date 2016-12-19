using System;
using SheshBeshGame.GameDataTypes.GamePlayer;

namespace SheshBeshGame.GameDataTypes.SheshBeshBoard
{
    public sealed class BoardStateBuilder
    {
        private byte EatenWhites { get; set; }
        private byte EatenBlacks { get; set; }
        private Column[] Columns { get; set; }

        public BoardStateBuilder(byte eatenWhites, byte eatenBlacks, Column[] columns)
        {
            EatenWhites = eatenWhites;
            EatenBlacks = eatenBlacks;
            Columns = columns;
        }

        public Column this[int index]
        {
            get { return Columns[index]; }
            set { Columns[index] = value; }
        }

        public BoardStateBuilder LessDiskAt(int column)
        {
            this.Columns[column] = this.Columns[column].LessDisk();
            return this;
        }
        public BoardStateBuilder AddDiskAt(int column)
        {
            this.Columns[column] = this.Columns[column].AddDisk();
            return this;
        }

        public BoardStateBuilder ToColorAt(int columnIndex, GameColor color)
        {
            this.Columns[columnIndex] = this.Columns[columnIndex].ToColor(color);
            return this;
        }

        public BoardState ToBoardState() => new BoardState(EatenWhites, EatenBlacks, Columns);

        public BoardStateBuilder AddEatenTo(GameColor color)
        {
            switch (color)
            {
                case GameColor.White:
                    this.EatenWhites++;
                    break;
                case GameColor.Black:
                    this.EatenBlacks++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
            return this;
        }
        public BoardStateBuilder LessEatenTo(GameColor color)
        {
            switch (color)
            {
                case GameColor.White:
                    this.EatenWhites--;
                    break;
                case GameColor.Black:
                    this.EatenBlacks--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
            return this;
        }
    }
}
