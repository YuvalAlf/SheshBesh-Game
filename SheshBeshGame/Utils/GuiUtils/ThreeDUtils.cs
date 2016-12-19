using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Media3D;

namespace SheshBeshGame.Utils.GuiUtils
{
    public static class ThreeDUtils
    {
        public static IEnumerable<GeometryModel3D> DeGroupToGeometries(this ModelVisual3D @this)
        {
            var model = @this.Content as Model3DGroup;
            return model?.Children.Cast<GeometryModel3D>();
        }
        public static IEnumerable<Point3D> GetPoints(this GeometryModel3D @this)
        {
            var meshGeometry = @this.Geometry as MeshGeometry3D;
            return meshGeometry?.Positions;
        }
    }
}
