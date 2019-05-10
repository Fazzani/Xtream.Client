using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public class XtreamJsonReader : IXtreamReader
    {
        private readonly HttpClient _client;

        public XtreamJsonReader(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.Create();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<T> GetFromApi<T>(ConnectionInfo connectionInfo, XtreamApiEnum xtreamApiEnum, CancellationToken cancellationToken, params string[] extraParams)
        {
            var jsonContent = await _client.GetStringAsync(new Uri(GetApiUrl(connectionInfo, xtreamApiEnum, extraParams)));

            cancellationToken.ThrowIfCancellationRequested();

            jsonContent = TrimJsonAndConvertChannelsToArray(jsonContent);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }

        private static string TrimJsonAndConvertChannelsToArray(string jsonContent)
        {
            jsonContent = Regex.Replace(jsonContent, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
            jsonContent = Regex.Replace(jsonContent, "\"\\d+\":{", "{", RegexOptions.Multiline);
            jsonContent = jsonContent.Replace("\"available_channels\":{", "\"available_channels\":[");
            jsonContent = jsonContent.Replace("}}}", "}]}");
            return jsonContent;
        }

        //TODO: API Builder

        protected virtual string GetApiUrl(ConnectionInfo connectionInfo, XtreamApiEnum xtreamApiEnum, params string[] extraParams)
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append($"{connectionInfo.Server}");

            switch (xtreamApiEnum)
            {
                case XtreamApiEnum.Player_Api:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.LiveCategories:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}&action=get_live_categories");
                    return urlBuilder.ToString();
                case XtreamApiEnum.LiveStreams:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}&action=get_live_streams");
                    return urlBuilder.ToString();
                case XtreamApiEnum.LiveStreamsByCategories:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}&action=get_live_streams&category_id={extraParams[0]}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.Panel_Api:
                    urlBuilder.Append($"/panel_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.VOD_Streams:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}&action=get_vod_streams");
                    return urlBuilder.ToString();
                case XtreamApiEnum.ShortEpgForStream:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}&action=get_short_epg&stream_id={extraParams[0]}");
                    return urlBuilder.ToString();
                case XtreamApiEnum.AllEpg:
                    urlBuilder.Append($"/player_api.php?username={connectionInfo.UserName}&password={connectionInfo.Password}&action=get_simple_data_table");
                    return urlBuilder.ToString();
                case XtreamApiEnum.Xmltv:
                    urlBuilder.Append($"/xmltv.php?username={connectionInfo.UserName}&password={connectionInfo.Password}");
                    return urlBuilder.ToString();
                default:
                    return string.Empty;
            }
        }
    }
}
