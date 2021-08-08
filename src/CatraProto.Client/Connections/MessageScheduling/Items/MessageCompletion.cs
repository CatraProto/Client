using System;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    class MessageCompletion
    {
        public TaskCompletionSource? TaskCompletionSource { get; }
        public IRpcMessage? RpcMessage { get; }
        public IMethod? Method { get; }
        private MessagesHandler? _messagesHandler;

        public MessageCompletion(TaskCompletionSource? taskCompletionSource, IRpcMessage? rpcMessage, IMethod? method)
        {
            if (rpcMessage is null && taskCompletionSource is not null)
            {
                throw new ArgumentNullException(nameof(taskCompletionSource));
            }

            Method = method;
            RpcMessage = rpcMessage;
            TaskCompletionSource = taskCompletionSource;
        }

        public void SetSent(long messageId)
        {
            _messagesHandler?.MessagesTrackers.MessageCompletionTracker.AddCompletion(messageId, this);
        }

        public void BindTo(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }
    }
}