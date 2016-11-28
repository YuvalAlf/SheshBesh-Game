namespace SheshBeshGame.GameDataTypes.Move
{
    public sealed class WholeMove
    {
        public SingleGameMove[] Moves { get; }

        public WholeMove(SingleGameMove[] moves)
        {
            Moves = moves;
        }

        
    }
}
