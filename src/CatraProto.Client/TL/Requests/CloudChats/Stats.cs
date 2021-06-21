using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.TL.Schemas.CloudChats.Stats;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Stats
    {
        private MessagesHandler _messagesHandler;

        internal Stats(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<BroadcastStatsBase>> GetBroadcastStats(InputChannelBase channel, bool dark = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<BroadcastStatsBase>();
            var methodBody = new GetBroadcastStats
            {
                Channel = channel,
                Dark = dark,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<StatsGraphBase>> LoadAsyncGraph(string token, long? x = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<StatsGraphBase>();
            var methodBody = new LoadAsyncGraph
            {
                Token = token,
                X = x,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<MegagroupStatsBase>> GetMegagroupStats(InputChannelBase channel, bool dark = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<MegagroupStatsBase>();
            var methodBody = new GetMegagroupStats
            {
                Channel = channel,
                Dark = dark,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<MessagesBase>> GetMessagePublicForwards(InputChannelBase channel, int msgId, int offsetRate, InputPeerBase offsetPeer, int offsetId, int limit, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<MessagesBase>();
            var methodBody = new GetMessagePublicForwards
            {
                Channel = channel,
                MsgId = msgId,
                OffsetRate = offsetRate,
                OffsetPeer = offsetPeer,
                OffsetId = offsetId,
                Limit = limit,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<MessageStatsBase>> GetMessageStats(InputChannelBase channel, int msgId, bool dark = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<MessageStatsBase>();
            var methodBody = new GetMessageStats
            {
                Channel = channel,
                MsgId = msgId,
                Dark = dark,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }
    }
}