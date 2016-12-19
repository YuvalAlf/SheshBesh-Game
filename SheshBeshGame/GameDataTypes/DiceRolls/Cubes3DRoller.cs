using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using SheshBeshGame.AppGui.Viewport3D.Dices.SurfaceBrushes;
using SheshBeshGame.Utils.DataTypesUtils;
using SheshBeshGame.Utils.GuiUtils;
using SheshBeshGame.Utils.Math;

namespace SheshBeshGame.GameDataTypes.DiceRolls
{
    public sealed class Cubes3DRoller : DiceRoller
    {
        public PerspectiveCamera Camera { get; }
        public ModelVisual3D Dice1 { get; }
        public ModelVisual3D Dice2 { get; }

        public Cubes3DRoller(PerspectiveCamera camera, ModelVisual3D dice1, ModelVisual3D dice2)
        {
            Camera = camera;
            Dice1 = dice1;
            Dice2 = dice2;
        }

        public override DiceRollRawResult Roll()
        {
            var dice1 = RollFromDice(Camera.Position, Dice1);
            var dice2 = RollFromDice(Camera.Position, Dice2);
            return new DiceRollRawResult(dice1, dice2);
        }

        private static int RollFromDice(Point3D cameraPosition, ModelVisual3D cube)
        {
            var transform = cube.Transform;
            var diceSurfaces = cube
                .DeGroupToGeometries()
                .Select((surface, diceNum) => DiceSurface.FromGeometryModel3D(surface, transform, diceNum + 1))
                .ToArray();
            var minSurface = diceSurfaces.MinBy(surface => surface.Points.SumOfDistancesTo(cameraPosition));
                //.Select(points => points.ApplyTransform(transform))
            minSurface.ApplyBrushToSurface(Colors.BlueViolet);
            return minSurface.DiceNum;
        }

    }
}
