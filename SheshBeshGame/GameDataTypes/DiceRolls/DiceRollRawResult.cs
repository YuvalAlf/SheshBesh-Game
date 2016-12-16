using System.Collections.Generic;
using System.Linq;
using SheshBeshGame.Utils.ImmutableList;

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

        public ImList<int>[] AllMoveOptions()
        {
            
            if (FirstRollResult == SecondRollResult)
                return new []
                {
                    ImList<int>.Create(Enumerable.Repeat(FirstRollResult, 4))
                };
            return new []
            {
                ImList<int>.Create(FirstRollResult, SecondRollResult),
                ImList<int>.Create(SecondRollResult, FirstRollResult)
            };
        }
    }
}
