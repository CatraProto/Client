using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.CatraErrors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Channels;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using ChannelParticipantBase = CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase;
using ChatFullBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase;
using DeleteHistory = CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory;
using DeleteMessages = CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages;
using GetMessages = CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages;
using ReadHistory = CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory;
using ReadMessageContents = CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents;
using ReportSpam = CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam;

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

        public async Task<RpcMessage<bool>> ReadHistoryAsync(InputChannelBase channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReadHistory
            {
                Channel = channel,
                MaxId = maxId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AffectedMessagesBase>> DeleteMessagesAsync(InputChannelBase channel, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AffectedMessagesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteMessages
            {
                Channel = channel,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReportSpamAsync(InputChannelBase channel, InputPeerBase participant, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReportSpam
            {
                Channel = channel,
                Participant = participant,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<MessagesBase>> GetMessagesAsync(InputChannelBase channel, IList<InputMessageBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<MessagesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetMessages
            {
                Channel = channel,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChannelParticipantsBase>> GetParticipantsAsync(InputChannelBase channel, ChannelParticipantsFilterBase filter, int offset, int limit, long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChannelParticipantsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetParticipants
            {
                Channel = channel,
                Filter = filter,
                Offset = offset,
                Limit = limit,
                Hash = hash
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChannelParticipantBase>> GetParticipantAsync(InputChannelBase channel, InputPeerBase participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChannelParticipantBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetParticipant
            {
                Channel = channel,
                Participant = participant
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetChannelsAsync(IList<InputChannelBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetChannels
            {
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatFullBase>> GetFullChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatFullBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetFullChannel
            {
                Channel = channel
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> CreateChannelAsync(string title, string about, bool broadcast = true, bool megagroup = true, bool forImport = true, InputGeoPointBase? geoPoint = null, string? address = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new CreateChannel
            {
                Title = title,
                About = about,
                Broadcast = broadcast,
                Megagroup = megagroup,
                ForImport = forImport,
                GeoPoint = geoPoint,
                Address = address
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditAdminAsync(InputChannelBase channel, InputUserBase userId, ChatAdminRightsBase adminRights, string rank, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditAdmin
            {
                Channel = channel,
                UserId = userId,
                AdminRights = adminRights,
                Rank = rank
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditTitleAsync(InputChannelBase channel, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditTitle
            {
                Channel = channel,
                Title = title
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditPhotoAsync(InputChannelBase channel, InputChatPhotoBase photo, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditPhoto
            {
                Channel = channel,
                Photo = photo
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> CheckUsernameAsync(InputChannelBase channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new CheckUsername
            {
                Channel = channel,
                Username = username
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> UpdateUsernameAsync(InputChannelBase channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new UpdateUsername
            {
                Channel = channel,
                Username = username
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> JoinChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new JoinChannel
            {
                Channel = channel
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> LeaveChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new LeaveChannel
            {
                Channel = channel
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> InviteToChannelAsync(InputChannelBase channel, IList<InputUserBase> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new InviteToChannel
            {
                Channel = channel,
                Users = users
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DeleteChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteChannel
            {
                Channel = channel
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ExportedMessageLinkBase>> ExportMessageLinkAsync(InputChannelBase channel, int id, bool grouped = true, bool thread = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ExportedMessageLinkBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ExportMessageLink
            {
                Channel = channel,
                Id = id,
                Grouped = grouped,
                Thread = thread
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ToggleSignaturesAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ToggleSignatures
            {
                Channel = channel,
                Enabled = enabled
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetAdminedPublicChannelsAsync(bool byLocation = true, bool checkLimit = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetAdminedPublicChannels
            {
                ByLocation = byLocation,
                CheckLimit = checkLimit
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditBannedAsync(InputChannelBase channel, InputPeerBase participant, ChatBannedRightsBase bannedRights, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditBanned
            {
                Channel = channel,
                Participant = participant,
                BannedRights = bannedRights
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AdminLogResultsBase>> GetAdminLogAsync(InputChannelBase channel, string q, long maxId, long minId, int limit, ChannelAdminLogEventsFilterBase? eventsFilter = null, IList<InputUserBase>? admins = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AdminLogResultsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetAdminLog
            {
                Channel = channel,
                Q = q,
                MaxId = maxId,
                MinId = minId,
                Limit = limit,
                EventsFilter = eventsFilter,
                Admins = admins
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetStickersAsync(InputChannelBase channel, InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SetStickers
            {
                Channel = channel,
                Stickerset = stickerset
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReadMessageContentsAsync(InputChannelBase channel, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReadMessageContents
            {
                Channel = channel,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> DeleteHistoryAsync(InputChannelBase channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteHistory
            {
                Channel = channel,
                MaxId = maxId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> TogglePreHistoryHiddenAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new TogglePreHistoryHidden
            {
                Channel = channel,
                Enabled = enabled
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetLeftChannelsAsync(int offset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetLeftChannels
            {
                Offset = offset
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetGroupsForDiscussionAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetGroupsForDiscussion();

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetDiscussionGroupAsync(InputChannelBase broadcast, InputChannelBase group, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SetDiscussionGroup
            {
                Broadcast = broadcast,
                Group = group
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditCreatorAsync(InputChannelBase channel, InputUserBase userId, InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditCreator
            {
                Channel = channel,
                UserId = userId,
                Password = password
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> EditLocationAsync(InputChannelBase channel, InputGeoPointBase geoPoint, string address, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditLocation
            {
                Channel = channel,
                GeoPoint = geoPoint,
                Address = address
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ToggleSlowModeAsync(InputChannelBase channel, int seconds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ToggleSlowMode
            {
                Channel = channel,
                Seconds = seconds
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<InactiveChatsBase>> GetInactiveChannelsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<InactiveChatsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetInactiveChannels();

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ConvertToGigagroupAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ConvertToGigagroup
            {
                Channel = channel
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ViewSponsoredMessageAsync(InputChannelBase channel, byte[] randomId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ViewSponsoredMessage
            {
                Channel = channel,
                RandomId = randomId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SponsoredMessagesBase>> GetSponsoredMessagesAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SponsoredMessagesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetSponsoredMessages
            {
                Channel = channel
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SendAsPeersBase>> GetSendAsAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SendAsPeersBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetSendAs
            {
                Peer = peer
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AffectedHistoryBase>> DeleteParticipantHistoryAsync(InputChannelBase channel, InputPeerBase participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AffectedHistoryBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteParticipantHistory
            {
                Channel = channel,
                Participant = participant
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReadHistoryAsync(long channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReadHistory
            {
                Channel = channelResolved,
                MaxId = maxId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AffectedMessagesBase>> DeleteMessagesAsync(long channel, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<AffectedMessagesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<AffectedMessagesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteMessages
            {
                Channel = channelResolved,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReportSpamAsync(long channel, PeerId participant, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(participant.Id, participant.Type));
            }

            var participantResolved = participantToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReportSpam
            {
                Channel = channelResolved,
                Participant = participantResolved,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<MessagesBase>> GetMessagesAsync(long channel, IList<InputMessageBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<MessagesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<MessagesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetMessages
            {
                Channel = channelResolved,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChannelParticipantsBase>> GetParticipantsAsync(long channel, ChannelParticipantsFilterBase filter, int offset, int limit, long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<ChannelParticipantsBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<ChannelParticipantsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetParticipants
            {
                Channel = channelResolved,
                Filter = filter,
                Offset = offset,
                Limit = limit,
                Hash = hash
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChannelParticipantBase>> GetParticipantAsync(long channel, PeerId participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<ChannelParticipantBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcMessage<ChannelParticipantBase>.FromError(new CantResolvePeer(participant.Id, participant.Type));
            }

            var participantResolved = participantToResolve;
            var rpcResponse = new RpcMessage<ChannelParticipantBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetParticipant
            {
                Channel = channelResolved,
                Participant = participantResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetChannelsAsync(IList<long> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var idResolved = new List<InputChannelBase>();
            for (var i = 0; i < id.Count; i++)
            {
                var idToResolveOut = id[i];
                var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(idToResolveOut);
                if (idToResolve is null)
                {
                    return RpcMessage<ChatsBase>.FromError(new CantResolvePeer(idToResolveOut, PeerType.Channel));
                }

                idResolved.Add(idToResolve);
            }

            var rpcResponse = new RpcMessage<ChatsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetChannels
            {
                Id = idResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatFullBase>> GetFullChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<ChatFullBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<ChatFullBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetFullChannel
            {
                Channel = channelResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditAdminAsync(long channel, long userId, ChatAdminRightsBase adminRights, string rank, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
            if (userIdToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(userId, PeerType.User));
            }

            var userIdResolved = userIdToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditAdmin
            {
                Channel = channelResolved,
                UserId = userIdResolved,
                AdminRights = adminRights,
                Rank = rank
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditTitleAsync(long channel, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditTitle
            {
                Channel = channelResolved,
                Title = title
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditPhotoAsync(long channel, InputChatPhotoBase photo, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditPhoto
            {
                Channel = channelResolved,
                Photo = photo
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> CheckUsernameAsync(long channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new CheckUsername
            {
                Channel = channelResolved,
                Username = username
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> UpdateUsernameAsync(long channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new UpdateUsername
            {
                Channel = channelResolved,
                Username = username
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> JoinChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new JoinChannel
            {
                Channel = channelResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> LeaveChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new LeaveChannel
            {
                Channel = channelResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> InviteToChannelAsync(long channel, IList<long> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var usersResolved = new List<InputUserBase>();
            for (var i = 0; i < users.Count; i++)
            {
                var usersToResolveOut = users[i];
                var usersToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(usersToResolveOut);
                if (usersToResolve is null)
                {
                    return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(usersToResolveOut, PeerType.User));
                }

                usersResolved.Add(usersToResolve);
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new InviteToChannel
            {
                Channel = channelResolved,
                Users = usersResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DeleteChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteChannel
            {
                Channel = channelResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ExportedMessageLinkBase>> ExportMessageLinkAsync(long channel, int id, bool grouped = true, bool thread = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<ExportedMessageLinkBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<ExportedMessageLinkBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ExportMessageLink
            {
                Channel = channelResolved,
                Id = id,
                Grouped = grouped,
                Thread = thread
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ToggleSignaturesAsync(long channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ToggleSignatures
            {
                Channel = channelResolved,
                Enabled = enabled
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditBannedAsync(long channel, PeerId participant, ChatBannedRightsBase bannedRights, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(participant.Id, participant.Type));
            }

            var participantResolved = participantToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditBanned
            {
                Channel = channelResolved,
                Participant = participantResolved,
                BannedRights = bannedRights
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AdminLogResultsBase>> GetAdminLogAsync(long channel, string q, long maxId, long minId, int limit, ChannelAdminLogEventsFilterBase? eventsFilter = null, IList<long>? admins = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<AdminLogResultsBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var adminsResolved = new List<InputUserBase>();
            if (admins is not null)
            {
                for (var i = 0; i < admins.Count; i++)
                {
                    var adminsToResolveOut = admins[i];
                    var adminsToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(adminsToResolveOut);
                    if (adminsToResolve is null)
                    {
                        return RpcMessage<AdminLogResultsBase>.FromError(new CantResolvePeer(adminsToResolveOut, PeerType.User));
                    }

                    adminsResolved.Add(adminsToResolve);
                }
            }

            var rpcResponse = new RpcMessage<AdminLogResultsBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetAdminLog
            {
                Channel = channelResolved,
                Q = q,
                MaxId = maxId,
                MinId = minId,
                Limit = limit,
                EventsFilter = eventsFilter,
                Admins = adminsResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetStickersAsync(long channel, InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SetStickers
            {
                Channel = channelResolved,
                Stickerset = stickerset
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReadMessageContentsAsync(long channel, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ReadMessageContents
            {
                Channel = channelResolved,
                Id = id
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> DeleteHistoryAsync(long channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteHistory
            {
                Channel = channelResolved,
                MaxId = maxId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> TogglePreHistoryHiddenAsync(long channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new TogglePreHistoryHidden
            {
                Channel = channelResolved,
                Enabled = enabled
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetDiscussionGroupAsync(long broadcast, long group, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var broadcastToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(broadcast);
            if (broadcastToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(broadcast, PeerType.Channel));
            }

            var broadcastResolved = broadcastToResolve;
            var groupToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(group);
            if (groupToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(group, PeerType.Channel));
            }

            var groupResolved = groupToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SetDiscussionGroup
            {
                Broadcast = broadcastResolved,
                Group = groupResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditCreatorAsync(long channel, long userId, InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
            if (userIdToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(userId, PeerType.User));
            }

            var userIdResolved = userIdToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditCreator
            {
                Channel = channelResolved,
                UserId = userIdResolved,
                Password = password
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> EditLocationAsync(long channel, InputGeoPointBase geoPoint, string address, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new EditLocation
            {
                Channel = channelResolved,
                GeoPoint = geoPoint,
                Address = address
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ToggleSlowModeAsync(long channel, int seconds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ToggleSlowMode
            {
                Channel = channelResolved,
                Seconds = seconds
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ConvertToGigagroupAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<UpdatesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<UpdatesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ConvertToGigagroup
            {
                Channel = channelResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ViewSponsoredMessageAsync(long channel, byte[] randomId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<bool>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ViewSponsoredMessage
            {
                Channel = channelResolved,
                RandomId = randomId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SponsoredMessagesBase>> GetSponsoredMessagesAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<SponsoredMessagesBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var rpcResponse = new RpcMessage<SponsoredMessagesBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetSponsoredMessages
            {
                Channel = channelResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SendAsPeersBase>> GetSendAsAsync(PeerId peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
            if (peerToResolve is null)
            {
                return RpcMessage<SendAsPeersBase>.FromError(new CantResolvePeer(peer.Id, peer.Type));
            }

            var peerResolved = peerToResolve;
            var rpcResponse = new RpcMessage<SendAsPeersBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetSendAs
            {
                Peer = peerResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AffectedHistoryBase>> DeleteParticipantHistoryAsync(long channel, PeerId participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
            if (channelToResolve is null)
            {
                return RpcMessage<AffectedHistoryBase>.FromError(new CantResolvePeer(channel, PeerType.Channel));
            }

            var channelResolved = channelToResolve;
            var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
            if (participantToResolve is null)
            {
                return RpcMessage<AffectedHistoryBase>.FromError(new CantResolvePeer(participant.Id, participant.Type));
            }

            var participantResolved = participantToResolve;
            var rpcResponse = new RpcMessage<AffectedHistoryBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DeleteParticipantHistory
            {
                Channel = channelResolved,
                Participant = participantResolved
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}