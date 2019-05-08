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

        public async Task<T> GetFromApi<T>(string playlistUrl, string xtreamUrlPattern, XtreamApiEnum xtreamApiEnum, CancellationToken cancellationToken, params string[] extraParams)
        {
            var json = await _client.GetStringAsync(new Uri(GetApiUrl(playlistUrl, xtreamUrlPattern, xtreamApiEnum, extraParams)));
            cancellationToken.ThrowIfCancellationRequested();
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected virtual string GetApiUrl(string playlistUrl, string xtreamUrlPattern, XtreamApiEnum xtreamApiEnum, params string[] extraParams)
        {
            var reg = Regex.Match(playlistUrl, xtreamUrlPattern, RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

            if (reg.Success)
            {
                var urlBuilder = new StringBuilder();
                urlBuilder.Append($"{reg.Groups["portocol"]}://{reg.Groups["host"]}");
                if(reg.Groups["port"].Success)
                    urlBuilder.Append($":{reg.Groups["port"]}");

                switch (xtreamApiEnum)
                {
                    case XtreamApiEnum.Player_Api:
                         urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.LiveCategories:
                        urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}&action=get_live_categories");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.LiveStreams:
                        urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}&action=get_live_streams");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.LiveStreamsByCategories:
                        urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}&action=get_live_streams&category_id={extraParams[0]}");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.Panel_Api:
                        urlBuilder.Append($"/panel_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.VOD_Streams:
                        urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}&action=get_vod_streams");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.ShortEpgForStream:
                        urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}&action=get_short_epg&stream_id={extraParams[0]}");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.AllEpg:
                        urlBuilder.Append($"/player_api.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}&action=get_simple_data_table");
                        return urlBuilder.ToString();
                    case XtreamApiEnum.Xmltv:
                        urlBuilder.Append($"/xmltv.php?username={reg.Groups["username"]}&password={reg.Groups["password"]}");
                        return urlBuilder.ToString();
                    default:
                        return string.Empty;
                }
            }
            else
            {
                throw new InvalidXtreamUrlFormatException(playlistUrl , xtreamUrlPattern);
            }
        }
    }
}
