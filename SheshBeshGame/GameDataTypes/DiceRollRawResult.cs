using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes
{
    public sealed class DiceRollRawResult
    {
        public int FirstRollResult { get; }
        public int SecondRollResult { get; }

        public DiceRollRawResult(int firstRollResult, int secondRollResult)
        {
            firstRollResult.CheckIfInRangeIncluding(1, 6);
            secondRollResult.CheckIfInRangeIncluding(1, 6);
            FirstRollResult = firstRollResult;
            SecondRollResult = secondRollResult;
        }
    }
}
