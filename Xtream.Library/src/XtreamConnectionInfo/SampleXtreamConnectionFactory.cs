namespace Xtream.Client.XtreamConnectionInfo
{
    public static class SampleXtreamConnectionFactory
    {
        public static ConnectionInfo Create(string url)
        {
            return new XtUrlConnectionFactory(url).Create();
        }

        public static ConnectionInfo Create(string server, string username, string password)
        {
            return new XtBasicConnectionFactory(server, username, password).Create();
        }
    }
}
