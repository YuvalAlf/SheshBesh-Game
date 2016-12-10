using System;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;

namespace SheshBeshGame.GameDataTypes.GamePlayer
{
    public sealed class RandomPlayer : Player
    {
        public Random Rnd { get; }

        public RandomPlayer(Random rnd)
        {
            Rnd = rnd;
        }

        public override SingleGameMove ChooseMove(BoardState boardState, GameColor player, SingleGameMove[] moves)
        {
            return moves.ChooseRandomly(Rnd);
        }
    }
}
