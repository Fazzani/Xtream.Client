using Shouldly;
using Xtream.Client.XtreamConnectionInfo;
using Xunit;

namespace Xtream.Client.Tests
{
    public class ConnectionFactoryUnitTest
    {
        [Theory]
        [InlineData("")]
        public void Invalid_ConnectionInfoFromUrl(string url)
        {
            IXtConnectionFactory connectionFactory = new XtUrlConnectionFactory(url);
            Should.Throw<InvalidXtreamUrlFormatException>(() => connectionFactory.Create());
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts", "http://viqdp-o.com:22561", "39h7mtn013", "omP5PMVP6Q")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=&password=omP5PMVP6Q&type=m3u_plus&output=ts", "http://viqdp-o.com:22561", "", "omP5PMVP6Q")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=&type=m3u_plus&output=ts", "http://viqdp-o.com:22561", "39h7mtn013", "")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=&password=&type=m3u_plus&output=ts", "http://viqdp-o.com:22561", "", "")]
        public void Valid_ConnectionInfoFromUrl(string url, string server, string user, string pwd)
        {
            var conection = SampleXtreamConnectionFactory.Create(url);
            var basicConection = SampleXtreamConnectionFactory.Create(server, user, pwd);
            conection.Server.ShouldBe(server);
            conection.Password.ShouldBe(pwd);
            conection.UserName.ShouldBe(user);

            basicConection.ToString().ShouldBe(conection.ToString());
        }

        [Theory]
        [InlineData("http://server.com", "user", "pwd")]
        [InlineData("http://server.com", "", "pwd")]
        [InlineData("http://serv-er.com", "", "")]
        public void Valid_Basic_Connection(string server, string user, string pwd)
        {
            IXtConnectionFactory connectionFactory = new XtBasicConnectionFactory(server, user, pwd);
            Should.NotThrow(() => connectionFactory.Create());
        }

        [Theory]
        [InlineData("", "user", "pwd")]
        public void InValid_Basic_Connection(string server, string user, string pwd)
        {
            IXtConnectionFactory connectionFactory = new XtBasicConnectionFactory(server, user, pwd);
            Should.Throw<InvalidXtreamConnectionException>(() => connectionFactory.Create());
        }
    }
}
