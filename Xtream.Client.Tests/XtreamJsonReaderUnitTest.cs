using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shouldly;
using System.Net;
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

        [Theory]
        [InlineData("https://gist.githubusercontent.com/Fazzani/722f67c30ada8bac4602f62a2aaccff6/raw/2d73244bb4b657514417a178bef5d299c65998b6/testmn.json")]
        public async Task xtreamJsonReader_GetPanelInfo(string url)
        {
            var panelJsonData = await GetXtreamPanel(url);

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            MockHttpClient(mockHttpClientFactory, panelJsonData);

            var xtreamJsonReader = new XtreamJsonReader(mockHttpClientFactory.Object, new XtBasicConnectionFactory("http://server.tes", "", ""));
            var panel = await xtreamJsonReader.GetFromApi<XtreamPanel>(XtreamApiEnum.Panel_Api, CancellationToken.None);

            panel.Categories.ShouldNotBeNull();
        }

        private static void MockHttpClient(Mock<IHttpClientFactory> mockHttpClientFactory, string panelJsonData)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(panelJsonData),
               })
               .Verifiable();

            mockHttpClientFactory.Setup(x => x.Create()).Returns(new HttpClient(handlerMock.Object));
        }

        private static async Task<string> GetXtreamPanel(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
