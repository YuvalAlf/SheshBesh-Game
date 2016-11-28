using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SheshBeshGame.GameDataTypes.Move;

namespace SheshBeshGame.GameDataTypes.GamePlayer
{
    public abstract class Player
    {
        public abstract SingleGameMove ChooseMove(Board board, GameColor player, SingleGameMove[] moves);
    }
}
