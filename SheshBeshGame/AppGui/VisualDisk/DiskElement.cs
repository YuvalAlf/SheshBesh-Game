using System;
using System.Windows.Media;
using System.Windows.Shapes;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.Utils.GuiUtils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    public abstract class DiskElement : Shape
    {
        public abstract GameColor DiskColor { get; }
        public abstract DrawingBrush DrawingBrush { get; }

        protected override Geometry DefiningGeometry => Global.GetResource<Geometry>("OuterCircleGeometry");

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
