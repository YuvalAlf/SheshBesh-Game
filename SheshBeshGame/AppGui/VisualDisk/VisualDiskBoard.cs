using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using SheshBeshGame.GameDataTypes;
using SheshBeshGame.Utils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    // TODO: ZIndex!!
    class VisualDiskBoard
    {
        private Canvas Canvas { get; set; }
        private Dictionary<int, LinkedList<DiskElement>> DisksAtColumn { get; }
        private LinkedList<DiskElement> EatenBlacks { get; }
        private LinkedList<DiskElement> EatenWhites { get; }

        public VisualDiskBoard()
        {
            DisksAtColumn = new Dictionary<int, LinkedList<DiskElement>>();
            foreach (int columnIndex in Column.All)
                DisksAtColumn.Add(columnIndex, new LinkedList<DiskElement>());
            EatenBlacks = new LinkedList<DiskElement>();
            EatenWhites = new LinkedList<DiskElement>();
        }

        public void ApplyBoard(Board board, Canvas canvas)
        {
            this.Canvas = canvas;
            foreach (int columnIndex in Column.All)
            {
                var column = board.columns[columnIndex];
                for (int i = 0; i < column.NumOfDisks; i++)
                {
                    var disk = DiskElement.Create(column.Color);
                    this.AddDiskToColumn(columnIndex, disk);
                    canvas.Children.Add(disk);
                }
            }
            for (int i = 0; i < board.eatenBlacks; i++)
            {
                var disk = DiskElement.Create(GameColor.Black);
                this.AddDiskToBlackEatens(disk);
                canvas.Children.Add(disk);
            }
            for (int i = 0; i < board.eatenWhites; i++)
            {
                var disk = DiskElement.Create(GameColor.White);
                this.AddDiskToWhiteEatens(disk);
                canvas.Children.Add(disk);
            }

        }

        private void AddDiskToColumn(int columnIndex, DiskElement disk)
        {
            CanvasPosition.Normalization normalization = new CanvasPosition.Normalization();
            normalization.Add(95, 10);
            normalization.Add(85, 15);
            normalization.Add(90, 5);

            if (this.DisksAtColumn[columnIndex].Count == 0)
                disk.CanvasPosition = InitialCanvasPosition(columnIndex);
            else
                disk.CanvasPosition =
                    this.DisksAtColumn[columnIndex]
                    .First()
                    .CanvasPosition
                    .AddVertical(15)
                    .NormalizeVertically(normalization);
            this.DisksAtColumn[columnIndex].AddFirst(disk);
        }

        private DiskElement RemoveDiskFromColumn(int columnIndex)
        {
            var first = DisksAtColumn[columnIndex].First.Value;
            this.DisksAtColumn[columnIndex].RemoveFirst();
            return first;
        }

        private void MoveDisk(int sourceColumn, int destinationColumn)
        {
            var disk = RemoveDiskFromColumn(sourceColumn);
            AddDiskToColumn(destinationColumn, disk);
        }

        private CanvasPosition InitialCanvasPosition(int columnIndex)
        {
            if (columnIndex < 6)
                return CanvasPosition.CreateTopLeft(5, 5 + columnIndex*15);
            if (columnIndex < 12)
                return CanvasPosition.CreateTopRight(5, 5 + (11 - columnIndex)*15);
            if (columnIndex < 18)
                return CanvasPosition.CreateBottomRight(5, 5 + (columnIndex - 12)*15);
            //if (columnIndex < 24)
            return CanvasPosition.CreateBottomLeft(5, 5 + (23 - columnIndex)*15);
        }

        private void AddDiskToBlackEatens(DiskElement disk)
        {
            CanvasPosition.Normalization normalization = new CanvasPosition.Normalization();
            normalization.Add(40, 80);
            normalization.Add(45, 75);
            normalization.Add(35, 85);

            var position = CanvasPosition.CreateTopLeft(85, 92.5);
            if (EatenBlacks.Count > 0)
                position =
                    EatenBlacks.First()
                    .CanvasPosition
                    .AddVertical(-15)
                    .NormalizeVertically(normalization);
            disk.CanvasPosition = position;
            EatenBlacks.AddFirst(disk);
        }

        private void AddDiskToWhiteEatens(DiskElement disk)
        {
            CanvasPosition.Normalization normalization = new CanvasPosition.Normalization();
            normalization.Add(40, 80);
            normalization.Add(45, 75);
            normalization.Add(35, 85);

            var position = CanvasPosition.CreateBottomLeft(85, 92.5);
            if (EatenWhites.Count > 0)
                position = 
                    EatenWhites.First()
                    .CanvasPosition
                    .AddVertical(-15)
                    .NormalizeVertically(normalization);
            disk.CanvasPosition = position;
            EatenWhites.AddFirst(disk);
        }
    }
}
