using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xtream.Client.XtreamConnectionInfo;

namespace Xtream.Client
{
    public class XtreamJsonReader : IXtreamReader
    {
        private readonly HttpClient _client;
        private readonly ConnectionInfo _connectionInfo;

        public XtreamJsonReader(IHttpClientFactory httpClientFactory, IXtConnectionFactory xtConnectionFactory)
        {
            _client = httpClientFactory.Create();
            _connectionInfo = xtConnectionFactory.Create();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<T> GetFromApi<T>(XtreamApiEnum xtreamApiEnum, CancellationToken cancellationToken, params string[] extraParams)
        {
            var json = await _client.GetStringAsync(new Uri(GetApiUrl(xtreamApiEnum, extraParams)));
            cancellationToken.ThrowIfCancellationRequested();
            json = Regex.Replace(json, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            json = Regex.Replace(json, "\"\\d+\":{", "{", RegexOptions.Multiline);
            json = json.Replace("\"available_channels\":{", "\"available_channels\":[");
            json = json.Replace("}}}", "}]}");
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected virtual string GetApiUrl(XtreamApiEnum xtreamApiEnum, params string[] extraParams)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append($"{_connectionInfo.Server}");

            switch (xtreamApiEnum)
            {
                case XtreamApiEnum.Player_Api:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.LiveCategories:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}&action=get_live_categories");
                    return urlBuilder.ToString();
                case XtreamApiEnum.LiveStreams:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}&action=get_live_streams");
                    return urlBuilder.ToString();
                case XtreamApiEnum.LiveStreamsByCategories:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}&action=get_live_streams&category_id={extraParams[0]}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.Panel_Api:
                    urlBuilder.Append($"/panel_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.VOD_Streams:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}&action=get_vod_streams");
                    return urlBuilder.ToString();
                case XtreamApiEnum.ShortEpgForStream:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}&action=get_short_epg&stream_id={extraParams[0]}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.AllEpg:
                    urlBuilder.Append($"/player_api.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}&action=get_simple_data_table");
                    return urlBuilder.ToString();
                case XtreamApiEnum.Xmltv:
                    urlBuilder.Append($"/xmltv.php?username={_connectionInfo.UserName}&password={_connectionInfo.Password}");
                    return urlBuilder.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
