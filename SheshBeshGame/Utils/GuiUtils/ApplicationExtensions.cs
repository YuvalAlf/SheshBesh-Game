using System.Windows;

namespace SheshBeshGame.Utils.GuiUtils
{
    public static class Global
    {
        public static T GetResource<T>(string key)
        {
            return (T) Application.Current.FindResource(key);
        }
    }
}
