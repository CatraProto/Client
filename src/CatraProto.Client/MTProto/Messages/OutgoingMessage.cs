using System.Threading;
using CatraProto.Client.MTProto.Messages.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Messages
{
    class OutgoingMessage : IMessage
    {
        public MessageOptions MessageOptions { get; set; } = new MessageOptions
        {
            AwaiterType = AwaiterType.RpcResponse
        };

        public CancellationToken CancellationToken { get; set; }
        public bool IsEncrypted { get; set; }
        public IObject Body { get; set; }
    }
}