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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;


namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Channels
    {

        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal Channels(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;

        }

        internal async Task<RpcResponse<bool>> InternalReadHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory()
            {
                Channel = channel,
                MaxId = maxId,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> InternalDeleteMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages()
            {
                Channel = channel,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalReportSpamAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam()
            {
                Channel = channel,
                Participant = participant,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages()
            {
                Channel = channel,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>> InternalGetParticipantsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase filter, int offset, int limit, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipants()
            {
                Channel = channel,
                Filter = filter,
                Offset = offset,
                Limit = limit,
                Hash = hash,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>> InternalGetParticipantAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipant()
            {
                Channel = channel,
                Participant = participant,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> InternalGetChannelsAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetChannels()
            {
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> InternalGetFullChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetFullChannel()
            {
                Channel = channel,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateChannelAsync(string title, string about, bool broadcast = false, bool megagroup = false, bool forImport = false, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase? geoPoint = null, string? address = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.CreateChannel()
            {
                Title = title,
                About = about,
                Broadcast = broadcast,
                Megagroup = megagroup,
                ForImport = forImport,
                GeoPoint = geoPoint,
                Address = address,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditAdminAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights, string rank, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditAdmin()
            {
                Channel = channel,
                UserId = userId,
                AdminRights = adminRights,
                Rank = rank,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditTitleAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditTitle()
            {
                Channel = channel,
                Title = title,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditPhotoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditPhoto()
            {
                Channel = channel,
                Photo = photo,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalCheckUsernameAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string username, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.CheckUsername()
            {
                Channel = channel,
                Username = username,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalUpdateUsernameAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string username, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.UpdateUsername()
            {
                Channel = channel,
                Username = username,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalJoinChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.JoinChannel()
            {
                Channel = channel,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalLeaveChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.LeaveChannel()
            {
                Channel = channel,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalInviteToChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.InviteToChannel()
            {
                Channel = channel,
                Users = users,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalDeleteChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteChannel()
            {
                Channel = channel,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>> InternalExportMessageLinkAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int id, bool grouped = false, bool thread = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ExportMessageLink()
            {
                Channel = channel,
                Id = id,
                Grouped = grouped,
                Thread = thread,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalToggleSignaturesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSignatures()
            {
                Channel = channel,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetAdminedPublicChannelsAsync(bool byLocation = false, bool checkLimit = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminedPublicChannels()
            {
                ByLocation = byLocation,
                CheckLimit = checkLimit,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditBannedAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditBanned()
            {
                Channel = channel,
                Participant = participant,
                BannedRights = bannedRights,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>> InternalGetAdminLogAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string q, long maxId, long minId, int limit, CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase? eventsFilter = null, List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>? admins = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminLog()
            {
                Channel = channel,
                Q = q,
                MaxId = maxId,
                MinId = minId,
                Limit = limit,
                EventsFilter = eventsFilter,
                Admins = admins,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalSetStickersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetStickers()
            {
                Channel = channel,
                Stickerset = stickerset,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalReadMessageContentsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents()
            {
                Channel = channel,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalDeleteHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId, bool forEveryone = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory()
            {
                Channel = channel,
                MaxId = maxId,
                ForEveryone = forEveryone,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalTogglePreHistoryHiddenAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.TogglePreHistoryHidden()
            {
                Channel = channel,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetLeftChannelsAsync(int offset, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetLeftChannels()
            {
                Offset = offset,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetGroupsForDiscussionAsync(CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetGroupsForDiscussion()
            {
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalSetDiscussionGroupAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase broadcast, CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase group, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetDiscussionGroup()
            {
                Broadcast = broadcast,
                Group = group,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditCreatorAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditCreator()
            {
                Channel = channel,
                UserId = userId,
                Password = password,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalEditLocationAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string address, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditLocation()
            {
                Channel = channel,
                GeoPoint = geoPoint,
                Address = address,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalToggleSlowModeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int seconds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSlowMode()
            {
                Channel = channel,
                Seconds = seconds,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase>> GetInactiveChannelsAsync(CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetInactiveChannels()
            {
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalConvertToGigagroupAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ConvertToGigagroup()
            {
                Channel = channel,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<bool>> InternalViewSponsoredMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, byte[] randomId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ViewSponsoredMessage()
            {
                Channel = channel,
                RandomId = randomId,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessagesBase>> InternalGetSponsoredMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSponsoredMessages()
            {
                Channel = channel,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase>> InternalGetSendAsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSendAs()
            {
                Peer = peer,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> InternalDeleteParticipantHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteParticipantHistory()
            {
                Channel = channel,
                Participant = participant,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalToggleJoinToSendAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleJoinToSend()
            {
                Channel = channel,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalToggleJoinRequestAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleJoinRequest()
            {
                Channel = channel,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> ReadHistoryAsync(long channel, int maxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory()
            {
                Channel = channelResolved,
                MaxId = maxId,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> DeleteMessagesAsync(long channel, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages()
            {
                Channel = channelResolved,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> ReportSpamAsync(long channel, CatraProto.Client.MTProto.PeerId participant, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
            }
            var participantResolved = participantToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam()
            {
                Channel = channelResolved,
                Participant = participantResolved,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessagesAsync(long channel, List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages()
            {
                Channel = channelResolved,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>> GetParticipantsAsync(long channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase filter, int offset, int limit, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipants()
            {
                Channel = channelResolved,
                Filter = filter,
                Offset = offset,
                Limit = limit,
                Hash = hash,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>> GetParticipantAsync(long channel, CatraProto.Client.MTProto.PeerId participant, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
            }
            var participantResolved = participantToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipant()
            {
                Channel = channelResolved,
                Participant = participantResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> InternalGetChannelsAsync(List<long> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var idResolved = new List<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            for (var i = 0; i < id.Count; i++)
            {
                var idToResolveOut = id[i];
                var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(idToResolveOut);
                if (idToResolve is null)
                {
                    return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>.FromError(new PeerNotFoundError(idToResolveOut, CatraProto.Client.MTProto.PeerType.Channel));
                }
                idResolved.Add(idToResolve);
            }
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetChannels()
            {
                Id = idResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> InternalGetFullChannelAsync(long channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetFullChannel()
            {
                Channel = channelResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditAdminAsync(long channel, long userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights, string rank, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
            if (userIdToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
            }
            var userIdResolved = userIdToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditAdmin()
            {
                Channel = channelResolved,
                UserId = userIdResolved,
                AdminRights = adminRights,
                Rank = rank,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditTitleAsync(long channel, string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditTitle()
            {
                Channel = channelResolved,
                Title = title,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditPhotoAsync(long channel, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditPhoto()
            {
                Channel = channelResolved,
                Photo = photo,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> CheckUsernameAsync(long channel, string username, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.CheckUsername()
            {
                Channel = channelResolved,
                Username = username,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> UpdateUsernameAsync(long channel, string username, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.UpdateUsername()
            {
                Channel = channelResolved,
                Username = username,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> JoinChannelAsync(long channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.JoinChannel()
            {
                Channel = channelResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> LeaveChannelAsync(long channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.LeaveChannel()
            {
                Channel = channelResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InviteToChannelAsync(long channel, List<long> users, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var usersResolved = new List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            for (var i = 0; i < users.Count; i++)
            {
                var usersToResolveOut = users[i];
                var usersToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(usersToResolveOut);
                if (usersToResolve is null)
                {
                    return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(usersToResolveOut, CatraProto.Client.MTProto.PeerType.User));
                }
                usersResolved.Add(usersToResolve);
            }
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.InviteToChannel()
            {
                Channel = channelResolved,
                Users = usersResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteChannelAsync(long channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteChannel()
            {
                Channel = channelResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>> ExportMessageLinkAsync(long channel, int id, bool grouped = false, bool thread = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ExportMessageLink()
            {
                Channel = channelResolved,
                Id = id,
                Grouped = grouped,
                Thread = thread,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleSignaturesAsync(long channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSignatures()
            {
                Channel = channelResolved,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditBannedAsync(long channel, CatraProto.Client.MTProto.PeerId participant, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
            }
            var participantResolved = participantToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditBanned()
            {
                Channel = channelResolved,
                Participant = participantResolved,
                BannedRights = bannedRights,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>> GetAdminLogAsync(long channel, string q, long maxId, long minId, int limit, CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase? eventsFilter = null, List<long>? admins = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var adminsResolved = new List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (admins is not null)
            {
                for (var i = 0; i < admins.Count; i++)
                {
                    var adminsToResolveOut = admins[i];
                    var adminsToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(adminsToResolveOut);
                    if (adminsToResolve is null)
                    {
                        return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>.FromError(new PeerNotFoundError(adminsToResolveOut, CatraProto.Client.MTProto.PeerType.User));
                    }
                    adminsResolved.Add(adminsToResolve);
                }
            }
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminLog()
            {
                Channel = channelResolved,
                Q = q,
                MaxId = maxId,
                MinId = minId,
                Limit = limit,
                EventsFilter = eventsFilter,
                Admins = adminsResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> SetStickersAsync(long channel, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetStickers()
            {
                Channel = channelResolved,
                Stickerset = stickerset,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> ReadMessageContentsAsync(long channel, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents()
            {
                Channel = channelResolved,
                Id = id,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteHistoryAsync(long channel, int maxId, bool forEveryone = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory()
            {
                Channel = channelResolved,
                MaxId = maxId,
                ForEveryone = forEveryone,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> TogglePreHistoryHiddenAsync(long channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.TogglePreHistoryHidden()
            {
                Channel = channelResolved,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> SetDiscussionGroupAsync(long broadcast, long group, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var broadcastToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(broadcast);
            if (broadcastToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(broadcast, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var broadcastResolved = broadcastToResolve;
            var groupToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(group);
            if (groupToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(group, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var groupResolved = groupToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetDiscussionGroup()
            {
                Broadcast = broadcastResolved,
                Group = groupResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditCreatorAsync(long channel, long userId, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
            if (userIdToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
            }
            var userIdResolved = userIdToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditCreator()
            {
                Channel = channelResolved,
                UserId = userIdResolved,
                Password = password,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> EditLocationAsync(long channel, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string address, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditLocation()
            {
                Channel = channelResolved,
                GeoPoint = geoPoint,
                Address = address,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleSlowModeAsync(long channel, int seconds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSlowMode()
            {
                Channel = channelResolved,
                Seconds = seconds,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ConvertToGigagroupAsync(long channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ConvertToGigagroup()
            {
                Channel = channelResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> ViewSponsoredMessageAsync(long channel, byte[] randomId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ViewSponsoredMessage()
            {
                Channel = channelResolved,
                RandomId = randomId,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessagesBase>> GetSponsoredMessagesAsync(long channel, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessagesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SponsoredMessagesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSponsoredMessages()
            {
                Channel = channelResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase>> GetSendAsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
            if (peerToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
            }
            var peerResolved = peerToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetSendAs()
            {
                Peer = peerResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> DeleteParticipantHistoryAsync(long channel, CatraProto.Client.MTProto.PeerId participant, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
            }
            var participantResolved = participantToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteParticipantHistory()
            {
                Channel = channelResolved,
                Participant = participantResolved,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleJoinToSendAsync(long channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleJoinToSend()
            {
                Channel = channelResolved,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleJoinRequestAsync(long channel, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(channel, CatraProto.Client.MTProto.PeerType.Channel));
            }
            var channelResolved = channelToResolve;
            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleJoinRequest()
            {
                Channel = channelResolved,
                Enabled = enabled,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

    }
}