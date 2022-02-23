using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    class MessageCompletion
    {
        public CancellationTokenRegistration? CancellationTokenRegistration { get; set; }
        public TaskCompletionSource? TaskCompletionSource { get; }
        public IRpcMessage? RpcMessage { get; }
        public IMethod? Method { get; }

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
    }
}