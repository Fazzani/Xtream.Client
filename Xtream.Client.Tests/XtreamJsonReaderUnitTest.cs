using Shouldly;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Xtream.Client.Tests
{
    public class XtreamJsonReaderUnitTest
    {
        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&passw=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?userme=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com/get.php?username=39h7mtn013")]
        public async Task Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<InvalidXtreamUrlFormatException>(xtreamClient.GetAllEpgAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://test-mo.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q")]
        public async Task Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetAllEpgAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetLiveCategoriesAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveCategoriesAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetLiveStreamsAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveStreamsAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetLiveStreamsByCategoriesAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetLiveStreamsByCategoriesAsync(url, "1", CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetPanelAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetPanelAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetShortEpgForStreamAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetShortEpgForStreamAsync(url,"1", CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetUserAndServerInfoAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetUserAndServerInfoAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetVodStreamsAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetVodStreamsAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task GetXmltvAsync_Not_Throw_InvalidXtreamUrlFormatException(string url)
        {
            var xtreamClient = new XtreamClient();
            await Should.ThrowAsync<HttpRequestException>(xtreamClient.GetXmltvAsync(url, CancellationToken.None));
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=sdq&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&password=omP5PMVP6Q")]
        [InlineData("http://viqsdfp-o.com/get.php?username=39h7mtn013&password=omP5PMVP6Q")]
        public async Task IsXtreamPlaylist_Shoold_true(string url)
        {
            var xtreamClient = new XtreamClient();
            xtreamClient.IsXtreamPlaylist(url).ShouldBe(true);
        }

        [Theory]
        [InlineData("http://viqdp-o.com:22561/get.php?username=39h7mtn013&pasword=omP5PMVP6Q&type=m3u_plus&output=ts")]
        [InlineData("http://viqdp-o.com:22561/get.php?useame=39h7mtn013")]
        [InlineData("http://viqdp-o.com:22561/get.php?password=omP5PMVP6Q&type=m3u_plus&output=ts")]
        public async Task IsXtreamPlaylist_Shoold_false(string url)
        {
            var xtreamClient = new XtreamClient();
            xtreamClient.IsXtreamPlaylist(url).ShouldBe(false);
        }
    }
}
