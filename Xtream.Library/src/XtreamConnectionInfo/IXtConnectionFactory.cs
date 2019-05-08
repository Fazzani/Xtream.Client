using System;
using System.Collections.Generic;
using System.Text;

namespace Xtream.Client.XtreamConnectionInfo
{
    public interface IXtConnectionFactory
    {
        ConnectionInfo Create();
    }
}
