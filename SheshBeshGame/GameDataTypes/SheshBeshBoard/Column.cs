using System.Collections.Generic;
using System.Linq;
using SheshBeshGame.GameDataTypes.GamePlayer;

namespace SheshBeshGame.GameDataTypes.SheshBeshBoard
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

        public GameColor Color => IsBlack ? GameColor.Black : GameColor.White;

        public Column AddDisk() => new Column((byte)(NumOfDisks + 1), IsBlack);
        public Column LessDisk() => new Column((byte)(NumOfDisks - 1), IsBlack);
        public Column ToColor(GameColor newColor) => new Column(NumOfDisks, newColor == GameColor.Black);

        public static Column Empty => new Column(0, false);
        public static IEnumerable<int> AllIndices => Enumerable.Range(0, 24);
    }
}
