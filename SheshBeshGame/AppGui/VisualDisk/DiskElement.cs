using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SheshBeshGame.GameDataTypes;
using SheshBeshGame.Utils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    public abstract class DiskElement : Shape
    {
        protected override Geometry DefiningGeometry => Global.GetResource<Geometry>("OuterCircleGeometry");
        public abstract GameColor DiskColor { get; }
        public abstract DrawingBrush DrawingBrush { get; }
        public Func<int, int> NumOfDisksAtColumn { get; }


        protected DiskElement(Func<int, int> numOfDisksAtColumn)
        {
            this.Fill = DrawingBrush;
            this.NumOfDisksAtColumn = numOfDisksAtColumn;
        }


        public static readonly DependencyProperty ColumnProperty =
            DependencyProperty.Register("Column", typeof(int), typeof(DiskElement), new PropertyMetadata(-1, OnColumnChanged), ValidateColumn);

        public int Column
        {
            get { return (int)this.GetValue(ColumnProperty); }
            set { this.SetValue(ColumnProperty, value); }
        }
        private static bool ValidateColumn(object value)
        {
            return ((int)value).IsInRangeIncluding(-1, 23);
        }

        private static void OnColumnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DiskElement disk = d as DiskElement;
            int newColumn = (int) e.NewValue;
            if (newColumn == -1)
            {
                disk.Opacity = 0.0;
                return;
            }
            disk.Opacity = 1.0;
            int amountOfDisksAtColumn = disk.NumOfDisksAtColumn(newColumn);
            DependencyProperty topBottomProperty = Canvas.TopProperty;
            DependencyProperty leftRightProperty = Canvas.LeftProperty;
            if (newColumn >= 6 && newColumn <= 17)
                leftRightProperty = Canvas.RightProperty;
            if (newColumn >= 12)
                topBottomProperty = Canvas.BottomProperty;

            Func<int, int> unitsFromNearEdge = x =>
            {
                if (x >= 12)
                    x -= 12;
                if (x >= 6)
                    x = 11 - x;
                return x;
            };
                disk.SetValue(topBottomProperty, 5.0 + 15.0 * amountOfDisksAtColumn);
                disk.SetValue(leftRightProperty, 5.0 + 15.0 * unitsFromNearEdge(newColumn));
        }

        public static DiskElement Create(GameColor diskColor, Func<int, int> numOfDisksAtColumn)
        {
            switch (diskColor)
            {
                case GameColor.White:
                    return new WhiteDiskElement(numOfDisksAtColumn);
                case GameColor.Black:
                    return new BlackDiskElement(numOfDisksAtColumn);
                default:
                    throw new ArgumentOutOfRangeException(nameof(diskColor), diskColor, null);
            }
        }
    }
}
