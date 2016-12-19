using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace SheshBeshGame.AppGui.Viewport3D.Dices.SurfaceBrushes
{
    public sealed class DiceSurface
    {
        public Point3D[] Points { get; }
        public int DiceNum { get; }
        private GeometryModel3D Model { get; }

        public DiceSurface(Point3D[] points, int diceNum, GeometryModel3D model)
        {
            Points = points;
            DiceNum = diceNum;
            Model = model;
        }


        public static DiceSurface FromGeometryModel3D(GeometryModel3D geometryModel3D, Transform3D transform, int diceNum)
        {
            var meshGeometry = geometryModel3D.Geometry as MeshGeometry3D;
            var points = meshGeometry.Positions.ToArray();
            transform.Transform(points);
            return new DiceSurface(points, diceNum, geometryModel3D);
        }

        public void ApplyBrushToSurface(Color newColor)
        {
            /*var diffusalMaterial = Model.Material as DiffuseMaterial;
            var brush = diffusalMaterial.Brush as DrawingBrush;
            var drawingGroup = brush.Drawing as DrawingGroup;
            var geometryDrawing = drawingGroup.Children[0] as GeometryDrawing;
            //geometryDrawing.Brush = newBrush;
            var colorAnimation = new ColorAnimation(newColor, new Duration(TimeSpan.FromMilliseconds(50)), FillBehavior.HoldEnd);
            Storyboard s = new Storyboard();
            s.Children.Add(colorAnimation);
            Storyboard.SetTarget(colorAnimation, geometryDrawing.Brush);
            //string path = "(DiffuseMaterial.Brush).(DrawingBrush.Drawing).(DrawingGroup.Children).[0].(GeometryDrawing.Brush).(SolidColorBrush.Color)";
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
            s.Begin();*/
        }
    }
}
