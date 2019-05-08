using System.Net.Http;

namespace Xtream.Client
{
    public class DefaultHttpClientFactory : IHttpClientFactory
    {
        public HttpClient Create()
        {
            return new HttpClient();
        }

        public static DefaultHttpClientFactory Default => new DefaultHttpClientFactory();
    }
}
