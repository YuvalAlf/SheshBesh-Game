using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;

namespace SheshBeshGame.GameDataTypes.GamePlayer
{
    public abstract class Player
    {
        public abstract SingleGameMove ChooseMove(BoardState boardState, GameColor player, SingleGameMove[] moves);
    }
}
