using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.MessageScheduling.Items
{
    internal class MessageCompletion
    {
        public CancellationTokenRegistration? CancellationTokenRegistration { get; set; }
        public TaskCompletionSource? TaskCompletionSource { get; }
        public IRpcResponse? RpcResponse { get; }
        public IMethod? Method { get; }

        public MessageCompletion(TaskCompletionSource? taskCompletionSource, IRpcResponse? rpcMessage, IMethod? method)
        {
            if (rpcMessage is null && taskCompletionSource is not null)
            {
                throw new ArgumentNullException(nameof(taskCompletionSource));
            }

            Method = method;
            RpcResponse = rpcMessage;
            TaskCompletionSource = taskCompletionSource;
        }
    }
}