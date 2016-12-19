using System;
using System.Threading;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;

namespace SheshBeshGame.GameDataTypes
{
    [Obsolete("Class not complete", true)]
    public sealed class GameEngine
    {
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }

        public DiceRoller DiceRoller { get; }
        private volatile bool play;
        public volatile BoardState boardState;
        public volatile GameColor Player;
        private readonly Thread playingThread;
        private Player CurrentPlayer => Player == GameColor.White ? WhitePlayer : BlackPlayer;
        public bool IsPlaying => play;
        public void StopPlaying() => play = false;
        public void Play() => play = true;

        public GameEngine(Player whitePlayer, Player blackPlayer, DiceRoller diceRoller , bool startPlaying)
        {
            WhitePlayer = whitePlayer;
            BlackPlayer = blackPlayer;
            DiceRoller = diceRoller;
            play = startPlaying;
            Player = GameColor.White;
            boardState = BoardState.StartingBoardState;
            playingThread = new Thread(PlayGame);
            playingThread.IsBackground = true;
            playingThread.Start();
        }


        private void PlayGame()
        {
            while (true)
            {
                while (!play)
                    Thread.Sleep(40);

                SingleGameMove[] optionalMoves = null;

                var chosenMove = CurrentPlayer.ChooseMove(boardState, Player, optionalMoves);

                /*DiceRoller
                    .Roll()
                    .AllMoveOptions()
                    .Select(m => Board.MoveOptions())*/


            }
        }
    }
}
