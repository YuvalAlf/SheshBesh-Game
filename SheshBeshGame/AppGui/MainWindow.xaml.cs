using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Windows.Shell;
using SheshBeshGame.AppGui.VisualDisk;
using SheshBeshGame.GameDataTypes;
using SheshBeshGame.Utils;

namespace SheshBeshGame.AppGui
{
    partial class MainWindow : Window
    {
        private Random rnd { get; } = new Random();
        private DiskElement[] disks { get; }
        private Board boardState { get; set; }

        private int Cube1Result => int.Parse(Cube1Num.Text);
        private int Cube2Result => int.Parse(Cube2Num.Text);

        private int GetNumOfDisksAtColumn(int column) => disks.Count(d => d.Column == column);
        public MainWindow()
        {
            InitializeComponent();
            this.CubesViewport.MouseLeftButtonDown += OnViewport3DMouseLeftButtonDown;
            this.CubesViewport.MouseLeftButtonUp += OnViewport3DMouseLeftButtonUp;
            this.boardState = Board.StartingBoard;
            this.disks = new DiskElement[0];

            for (int columnIndex = 0; columnIndex < 24; columnIndex++)
            {
                var column = boardState.columns[columnIndex];
                foreach (var _ in Enumerable.Repeat(0, column.NumOfDisks))
                {
                    var d = DiskElement.Create(column.Color, GetNumOfDisksAtColumn);
                    MainCanvas.Children.Add(d);
                    d.Column = columnIndex;
                    disks = disks.Concat(d.AsEnumerable()).ToArray();
                }
            }
            this.CubesViewport.IsEnabled = true;
        }

        private void OnViewport3DMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CubesViewport.CaptureMouse();
        }

        private void OnViewport3DMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CubesViewport.ReleaseMouseCapture();
            Cube1Num.Text = rnd.Next(1, 7).ToString();
            Cube2Num.Text = rnd.Next(1, 7).ToString();

            // TODO: columns available for playing...
        }
    }
}
