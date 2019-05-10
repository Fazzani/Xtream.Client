using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xtream.Client
{
    public interface IXtreamReader: IDisposable
    {
        Task<T> GetFromApi<T>(ConnectionInfo connectionInfo, XtreamApiEnum xtreamApiEnum, CancellationToken cancellationToken, params string[] extraParams);
    }
}