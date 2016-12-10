using System.Collections.Generic;
using System.Linq;

namespace SheshBeshGame.GameDataTypes.DiceRolls
{
    public sealed class DiceRollRawResult
    {
        public int FirstRollResult { get; }
        public int SecondRollResult { get; }

        public DiceRollRawResult(int firstRollResult, int secondRollResult)
        {
            FirstRollResult = firstRollResult;
            SecondRollResult = secondRollResult;
        }

        public List<int[]> AllMoveOptions()
        {
            
            if (FirstRollResult == SecondRollResult)
                return new List<int[]>
                {
                    Enumerable.Repeat(FirstRollResult, 4).ToArray()
                };
            return new List<int[]>
            {
                new []{FirstRollResult, SecondRollResult},
                new []{SecondRollResult, FirstRollResult}
            };
        }
    }
}
