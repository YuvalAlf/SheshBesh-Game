using System;

namespace SheshBeshGame.Utils.OptionUtil
{
    public sealed class NoneOptionException : Exception
    {
        public NoneOptionException(string message) : base(message)
        {
        }
    }
}
