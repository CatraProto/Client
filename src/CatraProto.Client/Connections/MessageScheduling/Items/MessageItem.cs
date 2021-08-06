using System.Threading;
using CatraProto.Client.MTProto.Messages;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    class MessageItem
    {
        public MessageStatus MessageStatus { get; }
        public MessageSendingOptions MessageSendingOptions { get; }
        public CancellationToken CancellationToken { get; }
        public IObject Body { get; }

        public MessageItem(IObject body, MessageSendingOptions messageSendingOptions, MessageStatus messageStatus, CancellationToken cancellationToken)
        {
            MessageSendingOptions = messageSendingOptions;
            MessageStatus = messageStatus;
            Body = body;
            CancellationToken = cancellationToken;
        }
    }
}