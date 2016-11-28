using System;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.Utils;

namespace SheshBeshGame.GameDataTypes.GamePlayer
{
    public sealed class RandomPlayer : Player
    {
        public Random Rnd { get; }

        public RandomPlayer(Random rnd)
        {
            Rnd = rnd;
        }

        public override SingleGameMove ChooseMove(Board board, GameColor player, SingleGameMove[] moves)
        {
            return moves.ChooseRandomly(Rnd);
        }
    }
}
