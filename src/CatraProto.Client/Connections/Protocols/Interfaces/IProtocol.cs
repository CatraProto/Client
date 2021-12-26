using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    interface IProtocol
    {
        public ConnectionInfo ConnectionInfo { get; }
        public IProtocolWriter Writer { get; }
        public IProtocolReader Reader { get; }

        public Task ConnectAsync(CancellationToken token = default);
        public Task CloseAsync();
    }
}