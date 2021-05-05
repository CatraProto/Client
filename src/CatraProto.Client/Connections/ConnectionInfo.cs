using System.Net;

namespace CatraProto.Client.Connections
{
    class ConnectionInfo
    {
        public IPAddress IPAddress { get; init; }
        public int Port { get; init; }

        public override string ToString()
        {
            return IPAddress + ":" + Port;
        }
    }
}