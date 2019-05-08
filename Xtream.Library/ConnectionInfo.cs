namespace Xtream.Client
{
    public class ConnectionInfo
    {
        public ConnectionInfo(string server)
        {
            Server = server;
        }

        public ConnectionInfo(string server, string username, string password) : this(server)
        {
            UserName = username;
            Password = password;
        }

        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
