using Xtream.Client;

namespace Xtream.Client.XtreamConnectionInfo
{
    public class XtBasicConnectionFactory : IXtConnectionFactory
    {
        private readonly string _server;
        private readonly string _username;
        private readonly string _password;

        public XtBasicConnectionFactory(string server, string username, string password)
        {
            _server = server;
            _username = username;
            _password = password;
        }
        public ConnectionInfo Create()
        {
            if (string.IsNullOrEmpty(_server))
            {
                throw new InvalidXtreamConnectionException("Server can't be null or empty");
            }
            return new ConnectionInfo(_server, _username, _password);
        }
    }
}
