using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheshBeshGame.GameDataTypes.DiceRolls
{
    public  sealed class RandomDiceRoller : DiceRoller
    {
        public Random Rnd { get; }

        public RandomDiceRoller(Random rnd)
        {
            Rnd = rnd;
        }

        public override DiceRollRawResult Roll()
        {
            return new DiceRollRawResult(Rnd.Next(1,7), Rnd.Next(1,7));
        }
    }
}
