using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
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
	    internal Channels(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<bool>> ReadHistoryAsync(InputChannelBase channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ReadHistory
{
Channel = channel,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedMessagesBase>> DeleteMessagesAsync(InputChannelBase channel, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedMessagesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new DeleteMessages
			{
Channel = channel,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedHistoryBase>> DeleteUserHistoryAsync(InputChannelBase channel, InputUserBase userId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedHistoryBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new DeleteUserHistory
			{
Channel = channel,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReportSpamAsync(InputChannelBase channel, InputUserBase userId, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ReportSpam
{
Channel = channel,
UserId = userId,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetMessagesAsync(InputChannelBase channel, IList<InputMessageBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetMessages
			{
Channel = channel,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChannelParticipantsBase>> GetParticipantsAsync(InputChannelBase channel, ChannelParticipantsFilterBase filter, int offset, int limit, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChannelParticipantsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetParticipants
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

	    public async Task<RpcMessage<ChannelParticipantBase>> GetParticipantAsync(InputChannelBase channel, InputUserBase userId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChannelParticipantBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetParticipant
			{
Channel = channel,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetChannelsAsync(IList<InputChannelBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetChannels
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatFullBase>> GetFullChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatFullBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetFullChannel
			{
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> CreateChannelAsync(string title, string about, bool broadcast = true, bool megagroup = true, bool forImport = true, InputGeoPointBase? geoPoint = null, string? address = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new CreateChannel
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

	    public async Task<RpcMessage<UpdatesBase>> EditAdminAsync(InputChannelBase channel, InputUserBase userId, ChatAdminRightsBase adminRights, string rank, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new EditAdmin
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

	    public async Task<RpcMessage<UpdatesBase>> EditTitleAsync(InputChannelBase channel, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new EditTitle
			{
Channel = channel,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditPhotoAsync(InputChannelBase channel, InputChatPhotoBase photo, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new EditPhoto
			{
Channel = channel,
Photo = photo,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> CheckUsernameAsync(InputChannelBase channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new CheckUsername
{
Channel = channel,
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdateUsernameAsync(InputChannelBase channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new UpdateUsername
{
Channel = channel,
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> JoinChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new JoinChannel
			{
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> LeaveChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new LeaveChannel
			{
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> InviteToChannelAsync(InputChannelBase channel, IList<InputUserBase> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new InviteToChannel
			{
Channel = channel,
Users = users,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> DeleteChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new DeleteChannel
			{
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ExportedMessageLinkBase>> ExportMessageLinkAsync(InputChannelBase channel, int id, bool grouped = true, bool thread = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ExportedMessageLinkBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new ExportMessageLink
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

	    public async Task<RpcMessage<UpdatesBase>> ToggleSignaturesAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new ToggleSignatures
			{
Channel = channel,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetAdminedPublicChannelsAsync(bool byLocation = true, bool checkLimit = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAdminedPublicChannels
			{
ByLocation = byLocation,
CheckLimit = checkLimit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditBannedAsync(InputChannelBase channel, InputUserBase userId, ChatBannedRightsBase bannedRights, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new EditBanned
			{
Channel = channel,
UserId = userId,
BannedRights = bannedRights,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AdminLogResultsBase>> GetAdminLogAsync(InputChannelBase channel, string q, long maxId, long minId, int limit, ChannelAdminLogEventsFilterBase? eventsFilter = null, IList<InputUserBase>? admins = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AdminLogResultsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAdminLog
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

	    public async Task<RpcMessage<bool>> SetStickersAsync(InputChannelBase channel, InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SetStickers
{
Channel = channel,
Stickerset = stickerset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReadMessageContentsAsync(InputChannelBase channel, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ReadMessageContents
{
Channel = channel,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> DeleteHistoryAsync(InputChannelBase channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new DeleteHistory
{
Channel = channel,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> TogglePreHistoryHiddenAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new TogglePreHistoryHidden
			{
Channel = channel,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetLeftChannelsAsync(int offset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetLeftChannels
			{
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetGroupsForDiscussionAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetGroupsForDiscussion
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetDiscussionGroupAsync(InputChannelBase broadcast, InputChannelBase group, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SetDiscussionGroup
{
Broadcast = broadcast,
Group = group,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditCreatorAsync(InputChannelBase channel, InputUserBase userId, InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new EditCreator
			{
Channel = channel,
UserId = userId,
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> EditLocationAsync(InputChannelBase channel, InputGeoPointBase geoPoint, string address, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new EditLocation
{
Channel = channel,
GeoPoint = geoPoint,
Address = address,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> ToggleSlowModeAsync(InputChannelBase channel, int seconds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new ToggleSlowMode
			{
Channel = channel,
Seconds = seconds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<InactiveChatsBase>> GetInactiveChannelsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<InactiveChatsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetInactiveChannels
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}