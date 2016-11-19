using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SheshBeshGame.GameDataTypes
{
    public struct Column
    {
        public int AmountOfDisks { get; }
        public GameColor DisksColor { get; }

        public Column(int amountOfDisks, GameColor disksColor)
        {
            Debug.Assert(amountOfDisks >= 0);
            AmountOfDisks = amountOfDisks;
            DisksColor = disksColor;
        }

        public bool IsEmpty => AmountOfDisks == 0;
        public static Column Empty => new Column(0, GameColor.Black);
    }
}
