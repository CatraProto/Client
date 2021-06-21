using System;
using System.Net;

namespace CatraProto.Client.Connections
{
    class ConnectionInfo
    {
        public ConnectionInfo(IPAddress ipAddress, int port, int dcId)
        {
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Port = port;
            DcId = dcId;
        }

        public IPAddress IpAddress { get; init; }
        public int Port { get; init; }
        public int DcId { get; init; }

        public override string ToString()
        {
            return IpAddress + ":" + Port + $" (DC{DcId})";
        }
    }
}