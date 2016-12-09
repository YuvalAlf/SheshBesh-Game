using System;
using System.Windows.Media;
using SheshBeshGame.GameDataTypes;
using SheshBeshGame.Utils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    internal sealed class WhiteDiskElement : DiskElement
    {
        public override GameColor DiskColor => GameColor.White;
        public override DrawingBrush DrawingBrush => Global.GetResource<DrawingBrush>("WhiteDiskBrush");
    }
}
