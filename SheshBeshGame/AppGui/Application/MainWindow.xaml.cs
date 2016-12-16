using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;
using SheshBeshGame.Utils.GuiUtils;

namespace SheshBeshGame.AppGui.Application
{
    partial class MainWindow : Window
    {
        private TextBlock Dice1NumberTextBlock => Global.GetResource<TextBlock>("Dice1NumberTextBlock");
        private TextBlock Dice2NumberTextBlock => Global.GetResource<TextBlock>("Dice2NumberTextBlock");
        private Viewport3D DicesViewport => Global.GetResource<Viewport3D>("DicesViewport3D");
        private Random Rnd { get; } = new Random();
        private VisualDiskBoard DisksVisualState { get; } = new VisualDiskBoard();
        private BoardState BoardState { get; set; } = BoardState.StartingBoardState;

        private int Dice1Result => int.Parse(Dice1NumberTextBlock.Text);
        private int Dice2Result => int.Parse(Dice2NumberTextBlock.Text);
        private DiceRollRawResult DiceRoll => new DiceRollRawResult(Dice1Result, Dice2Result);
        private GameColor CurrentPlayer { get; set; } = GameColor.White;


        public MainWindow()
        {
            InitializeComponent();
            this.DicesViewport.MouseLeftButtonDown += OnViewport3DMouseLeftButtonDown;
            this.DicesViewport.MouseLeftButtonUp += OnViewport3DMouseLeftButtonUp;

            DisksVisualState.ApplyBoard(BoardState, WholeBoardCanvas);

            this.DicesViewport.IsEnabled = true;
        }

        private void OnViewport3DMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DicesViewport.CaptureMouse();
        }



        private void OnViewport3DMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DicesViewport.ReleaseMouseCapture();

            DicesViewport
                .Triggers
                .Cast<EventTrigger>()
                .First()
                .Actions
                .Cast<BeginStoryboard>()
                .Iter(b =>  b.Storyboard.Pause(DicesViewport));
            
            Dice1NumberTextBlock.Text = Rnd.Next(1, 7).ToString();
            Dice2NumberTextBlock.Text = Rnd.Next(1, 7).ToString();

          WholeMove[] moveOptions = this.BoardState.MoveOptions(DiceRoll, CurrentPlayer).ToArray();
          DiskElement[] sourceDisks = moveOptions.Select(m => m.Moves.First().GetDiskAtSourceColumn(DisksVisualState)).ToArray();

            foreach (var disk in sourceDisks)
            {
                ObjectAnimationUsingKeyFrames a = new ObjectAnimationUsingKeyFrames();
                
                var keyTime = KeyTime.FromTimeSpan(new TimeSpan(0, 0, 0, 0, 0));
                var drawingBrush = Global.GetResource<DrawingBrush>("ChosenDiskBrush");
                a.KeyFrames.Add(new DiscreteObjectKeyFrame(drawingBrush, keyTime));


                var storyBoard = new Storyboard();
                storyBoard.Children.Add(a);
                storyBoard.FillBehavior = FillBehavior.HoldEnd;
                Storyboard.SetTarget(a, disk);
                Storyboard.SetTargetProperty(a, new PropertyPath("Fill"));
                storyBoard.Begin(WholeBoardCanvas);
            }
          
          //Disks.Where(d => optionalColumns.Contains(d.Column));
        }
    }
}
