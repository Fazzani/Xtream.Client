using Shouldly;
using System.Linq;
using Xunit;

namespace Xtream.Client.Tests
{
    public class DefaultHttpClientFactoryUnitTest
    {
        [Fact]
        public void DefaultHttpClientFactory_Should_Create_HttpClient_With_Default_UserAgent()
        {
            // Arrange
            var factory = DefaultHttpClientFactory.Default;

            // Act
            var client = factory.Create();

            // Assert
            client.ShouldNotBeNull();
            var userAgentHeader = client.DefaultRequestHeaders.UserAgent.ToString();
            userAgentHeader.ShouldBe("XtreamClient/1.0");
        }

        [Fact]
        public void DefaultHttpClientFactory_Should_Create_HttpClient_With_Custom_UserAgent()
        {
            // Arrange
            var customUserAgent = "CustomAgent/2.0";
            var factory = new DefaultHttpClientFactory(customUserAgent);

            // Act
            var client = factory.Create();

            // Assert
            client.ShouldNotBeNull();
            var userAgentHeader = client.DefaultRequestHeaders.UserAgent.ToString();
            userAgentHeader.ShouldBe(customUserAgent);
        }

        [Fact]
        public void DefaultHttpClientFactory_Parameterless_Constructor_Should_Use_Default_UserAgent()
        {
            // Arrange
            var factory = new DefaultHttpClientFactory();

            // Act
            var client = factory.Create();

            // Assert
            client.ShouldNotBeNull();
            var userAgentHeader = client.DefaultRequestHeaders.UserAgent.ToString();
            userAgentHeader.ShouldBe("XtreamClient/1.0");
        }

        [Fact]
        public void DefaultHttpClientFactory_Should_Create_HttpClient_Without_UserAgent_When_Empty()
        {
            // Arrange
            var factory = new DefaultHttpClientFactory(string.Empty);

            // Act
            var client = factory.Create();

            // Assert
            client.ShouldNotBeNull();
            client.DefaultRequestHeaders.UserAgent.Count.ShouldBe(0);
        }

        [Fact]
        public void DefaultHttpClientFactory_Should_Create_HttpClient_Without_UserAgent_When_Null()
        {
            // Arrange
            var factory = new DefaultHttpClientFactory(null);

            // Act
            var client = factory.Create();

            // Assert
            client.ShouldNotBeNull();
            client.DefaultRequestHeaders.UserAgent.Count.ShouldBe(0);
        }
    }
}
