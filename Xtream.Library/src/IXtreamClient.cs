using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public interface IXtreamClient
    {
        Task<List<Epg_Listings>> GetAllEpgAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
        Task<List<Live>> GetLiveCategoriesAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
        Task<List<Channels>> GetLiveStreamsAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
        Task<List<Channels>> GetLiveStreamsByCategoriesAsync(ConnectionInfo connectionInfo, string categoryId, CancellationToken cancellationToken = default);
        Task<XtreamPanel> GetPanelAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
        Task<List<Epg_Listings>> GetShortEpgForStreamAsync(ConnectionInfo connectionInfo, string streamId, CancellationToken cancellationToken = default);
        Task<PlayerApi> GetUserAndServerInfoAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
        Task<List<Channels>> GetVodStreamsAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
        Task<PlayerApi> GetXmltvAsync(ConnectionInfo connectionInfo, CancellationToken cancellationToken = default);
    }
}
