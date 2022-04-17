using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    internal interface IProtocolWriter
    {
        public Task<bool> SendAsync(byte[] message, CancellationToken token = default);
    }
}