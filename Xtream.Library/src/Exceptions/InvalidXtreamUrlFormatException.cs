using System;

namespace Xtream.Client
{
    public class InvalidXtreamUrlFormatException : Exception
    {
        public InvalidXtreamUrlFormatException(string playlistUrl, string pattern) : base($"Invalid pattern matcher {pattern} for playlist ${playlistUrl}")
        {
        }

    }
}
