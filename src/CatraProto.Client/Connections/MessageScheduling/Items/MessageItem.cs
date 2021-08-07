using System.Threading;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.Connections.MessageScheduling.Trackers;
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
        private MessagesHandler? _messagesHandler;
        private readonly object _mutex = new object();
        public MessageItem(IObject body, MessageSendingOptions messageSendingOptions, MessageStatus messageStatus, CancellationToken cancellationToken)
        {
            Body = body;
            MessageSendingOptions = messageSendingOptions;
            MessageStatus = messageStatus;
            CancellationToken = cancellationToken;
        }

        public void SetSent(long messageId)
        {
            lock (_mutex)
            {
                MessageStatus.SetSent(messageId);
                _messagesHandler?.MessagesTrackers.MessagesAckTracker.TrackMessage(this);   
            }
        }
        
        public void Resend()
        {
            lock (_mutex)
            {
                MessageStatus.Reset();
                MessageStatus.MessageState = MessageState.NotYetSent;
                _messagesHandler?.MessagesQueue.EnqueueMessage(this);
            }
        }

        public void Reset()
        {
            lock (_mutex)
            {
                MessageStatus.Reset();
                MessageStatus.MessageState = MessageState.NotYetSent;   
            }
        }
        
        public void BindTo(MessagesHandler messagesHandler)
        {
            lock (_mutex)
            {
                _messagesHandler = messagesHandler;
                MessageStatus.BindTo(messagesHandler);
            }

        }
    }
}