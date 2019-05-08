using Shouldly;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xtream.Client.XtreamConnectionInfo;
using Xunit;

namespace Xtream.Client.Tests
{
    public class XtreamJsonReaderUnitTest
    {
        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://test-mo.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q")]
        public async Task Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetAllEpgAsync( CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetLiveCategoriesAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveCategoriesAsync( CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetLiveStreamsAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveStreamsAsync( CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetLiveStreamsByCategoriesAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveStreamsByCategoriesAsync("1", CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetPanelAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetPanelAsync( CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetShortEpgForStreamAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetShortEpgForStreamAsync("1", CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetUserAndServerInfoAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetUserAndServerInfoAsync( CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetVodStreamsAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetVodStreamsAsync(CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetXmltvAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetXmltvAsync(CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com", "39h7mtn013", "omP5PMVP6Q")]
        [InlineData("http://viqdp-o.com:22561", "", "omP5PMVP6Q")]
        [InlineData("http://viqdp-o.com:21", "39h7mtn013", "")]
        [InlineData("http://viqdp-o.com:80", "", "")]
        public async Task GetXmltvAsync_BasicAuth_Not_Throw_InvalidXtreamUrlFormatException(string server, string username, string password)
        {
            var xtreamClient = new XtreamClient(new XtBasicConnectionFactory(server, username, password));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetXmltvAsync(CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com", "39h7mtn013", "omP5PMVP6Q")]
        [InlineData("http://viqdp-o.com:22561", "", "omP5PMVP6Q")]
        [InlineData("http://viqdp-o.com:21", "39h7mtn013", "")]
        [InlineData("http://viqdp-o.com:80", "", "")]
        public async Task GetLiveStreamsAsync_BasicAuth_Not_Throw_InvalidXtreamUrlFormatException(string server, string username, string password)
        {
            var xtreamClient = new XtreamClient(new XtBasicConnectionFactory(server, username, password));
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveStreamsAsync(CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=sdq&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q")]
        [InlineData("http://viqsdfp-o.com/get.php?username=39h7mtn013&password=omP5PMVP6Q")]
        public async Task IsXtreamPlaylist_Shoold_true(string url)
        {
            XtreamClient.IsXtreamPlaylist(url).ShouldBe(true);
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&pasword=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?useame=39h7mtn013")]
        [InlineData("http://viqdp-o.com:22561/get.php?password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task IsXtreamPlaylist_Shoold_false(string url)
        {
            XtreamClient.IsXtreamPlaylist(url).ShouldBe(false);
        }
    }
}
