using System;

namespace Xtream.Client
{
    public class InvalidXtreamConnectionException : Exception
    {
        public InvalidXtreamConnectionException(string message) : base(message)
        {
        }
    }
}
