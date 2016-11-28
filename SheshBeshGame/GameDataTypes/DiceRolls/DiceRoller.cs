using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheshBeshGame.GameDataTypes.DiceRolls
{
    public abstract class DiceRoller
    {
        public abstract DiceRollRawResult Roll();
    }
}
