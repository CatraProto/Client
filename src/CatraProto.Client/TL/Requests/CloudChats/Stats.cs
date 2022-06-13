/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;


namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Stats
    {

        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal Stats(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;

        }

        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>> InternalGetBroadcastStatsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool dark = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetBroadcastStats()
            {
                Channel = channel,
                Dark = dark,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>> LoadAsyncGraphAsync(string token, long? x = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.LoadAsyncGraph()
            {
                Token = token,
                X = x,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>> InternalGetMegagroupStatsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool dark = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMegagroupStats()
            {
                Channel = channel,
                Dark = dark,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetMessagePublicForwardsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int msgId, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessagePublicForwards()
            {
                Channel = channel,
                MsgId = msgId,
                OffsetRate = offsetRate,
                OffsetPeer = offsetPeer,
                OffsetId = offsetId,
                Limit = limit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>> InternalGetMessageStatsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int msgId, bool dark = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessageStats()
            {
                Channel = channel,
                MsgId = msgId,
                Dark = dark,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>> GetBroadcastStatsAsync(long channel, bool dark = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.BroadcastStatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetBroadcastStats()
            {
                Channel = channelResolved,
                Dark = dark,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>> GetMegagroupStatsAsync(long channel, bool dark = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MegagroupStatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMegagroupStats()
            {
                Channel = channelResolved,
                Dark = dark,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessagePublicForwardsAsync(long channel, int msgId, int offsetRate, CatraProto.Client.MTProto.PeerId offsetPeer, int offsetId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var offsetPeerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(offsetPeer);
            if (offsetPeerToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(offsetPeer.Id, offsetPeer.Type));
            }
            var offsetPeerResolved = offsetPeerToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessagePublicForwards()
            {
                Channel = channelResolved,
                MsgId = msgId,
                OffsetRate = offsetRate,
                OffsetPeer = offsetPeerResolved,
                OffsetId = offsetId,
                Limit = limit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>> GetMessageStatsAsync(long channel, int msgId, bool dark = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stats.MessageStatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stats.GetMessageStats()
            {
                Channel = channelResolved,
                MsgId = msgId,
                Dark = dark,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

    }
}