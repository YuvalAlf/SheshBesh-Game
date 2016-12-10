using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SheshBeshGame.Utils.Math;

namespace SheshBeshGame.Utils.GuiUtils
{
    public sealed class CanvasPosition
    {
        public double? Top { get; }
        public double? Bottom { get; }
        public double? Right { get; }
        public double? Left { get; }

        private CanvasPosition(double? top, double? bottom, double? right, double? left)
        {
            Top = top;
            Bottom = bottom;
            Right = right;
            Left = left;
        }

        public static CanvasPosition CreateTopLeft(double top, double left)
            => new CanvasPosition(top, null, null, left);
        public static CanvasPosition CreateTopRight(double top, double right)
            => new CanvasPosition(top, null, right, null);
        public static CanvasPosition CreateBottomLeft(double bottom, double left)
            => new CanvasPosition(null, bottom, null, left);
        public static CanvasPosition CreateBottomRight(double bottom, double right)
            => new CanvasPosition(null, bottom, right, null);

        public CanvasPosition AddHorizonal(double amount)
        {
            if (this.Right != null)
                return new CanvasPosition(Top, Bottom, Right + amount, Left);
            return new CanvasPosition(Top, Bottom, Right, Left + amount);
        }
        public CanvasPosition AddVertical(double amount)
        {
            if (this.Top != null)
                return new CanvasPosition(Top + amount, Bottom, Right, Left);
            return new CanvasPosition(Top, Bottom + amount, Right, Left);
        }

        public void Apply(DependencyObject d)
        {
            if (Right != null)
                d.SetValue(Canvas.RightProperty, Right);
            if (Left != null)
                d.SetValue(Canvas.LeftProperty, Left);
            if (Top != null)
                d.SetValue(Canvas.TopProperty, Top);
            if (Bottom != null)
                d.SetValue(Canvas.BottomProperty, Bottom);
        }
        public CanvasPosition NormalizeVertically(ValueNormalization normalization)
        {
            if (Bottom != null)
                return new CanvasPosition(Top, normalization.Normalize(Bottom.Value), Right, Left);
            return new CanvasPosition(normalization.Normalize(Top.Value), Bottom, Right, Left);
        }
    }
}
