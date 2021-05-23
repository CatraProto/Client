using System.Net;

namespace CatraProto.Client.Connections
{
    class ConnectionInfo
    {
        public IPAddress IpAddress { get; init; }
        public int Port { get; init; }
        public int DcId { get; init; }
        
        public override string ToString()
        {
            return IpAddress + ":" + Port + $" (DC{DcId})";
        }
    }
}