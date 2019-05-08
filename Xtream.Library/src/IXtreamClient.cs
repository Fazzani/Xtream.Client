using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public interface IXtreamClient
    {
        Task<List<Epg_Listings>> GetAllEpgAsync(CancellationToken cancellationToken = default);
        Task<List<Live>> GetLiveCategoriesAsync(CancellationToken cancellationToken = default);
        Task<List<Channels>> GetLiveStreamsAsync(CancellationToken cancellationToken = default);
        Task<List<Channels>> GetLiveStreamsByCategoriesAsync(string categoryId, CancellationToken cancellationToken = default);
        Task<XtreamPanel> GetPanelAsync(CancellationToken cancellationToken = default);
        Task<List<Epg_Listings>> GetShortEpgForStreamAsync(string streamId, CancellationToken cancellationToken = default);
        Task<PlayerApi> GetUserAndServerInfoAsync(CancellationToken cancellationToken = default);
        Task<List<Channels>> GetVodStreamsAsync(CancellationToken cancellationToken = default);
        Task<PlayerApi> GetXmltvAsync(CancellationToken cancellationToken = default);
    }
}
