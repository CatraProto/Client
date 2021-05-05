using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    interface IProtocolWriter
    {
        public Task SendMessage(byte[] message, CancellationToken token = default);
    }
}