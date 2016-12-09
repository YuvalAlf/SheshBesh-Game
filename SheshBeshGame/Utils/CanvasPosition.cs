using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SheshBeshGame.Utils
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
        public CanvasPosition NormalizeVertically(Normalization normalization)
        {
            if (Bottom != null)
            {
                var newBottom = normalization.Mapping.ContainsKey(Bottom.Value)
                    ? normalization.Mapping[Bottom.Value]
                    : Bottom;
                return new CanvasPosition(Top, newBottom, Right, Left);
            }

            var newTop = normalization.Mapping.ContainsKey(Top.Value)
                ? normalization.Mapping[Top.Value]
                : Top;
            return new CanvasPosition(newTop, Bottom, Right, Left);
        }

        public sealed class Normalization
        {
            public Dictionary<double, double> Mapping { get; } = new Dictionary<double, double>();

            public void Add(double from, double to) => Mapping.Add(from, to);
        }
    }
}
