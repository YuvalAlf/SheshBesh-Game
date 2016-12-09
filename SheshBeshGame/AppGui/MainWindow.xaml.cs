using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Windows.Shell;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.Utils;

namespace SheshBeshGame.AppGui
{
    partial class MainWindow : Window
    {
        private Random Rnd { get; } = new Random();
        private VisualDiskBoard DisksVisualState { get; } = new VisualDiskBoard();
        private Board BoardState { get; set; } = Board.StartingBoard;

        private int Cube1Result => int.Parse(Cube1Num.Text);
        private int Cube2Result => int.Parse(Cube2Num.Text);
        private DiceRollRawResult DiceRoll => new DiceRollRawResult(Cube1Result, Cube2Result);
        private GameColor CurrentPlayer { get; set; } = GameColor.White;


        public MainWindow()
        {
            InitializeComponent();
            this.CubesViewport.MouseLeftButtonDown += OnViewport3DMouseLeftButtonDown;
            this.CubesViewport.MouseLeftButtonUp += OnViewport3DMouseLeftButtonUp;

            DisksVisualState.ApplyBoard(BoardState, MainCanvas);

            this.CubesViewport.IsEnabled = true;
        }

        private void OnViewport3DMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CubesViewport.CaptureMouse();
        }



        private void OnViewport3DMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CubesViewport.ReleaseMouseCapture();

            Cube1Num.Text = Rnd.Next(1, 7).ToString();
            Cube2Num.Text = Rnd.Next(1, 7).ToString();

          //  WholeMove[] moveOptions = this.BoardState.MoveOptions(DiceRoll, CurrentPlayer).ToArray();
           // int[] optionalColumns = moveOptions.Select(m => m.Moves[0].SourceColumn).ToArray();
           // Disks.Where(d => optionalColumns.Contains(d.Column));
        }
    }
}
