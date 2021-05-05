using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    interface IProtocolReader
    {
        public Task<byte[]> ReadIncomingMessage(CancellationToken token = default);
    }
}