using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    interface IProtocol
    {
        public ConnectionInfo ConnectionInfo { get; }
        public bool IsConnected { get; }
        public IProtocolWriter Writer { get; }
        public IProtocolReader Reader { get; }
        
        public Task Connect(CancellationToken token = default);
        public Task Close();
    }
}
