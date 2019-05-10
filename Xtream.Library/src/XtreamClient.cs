using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public class XtreamClient : IXtreamClient, IDisposable
    {
        private readonly IXtreamReader _xtreamReader;
        private const string DefaultRegexXtreamUrl = @"^(?<host>(?:https?://(?:.*)(:(?:\d{2,5}))?))/get\.php\?username=(?<username>.*)&password=(?<password>\w*)";

        /// <summary>
        /// Using default json reader
        /// </summary>
        /// <param name="connectionFactory"></param>
        /// <param name="httpClientFactory"></param>
        public XtreamClient(IHttpClientFactory httpClientFactory)
        {
            _xtreamReader = new XtreamJsonReader(httpClientFactory);
        }

        public XtreamClient(IXtreamReader xtreamReader)
        {
            _xtreamReader = xtreamReader;
        }

        public Task<PlayerApi> GetUserAndServerInfoAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
            _xtreamReader.GetFromApi<PlayerApi>(connectionInfo, XtreamApiEnum.Player_Api, cancellationToken);

        public Task<XtreamPanel> GetPanelAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<XtreamPanel>(connectionInfo, XtreamApiEnum.Panel_Api, cancellationToken);

        public Task<List<Channels>> GetVodStreamsAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(connectionInfo, XtreamApiEnum.VOD_Streams, cancellationToken);

        public Task<List<Channels>> GetLiveStreamsAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(connectionInfo, XtreamApiEnum.LiveStreams, cancellationToken);

        public Task<List<Channels>> GetLiveStreamsByCategoriesAsync(ConnectionInfo connectionInfo, string categoryId, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(connectionInfo, XtreamApiEnum.LiveStreamsByCategories, cancellationToken, categoryId);

        public Task<List<Live>> GetLiveCategoriesAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Live>>(connectionInfo, XtreamApiEnum.LiveCategories, cancellationToken);

        public Task<List<Epg_Listings>> GetAllEpgAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Epg_Listings>>(connectionInfo, XtreamApiEnum.AllEpg, cancellationToken);

        public Task<List<Epg_Listings>> GetShortEpgForStreamAsync(ConnectionInfo connectionInfo, string streamId, CancellationToken cancellationToken) =>
            _xtreamReader.GetFromApi<List<Epg_Listings>>(connectionInfo, XtreamApiEnum.ShortEpgForStream, cancellationToken, streamId);

        public Task<PlayerApi> GetXmltvAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<PlayerApi>(connectionInfo, XtreamApiEnum.Xmltv, cancellationToken);

        public static bool IsXtreamPlaylist(string playlistUrl, string xtreamUrlPattern = DefaultRegexXtreamUrl) =>
            Regex.Match(playlistUrl, xtreamUrlPattern, RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase).Success;

        public void Dispose()
        {
            _xtreamReader?.Dispose();
        }

    }
}
