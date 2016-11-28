using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.Move;

namespace SheshBeshGame.GameDataTypes
{
    public sealed class GameEngine
    {
        private Player WhitePlayer { get; }
        private Player BlackPlayer { get; }

        public DiceRoller DiceRoller { get; }
        private volatile bool play;
        public volatile Board Board;
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
            Board = Board.StartingBoard;
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

                var chosenMove = CurrentPlayer.ChooseMove(Board, Player, optionalMoves);

                /*DiceRoller
                    .Roll()
                    .AllMoveOptions()
                    .Select(m => Board.MoveOptions())*/


            }
        }
    }
}
