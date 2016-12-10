using System.Windows.Media;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.Utils.GuiUtils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    internal sealed class WhiteDiskElement : DiskElement
    {
        public override GameColor DiskColor => GameColor.White;
        public override DrawingBrush DrawingBrush => Global.GetResource<DrawingBrush>("WhiteDiskBrush");
    }
}
