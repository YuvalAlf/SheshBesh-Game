using System.Collections.Generic;
using System.Linq;

namespace SheshBeshGame.GameDataTypes
{
    public struct Column
    {
        public byte NumOfDisks { get; }
        public bool IsBlack { get; }
        public bool IsWhite => !IsBlack;
        public bool IsEmpty => NumOfDisks == 0;

        public Column(byte numOfDisks, bool isBlack)
        {
            NumOfDisks = numOfDisks;
            IsBlack = isBlack;
        }

        public static Column Empty => new Column(0, false);
        public GameColor Color => IsBlack ? GameColor.Black : GameColor.White;

        public Column AddDisk() => new Column((byte)(NumOfDisks + 1), IsBlack);
        public Column LessDisk() => new Column((byte)(NumOfDisks - 1), IsBlack);
        public Column ToColor(GameColor newColor) => new Column(NumOfDisks, newColor == GameColor.Black);

        public static IEnumerable<int> All => Enumerable.Range(0, 24);
    }
}
