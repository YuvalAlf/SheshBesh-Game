using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SheshBeshGame.Utils
{
    public static class Global
    {
        public static T GetResource<T>(string key)
        {
            return (T) Application.Current.FindResource(key);
        }
    }
}
