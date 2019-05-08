using System.Text.RegularExpressions;

namespace Xtream.Client.XtreamConnectionInfo
{
    public class XtUrlConnectionFactory : IXtConnectionFactory
    {
        private const string DefaultRegexXtreamUrl = @"^(?<host>(?:https?://(?:.*)(:(?:\d{2,5}))?))/get\.php\?username=(?<username>.*)&password=(?<password>\w*)";
        private readonly string _playlistUrl;
        private readonly string _regexXtreamUrl;

        public XtUrlConnectionFactory(string playlistUrl, string regexXtreamUrl = DefaultRegexXtreamUrl)
        {
            _playlistUrl = playlistUrl;
            _regexXtreamUrl = regexXtreamUrl;
        }

        public ConnectionInfo Create()
        {
            var match = Regex.Match(_playlistUrl, _regexXtreamUrl, RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
            if (match.Success)
            {
                if (!match.Groups["host"].Success)
                {
                    throw new InvalidXtreamUrlFormatException(_playlistUrl, _regexXtreamUrl);
                }
                if (match.Groups["username"].Success && match.Groups["password"].Success)
                {
                    return new ConnectionInfo(match.Groups["host"].Value, match.Groups["username"].Value, match.Groups["password"].Value);
                }
                else
                {
                    return new ConnectionInfo(match.Groups["host"].Value);
                }
            }
            else
            {
                throw new InvalidXtreamUrlFormatException(_playlistUrl, _regexXtreamUrl);
            }
        }
    }
}
