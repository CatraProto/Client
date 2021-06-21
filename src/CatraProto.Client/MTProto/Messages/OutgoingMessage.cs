using System.Threading;
using CatraProto.Client.MTProto.Messages.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Messages
{
    class OutgoingMessage : IMessage
    {
        public MessageOptions MessageOptions { get; set; } = new MessageOptions
        {
            ExpectsResponse = true
        };
        
        public bool IsEncrypted { get; set; }
        public IObject Body { get; set; }
        public CancellationToken CancellationToken { get; set; }
    }
}