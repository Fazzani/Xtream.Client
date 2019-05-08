using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public class XtreamClient : IXtreamClient, IDisposable
    {
        private readonly string _xtreamUrlPattern;
        private readonly IXtreamReader _xtreamReader;
        private const string  RegexXtreamUrl =@"^(?<portocol>https?)://(?<host>.*)(:(?<port>\d{2,5}))?/get\.php\?username=(?<username>.*)&password=(?<password>\w+)";

        public XtreamClient()
        {
            _xtreamUrlPattern = RegexXtreamUrl;
            _xtreamReader = new XtreamJsonReader(DefaultHttpClientFactory.Default);
        }

        public XtreamClient(IHttpClientFactory httpClientFactory)
        {
            _xtreamUrlPattern = RegexXtreamUrl;
            _xtreamReader = new XtreamJsonReader(httpClientFactory);
        }

        public XtreamClient(IXtreamReader xtreamReader)
        {
            _xtreamReader = xtreamReader;
        }

        public XtreamClient(string urlPattern, IXtreamReader xtreamReader)
            : this(xtreamReader)
        {
            _xtreamUrlPattern = urlPattern;
        }

        public Task<PlayerApi> GetUserAndServerInfoAsync(string playlistUrl, CancellationToken cancellationToken) =>
            _xtreamReader.GetFromApi<PlayerApi>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.Player_Api, cancellationToken);

        public Task<XtreamPanel> GetPanelAsync(string playlistUrl, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<XtreamPanel>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.Panel_Api, cancellationToken);

        public Task<List<Channels>> GetVodStreamsAsync(string playlistUrl, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.VOD_Streams, cancellationToken);

        public Task<List<Channels>> GetLiveStreamsAsync(string playlistUrl, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.LiveStreams, cancellationToken);

        public Task<List<Channels>> GetLiveStreamsByCategoriesAsync(string playlistUrl, string categoryId, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.LiveStreamsByCategories, cancellationToken, categoryId);

        public Task<List<Live>> GetLiveCategoriesAsync(string playlistUrl, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Live>>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.LiveCategories, cancellationToken);

        public Task<List<Epg_Listings>> GetAllEpgAsync(string playlistUrl, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Epg_Listings>>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.AllEpg, cancellationToken);

        public Task<List<Epg_Listings>> GetShortEpgForStreamAsync(string playlistUrl, string streamId, CancellationToken cancellationToken) =>
            _xtreamReader.GetFromApi<List<Epg_Listings>>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.ShortEpgForStream, cancellationToken, streamId);

        public Task<PlayerApi> GetXmltvAsync(string playlistUrl, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<PlayerApi>(playlistUrl, _xtreamUrlPattern, XtreamApiEnum.Xmltv, cancellationToken);

        public bool IsXtreamPlaylist(string playlistUrl) => Regex.Match(playlistUrl, _xtreamUrlPattern, RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase).Success;

        public void Dispose()
        {
            _xtreamReader?.Dispose();
        }

    }
}
