using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xtream.Client.XtreamConnectionInfo;

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
        public XtreamClient(IXtConnectionFactory connectionFactory)
        {
            _xtreamReader = new XtreamJsonReader(DefaultHttpClientFactory.Default, connectionFactory);
        }

        /// <summary>
        /// Using default json reader
        /// </summary>
        /// <param name="connectionFactory"></param>
        /// <param name="httpClientFactory"></param>
        public XtreamClient(IXtConnectionFactory connectionFactory, IHttpClientFactory httpClientFactory)
        {
            _xtreamReader = new XtreamJsonReader(httpClientFactory, connectionFactory);
        }

        public XtreamClient(IXtreamReader xtreamReader)
        {
            _xtreamReader = xtreamReader;
        }

        public Task<PlayerApi> GetUserAndServerInfoAsync(CancellationToken cancellationToken) =>
            _xtreamReader.GetFromApi<PlayerApi>(XtreamApiEnum.Player_Api, cancellationToken);

        public Task<XtreamPanel> GetPanelAsync(CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<XtreamPanel>(XtreamApiEnum.Panel_Api, cancellationToken);

        public Task<List<Channels>> GetVodStreamsAsync(CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(XtreamApiEnum.VOD_Streams, cancellationToken);

        public Task<List<Channels>> GetLiveStreamsAsync(CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(XtreamApiEnum.LiveStreams, cancellationToken);

        public Task<List<Channels>> GetLiveStreamsByCategoriesAsync(string categoryId, CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Channels>>(XtreamApiEnum.LiveStreamsByCategories, cancellationToken, categoryId);

        public Task<List<Live>> GetLiveCategoriesAsync(CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Live>>(XtreamApiEnum.LiveCategories, cancellationToken);

        public Task<List<Epg_Listings>> GetAllEpgAsync(CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<List<Epg_Listings>>(XtreamApiEnum.AllEpg, cancellationToken);

        public Task<List<Epg_Listings>> GetShortEpgForStreamAsync(string streamId, CancellationToken cancellationToken) =>
            _xtreamReader.GetFromApi<List<Epg_Listings>>(XtreamApiEnum.ShortEpgForStream, cancellationToken, streamId);

        public Task<PlayerApi> GetXmltvAsync(CancellationToken cancellationToken) =>
             _xtreamReader.GetFromApi<PlayerApi>(XtreamApiEnum.Xmltv, cancellationToken);

        public static bool IsXtreamPlaylist(string playlistUrl, string xtreamUrlPattern = DefaultRegexXtreamUrl) =>
            Regex.Match(playlistUrl, xtreamUrlPattern, RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase).Success;

        public void Dispose()
        {
            _xtreamReader?.Dispose();
        }

    }
}
