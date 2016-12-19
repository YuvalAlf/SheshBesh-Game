using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;

namespace SheshBeshGame.Utils.Math
{
    public static class ThreeDMath
    {
        public static double SumOfDistancesTo(this IEnumerable<Point3D> points, Point3D relativePoint)
        {
            return points.Sum(point => point.DistanceTo(relativePoint));
        }

        public static double DistanceTo(this Point3D point1, Point3D point2)
        {
            var dx = point1.X - point2.X;
            var dy = point1.Y - point2.Y;
            var dz = point1.Z - point2.Z;
            return System.Math.Sqrt(dx*dx + dy*dy + dz*dz);
        }
    }
}
