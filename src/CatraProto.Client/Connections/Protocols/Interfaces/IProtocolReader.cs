using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    internal interface IProtocolReader
    {
        public Task<byte[]> ReadMessageAsync(CancellationToken token = default);
    }
}