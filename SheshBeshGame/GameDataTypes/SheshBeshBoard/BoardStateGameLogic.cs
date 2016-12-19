using System.Collections.Generic;
using System.Linq;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.Utils.ImmutableList;

namespace SheshBeshGame.GameDataTypes.SheshBeshBoard
{
    public sealed partial class BoardState
    {
        private IEnumerable<SingleGameMove> SingleMoveOptions(int diceRoll, GameColor player)
        {
            if (this.EatenDisksExist(player))
            {
                int destinationColumnIndex = player.RelativeColumnIndex(diceRoll);
                var destinationColumn = this[destinationColumnIndex];
                if (destinationColumn.Color == player || destinationColumn.IsEmpty)
                    yield return new RemoveEatenDisk(destinationColumnIndex);
                else if (destinationColumn.NumOfDisks == 1)
                    yield return new RemoveEatenDiskEats(destinationColumnIndex);
            }
            else
            {
                bool canAquit = true;
                for (int columnIndex = 0; columnIndex <= 23 - diceRoll; columnIndex++)
                {
                    int sourceColumnIndex = player.RelativeColumnIndex(columnIndex);
                    var sourceColumn = this[sourceColumnIndex];
                    if (sourceColumn.NumOfDisks > 0 && sourceColumn.Color == player)
                    {
                        canAquit = false;
                        int destinationColumnIndex = player.RelativeColumnIndex(columnIndex + diceRoll);
                        var destinationColumn = this[destinationColumnIndex];
                        if (destinationColumn.IsEmpty || destinationColumn.Color == player)
                            yield return new RegularMove(sourceColumnIndex, destinationColumnIndex);
                        else if (destinationColumn.NumOfDisks == 1)
                            yield return new EatDisk(sourceColumnIndex, destinationColumnIndex);
                    }
                }
                if (canAquit)
                {
                    int columnIndex = 24 - diceRoll;
                    while (true)
                    {
                        int relativeColumn = player.RelativeColumnIndex(columnIndex);
                        var column = this[relativeColumn];
                        if (column.NumOfDisks > 0 && column.Color == player)
                        {
                            yield return new AcquitDisk(relativeColumn);
                            break;
                        }
                        columnIndex++;
                    }
                }
            }
        }

        private IEnumerable<ImList<SingleGameMove>> MoveOptions(ImList<int> moves, GameColor player)
        {
            if (moves.IsNil)
                yield return ImList<SingleGameMove>.Nil;
            else
                foreach (var firstMove in this.SingleMoveOptions(moves.HeadUnsafe, player))
                    foreach (var restMoves in this.DoSingleMove(firstMove).MoveOptions(moves.TailUnsafe, player))
                        yield return ImList<SingleGameMove>.Cons(firstMove, restMoves);
        }

        public IEnumerable<WholeMove> MoveOptions(DiceRollRawResult diceRoll, GameColor player)
        {
            return
                diceRoll
                .AllMoveOptions()
                .SelectMany(moves => this.MoveOptions(moves, player))
                .Select(moves => new WholeMove(moves));
        }

        public GameStatus GameStatus()
        {
            bool blackExist = false;
            bool whiteExist = false;
            foreach (var column in this.Columns)
                if (column.NumOfDisks > 0)
                    if (column.IsWhite)
                        whiteExist = true;
                    else
                        blackExist = true;
            if (!blackExist)
                return GameDataTypes.GameStatus.BlackWins;
            if (!whiteExist)
                return GameDataTypes.GameStatus.WhiteWins;
            return GameDataTypes.GameStatus.ContinueGame;
        }
    }
}
