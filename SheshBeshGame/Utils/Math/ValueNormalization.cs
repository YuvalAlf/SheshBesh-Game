namespace SheshBeshGame.Utils.Math
{
    public sealed class ValueNormalization
    {
        private ValueMapping[] ValueMapper { get; }

        public ValueNormalization(params ValueMapping[] valueMappings)
        {
            ValueMapper = valueMappings;
        }

        public double Normalize(double value)
        {
            foreach (var valueMapper in ValueMapper)
                if (valueMapper.From == value)
                    return valueMapper.To;
            return value;
        }
        public struct ValueMapping
        {
            public double From { get; }
            public double To { get; }

            public ValueMapping(double @from, double to)
            {
                From = @from;
                To = to;
            }
        }
    }
}
