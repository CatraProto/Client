using System.Net;
using CatraProto.Client.Connections;

namespace CatraProto.Client.MTProto.Settings
{
    public class ConnectionSettings
    {
        public ConnectionInfo DefaultDatacenter { get; }
        public int PfsKeyDuration { get; }
        public int ConnectionTimeout { get; }
        public bool Ipv6Allowed { get; }

        public ConnectionSettings(ConnectionInfo defaultDatacenter, int pfsKeyDuration = 1500, int connectionTimeout = 60, bool ipv6Allowed = false)
        {
            DefaultDatacenter = defaultDatacenter;
            PfsKeyDuration = pfsKeyDuration;
            ConnectionTimeout = connectionTimeout;
            Ipv6Allowed = ipv6Allowed;
        }
    }
}