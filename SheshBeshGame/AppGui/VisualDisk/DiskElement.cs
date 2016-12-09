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
        private CanvasPosition canvasPosition = CanvasPosition.CreateTopLeft(0, 0);

        public CanvasPosition CanvasPosition
        {
            get { return canvasPosition; }
            set
            {
                canvasPosition = value;
                canvasPosition.Apply(this);
            }
        }


        protected DiskElement()
        {
            this.Fill = DrawingBrush;
        }

        public static DiskElement Create(GameColor diskColor)
        {
            switch (diskColor)
            {
                case GameColor.White:
                    return new WhiteDiskElement();
                case GameColor.Black:
                    return new BlackDiskElement();
                default:
                    throw new ArgumentOutOfRangeException(nameof(diskColor), diskColor, null);
            }
        }
    }
}
