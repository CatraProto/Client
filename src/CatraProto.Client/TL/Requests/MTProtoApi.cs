using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.TL.Requests
{
    public partial class MTProtoApi
    {
        private readonly MessagesQueue _messagesQueue;

        internal MTProtoApi(MessagesQueue messagesQueue)
        {
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<ResPQBase>> ReqPqAsync(BigInteger nonce, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ResPQBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: false);
            var methodBody = new ReqPq
            {
                Nonce = nonce
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ResPQBase>> ReqPqMultiAsync(BigInteger nonce, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ResPQBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: false);
            var methodBody = new ReqPqMulti
            {
                Nonce = nonce
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ServerDHParamsBase>> ReqDHParamsAsync(BigInteger nonce, BigInteger serverNonce, byte[] p, byte[] q,
            long publicKeyFingerprint, byte[] encryptedData, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ServerDHParamsBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: false);
            var methodBody = new ReqDHParams
            {
                Nonce = nonce,
                ServerNonce = serverNonce,
                P = p,
                Q = q,
                PublicKeyFingerprint = publicKeyFingerprint,
                EncryptedData = encryptedData
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SetClientDHParamsAnswerBase>> SetClientDHParamsAsync(BigInteger nonce, BigInteger serverNonce,
            byte[] encryptedData, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SetClientDHParamsAnswerBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: false);
            var methodBody = new SetClientDHParams
            {
                Nonce = nonce,
                ServerNonce = serverNonce,
                EncryptedData = encryptedData
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcDropAnswerBase>> RpcDropAnswerAsync(long reqMsgId, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcDropAnswerBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new RpcDropAnswer
            {
                ReqMsgId = reqMsgId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<FutureSaltsBase>> GetFutureSaltsAsync(int num, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<FutureSaltsBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetFutureSalts
            {
                Num = num
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<PongBase>> PingAsync(long pingId, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PongBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new Ping
            {
                PingId = pingId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<PongBase>> PingDelayDisconnectAsync(long pingId, int disconnectDelay,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PongBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new PingDelayDisconnect
            {
                PingId = pingId,
                DisconnectDelay = disconnectDelay
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<DestroySessionResBase>> DestroySessionAsync(long sessionId, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<DestroySessionResBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DestroySession
            {
                SessionId = sessionId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<HttpWaitBase>> HttpWaitAsync(int maxDelay, int waitAfter, int maxWait,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<HttpWaitBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new HttpWait
            {
                MaxDelay = maxDelay,
                WaitAfter = waitAfter,
                MaxWait = maxWait
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}