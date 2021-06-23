using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;

namespace CatraProto.Client.Connections
{
    class MessageContainer
    {
        public OutgoingMessage OutgoingMessage { get; set; }
        public CancellationTokenRegistration CancellationTokenRegistration { get; set; }
        public TaskCompletionSource CompletionSource { get; set; }
        public IRpcMessage RpcContainer { get; set; }
    }
}