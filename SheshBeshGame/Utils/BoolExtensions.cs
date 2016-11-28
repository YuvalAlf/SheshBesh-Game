using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheshBeshGame.Utils
{
    public static class BoolExtensions
    {
        public static int AsInt(this bool @this) => @this ? 1 : 0;
    }
}
