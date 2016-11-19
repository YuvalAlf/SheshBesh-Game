using System;
using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes
{
    public sealed class ColumnChunk
    {
        private Column[] Columns { get; }

        public ColumnChunk(Column[] columns)
        {
            if (columns.Length != 6)
                throw new ArgumentException("Number of columns in chunk is " + columns.Length + " instead of 6!");
            Columns = columns;
        }

        public Column this[int index]
        {
            get
            {
                index.CheckIfInRangeIncluding(0, 5);
                return Columns[index];
            }
        }
    }
}
