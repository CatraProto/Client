using System.Net;
using CatraProto.Client.Connections;

namespace CatraProto.Client.MTProto.Settings
{
    public class ConnectionSettings
    {
        public ConnectionInfo DefaultDatacenter { get; } = new ConnectionInfo(IPAddress.Parse( /*"149.154.167.92"*/"149.154.167.50"), 443, 2);
        public bool Ipv6Allowed { get; }

        public ConnectionSettings(bool ipv6Allowed = false, ConnectionInfo? defaultDatacenter = null)
        {
            if (defaultDatacenter is not null)
            {
                DefaultDatacenter = defaultDatacenter;
            }

            Ipv6Allowed = false;
        }
    }
}