using System;
using System.Windows.Media;
using SheshBeshGame.GameDataTypes;
using SheshBeshGame.Utils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    internal sealed class BlackDiskElement : DiskElement
    {
        public override GameColor DiskColor => GameColor.Black;
        public override DrawingBrush DrawingBrush => Global.GetResource<DrawingBrush>("BlackDiskBrush");
    }
}
