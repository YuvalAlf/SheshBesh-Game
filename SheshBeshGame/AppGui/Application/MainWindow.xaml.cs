using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes.DiceRolls;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.Move;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.DataTypesUtils;
using SheshBeshGame.Utils.GuiUtils;
using SysViewport3D = System.Windows.Controls.Viewport3D;

namespace SheshBeshGame.AppGui.Application
{
    public partial class MainWindow : Window
    {
        private TextBlock Dice1NumberTextBlock => Global.GetResource<TextBlock>("Dice1NumberTextBlock");
        private TextBlock Dice2NumberTextBlock => Global.GetResource<TextBlock>("Dice2NumberTextBlock");
        private SysViewport3D DicesViewport => Global.GetResource<SysViewport3D>("DicesViewport3D");
        private VisualDiskBoard DisksVisualState { get; } = new VisualDiskBoard();
        private BoardState BoardState { get; set; } = BoardState.StartingBoardState;
        private DiceRollRawResult DiceRoll => DiceRoller.Roll();
        private DiceRoller DiceRoller { get; }
        private GameColor CurrentPlayer { get; set; } = GameColor.White;
        private ModelVisual3D DiceOne => DicesViewport.Children[1] as ModelVisual3D;
        private ModelVisual3D DiceTwo => DicesViewport.Children[2] as ModelVisual3D;
        private PerspectiveCamera Camera => DicesViewport.Camera as PerspectiveCamera;


        public MainWindow()
        {
            InitializeComponent();
            this.DiceRoller = new Cubes3DRoller(Camera, DiceOne, DiceTwo);
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
            
            Dice1NumberTextBlock.Text = DiceRoll.FirstRollResult.ToString();
            Dice2NumberTextBlock.Text = DiceRoll.SecondRollResult.ToString();

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
                storyBoard.Begin();
            }
          
          //Disks.Where(d => optionalColumns.Contains(d.Column));
        }
    }
}
