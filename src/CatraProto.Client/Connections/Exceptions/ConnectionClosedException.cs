using System.IO;

namespace CatraProto.Client.Connections.Exceptions
{
    public class ConnectionClosedException : IOException
    {
        public override string Message { get; } = "Connection closed";
    }
}