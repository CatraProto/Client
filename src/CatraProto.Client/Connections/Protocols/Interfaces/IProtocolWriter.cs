using System.Threading;
using System.Threading.Tasks;
using MessageBase = CatraProto.Client.Connections.Messages.Interfaces.MessageBase;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
    interface IProtocolWriter
    {
        public Task SendMessage(byte[] message, CancellationToken token = default);
        public Task SendMessage(MessageBase message, CancellationToken token = default);
    }
}
