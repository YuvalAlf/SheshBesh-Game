using System.Windows.Media;
using SheshBeshGame.GameDataTypes.GamePlayer;
using SheshBeshGame.Utils.GuiUtils;

namespace SheshBeshGame.AppGui.VisualDisk
{
    internal sealed class BlackDiskElement : DiskElement
    {
        public override GameColor DiskColor => GameColor.Black;
        public override DrawingBrush DrawingBrush => Global.GetResource<DrawingBrush>("BlackDiskBrush");
    }
}
