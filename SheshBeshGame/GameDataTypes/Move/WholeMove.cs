using SheshBeshGame.Utils.ImmutableList;

namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class WholeMove
    {
        public ImList<SingleGameMove> Moves { get; }

        public WholeMove(ImList<SingleGameMove> moves)
        {
            Moves = moves;
        }

        public override string ToString() => Moves.ToString();
    }
}
