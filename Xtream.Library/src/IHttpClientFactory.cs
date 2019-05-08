using System.Net.Http;

namespace Xtream.Client
{
    public interface IHttpClientFactory
    {
        HttpClient Create();
    }
}
