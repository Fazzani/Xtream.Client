using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public interface IXtreamClient
    {
        Task<List<Epg_Listings>> GetAllEpgAsync(CancellationToken cancellationToken);
        Task<List<Live>> GetLiveCategoriesAsync(CancellationToken cancellationToken);
        Task<List<Channels>> GetLiveStreamsAsync(CancellationToken cancellationToken);
        Task<List<Channels>> GetLiveStreamsByCategoriesAsync(string categoryId, CancellationToken cancellationToken);
        Task<XtreamPanel> GetPanelAsync(CancellationToken cancellationToken);
        Task<List<Epg_Listings>> GetShortEpgForStreamAsync(string streamId, CancellationToken cancellationToken);
        Task<PlayerApi> GetUserAndServerInfoAsync(CancellationToken cancellationToken);
        Task<List<Channels>> GetVodStreamsAsync(CancellationToken cancellationToken);
        Task<PlayerApi> GetXmltvAsync(CancellationToken cancellationToken);
    }
}
