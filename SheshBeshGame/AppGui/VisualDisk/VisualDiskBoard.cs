using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.GameDataTypes.SheshBeshBoard;
using SheshBeshGame.Utils.GuiUtils;
using SheshBeshGame.Utils.Math;
using static SheshBeshGame.Utils.Math.ValueNormalization;

namespace SheshBeshGame.AppGui.VisualDisk
{
    // TODO: ZIndex!!
    public sealed class VisualDiskBoard
    {
        private Canvas Canvas { get; set; }
        internal Dictionary<int, LinkedList<DiskElement>> DisksAtColumn { get; }
        internal LinkedList<DiskElement> EatenBlacks { get; }
        internal LinkedList<DiskElement> EatenWhites { get; }

        public VisualDiskBoard()
        {
            DisksAtColumn = new Dictionary<int, LinkedList<DiskElement>>();
            foreach (int columnIndex in Column.AllIndices)
                DisksAtColumn.Add(columnIndex, new LinkedList<DiskElement>());
            EatenBlacks = new LinkedList<DiskElement>();
            EatenWhites = new LinkedList<DiskElement>();
        }

        public void ApplyBoard(BoardState boardState, Canvas canvas)
        {
            this.Canvas = canvas;
            foreach (int columnIndex in Column.AllIndices)
            {
                var column = boardState[columnIndex];
                for (int i = 0; i < column.NumOfDisks; i++)
                {
                    var disk = DiskElement.Create(column.Color);
                    this.AddDiskToColumn(columnIndex, disk);
                    canvas.Children.Add(disk);
                }
            }
            for (int i = 0; i < boardState.EatenBlacks; i++)
            {
                var disk = DiskElement.Create(GameColor.Black);
                this.AddDiskToBlackEatens(disk);
                canvas.Children.Add(disk);
            }
            for (int i = 0; i < boardState.EatenWhites; i++)
            {
                var disk = DiskElement.Create(GameColor.White);
                this.AddDiskToWhiteEatens(disk);
                canvas.Children.Add(disk);
            }

        }

        private readonly ValueNormalization disksColumNormalization =
            new ValueNormalization(new ValueMapping(95, 10), new ValueMapping(85, 15), new ValueMapping(90, 5));
        private void AddDiskToColumn(int columnIndex, DiskElement disk)
        {
            if (this.DisksAtColumn[columnIndex].Count == 0)
                disk.CanvasPosition = InitialCanvasPosition(columnIndex);
            else
                disk.CanvasPosition =
                    this.DisksAtColumn[columnIndex]
                    .First()
                    .CanvasPosition
                    .AddVertical(15)
                    .NormalizeVertically(disksColumNormalization);
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

        private readonly ValueNormalization eatensColumNormalization =
            new ValueNormalization(new ValueMapping(40, 80), new ValueMapping(45, 75), new ValueMapping(35, 85));

        private void AddDiskToBlackEatens(DiskElement disk)
        {
            var position = CanvasPosition.CreateTopLeft(85, 92.5);
            if (EatenBlacks.Count > 0)
                position =
                    EatenBlacks.First()
                    .CanvasPosition
                    .AddVertical(-15)
                    .NormalizeVertically(eatensColumNormalization);
            disk.CanvasPosition = position;
            EatenBlacks.AddFirst(disk);
        }

        private void AddDiskToWhiteEatens(DiskElement disk)
        {
            var position = CanvasPosition.CreateBottomLeft(85, 92.5);
            if (EatenWhites.Count > 0)
                position = 
                    EatenWhites.First()
                    .CanvasPosition
                    .AddVertical(-15)
                    .NormalizeVertically(eatensColumNormalization);
            disk.CanvasPosition = position;
            EatenWhites.AddFirst(disk);
        }
    }
}
