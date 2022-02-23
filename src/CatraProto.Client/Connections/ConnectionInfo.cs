using System;
using System.Net;

namespace CatraProto.Client.Connections
{
    public class ConnectionInfo
    {
        public ConnectionProtocol ConnectionProtocol { get; }
        public IPAddress IpAddress { get; }
        public int Port { get; }
        public int DcId { get; }
        public bool Main { get; set; }

        public ConnectionInfo(ConnectionProtocol connectionProtocol, IPAddress ipAddress, int port, int dcId)
        {
            ConnectionProtocol = connectionProtocol;
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Port = port;
            DcId = dcId;
        }

        public override string ToString()
        {
            return $"DC{DcId} ({IpAddress}:{Port}, Main: {Main})";
        }
    }
}