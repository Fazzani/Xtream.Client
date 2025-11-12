using System.Net.Http;

namespace Xtream.Client
{
    public class DefaultHttpClientFactory : IHttpClientFactory
    {
        private readonly string _userAgent;

        /// <summary>
        /// Initializes a new instance of the DefaultHttpClientFactory class with an optional User-Agent.
        /// </summary>
        /// <param name="userAgent">The User-Agent header value to set on created HttpClient instances. Defaults to "XtreamClient/1.0".</param>
        public DefaultHttpClientFactory(string userAgent = "XtreamClient/1.0")
        {
            _userAgent = userAgent;
        }

        public HttpClient Create()
        {
            var client = new HttpClient();
            if (!string.IsNullOrEmpty(_userAgent))
            {
                client.DefaultRequestHeaders.Add("User-Agent", _userAgent);
            }
            return client;
        }

        public static DefaultHttpClientFactory Default => new DefaultHttpClientFactory();
    }
}
