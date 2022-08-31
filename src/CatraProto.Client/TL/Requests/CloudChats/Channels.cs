#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
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

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Channels
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Channels(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    internal async Task<RpcResponse<bool>> InternalReadHistoryAsync(InputChannelBase channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReadHistory(){
Channel = channel,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<AffectedMessagesBase>> InternalDeleteMessagesAsync(InputChannelBase channel, List<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AffectedMessagesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteMessages(){
Channel = channel,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReportSpamAsync(InputChannelBase channel, InputPeerBase participant, List<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReportSpam(){
Channel = channel,
Participant = participant,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<MessagesBase>> InternalGetMessagesAsync(InputChannelBase channel, List<InputMessageBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<MessagesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetMessages(){
Channel = channel,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<ChannelParticipantsBase>> InternalGetParticipantsAsync(InputChannelBase channel, ChannelParticipantsFilterBase filter, int offset, int limit, long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChannelParticipantsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetParticipants(){
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
internal async Task<RpcResponse<ChannelParticipantBase>> InternalGetParticipantAsync(InputChannelBase channel, InputPeerBase participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChannelParticipantBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetParticipant(){
Channel = channel,
Participant = participant,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<ChatsBase>> InternalGetChannelsAsync(List<InputChannelBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChatsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetChannels(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<ChatFullBase>> InternalGetFullChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChatFullBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetFullChannel(){
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> CreateChannelAsync(string title, string about, bool broadcast = false, bool megagroup = false, bool forImport = false, InputGeoPointBase? geoPoint = null, string? address = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CreateChannel(){
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
internal async Task<RpcResponse<UpdatesBase>> InternalEditAdminAsync(InputChannelBase channel, InputUserBase userId, ChatAdminRightsBase adminRights, string rank, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditAdmin(){
Channel = channel,
UserId = userId,
AdminRights = adminRights,
Rank = rank,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalEditTitleAsync(InputChannelBase channel, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditTitle(){
Channel = channel,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalEditPhotoAsync(InputChannelBase channel, InputChatPhotoBase photo, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditPhoto(){
Channel = channel,
Photo = photo,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalCheckUsernameAsync(InputChannelBase channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CheckUsername(){
Channel = channel,
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalUpdateUsernameAsync(InputChannelBase channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateUsername(){
Channel = channel,
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalJoinChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new JoinChannel(){
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalLeaveChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new LeaveChannel(){
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalInviteToChannelAsync(InputChannelBase channel, List<InputUserBase> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new InviteToChannel(){
Channel = channel,
Users = users,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalDeleteChannelAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteChannel(){
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<ExportedMessageLinkBase>> InternalExportMessageLinkAsync(InputChannelBase channel, int id, bool grouped = false, bool thread = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ExportedMessageLinkBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ExportMessageLink(){
Channel = channel,
Id = id,
Grouped = grouped,
Thread = thread,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalToggleSignaturesAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleSignatures(){
Channel = channel,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ChatsBase>> GetAdminedPublicChannelsAsync(bool byLocation = false, bool checkLimit = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChatsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAdminedPublicChannels(){
ByLocation = byLocation,
CheckLimit = checkLimit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalEditBannedAsync(InputChannelBase channel, InputPeerBase participant, ChatBannedRightsBase bannedRights, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditBanned(){
Channel = channel,
Participant = participant,
BannedRights = bannedRights,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<AdminLogResultsBase>> InternalGetAdminLogAsync(InputChannelBase channel, string q, long maxId, long minId, int limit, ChannelAdminLogEventsFilterBase? eventsFilter = null, List<InputUserBase>? admins = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AdminLogResultsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAdminLog(){
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
internal async Task<RpcResponse<bool>> InternalSetStickersAsync(InputChannelBase channel, InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetStickers(){
Channel = channel,
Stickerset = stickerset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReadMessageContentsAsync(InputChannelBase channel, List<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReadMessageContents(){
Channel = channel,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalDeleteHistoryAsync(InputChannelBase channel, int maxId, bool forEveryone = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteHistory(){
Channel = channel,
MaxId = maxId,
ForEveryone = forEveryone,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalTogglePreHistoryHiddenAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new TogglePreHistoryHidden(){
Channel = channel,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ChatsBase>> GetLeftChannelsAsync(int offset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChatsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetLeftChannels(){
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ChatsBase>> GetGroupsForDiscussionAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ChatsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupsForDiscussion(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSetDiscussionGroupAsync(InputChannelBase broadcast, InputChannelBase group, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetDiscussionGroup(){
Broadcast = broadcast,
Group = group,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalEditCreatorAsync(InputChannelBase channel, InputUserBase userId, InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditCreator(){
Channel = channel,
UserId = userId,
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalEditLocationAsync(InputChannelBase channel, InputGeoPointBase geoPoint, string address, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditLocation(){
Channel = channel,
GeoPoint = geoPoint,
Address = address,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalToggleSlowModeAsync(InputChannelBase channel, int seconds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleSlowMode(){
Channel = channel,
Seconds = seconds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<InactiveChatsBase>> GetInactiveChannelsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<InactiveChatsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetInactiveChannels(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalConvertToGigagroupAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ConvertToGigagroup(){
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalViewSponsoredMessageAsync(InputChannelBase channel, byte[] randomId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ViewSponsoredMessage(){
Channel = channel,
RandomId = randomId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<SponsoredMessagesBase>> InternalGetSponsoredMessagesAsync(InputChannelBase channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SponsoredMessagesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSponsoredMessages(){
Channel = channel,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<SendAsPeersBase>> InternalGetSendAsAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SendAsPeersBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSendAs(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<AffectedHistoryBase>> InternalDeleteParticipantHistoryAsync(InputChannelBase channel, InputPeerBase participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AffectedHistoryBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteParticipantHistory(){
Channel = channel,
Participant = participant,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalToggleJoinToSendAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleJoinToSend(){
Channel = channel,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalToggleJoinRequestAsync(InputChannelBase channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleJoinRequest(){
Channel = channel,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReadHistoryAsync(long channel, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReadHistory(){
Channel = channelResolved,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AffectedMessagesBase>> DeleteMessagesAsync(long channel, List<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<AffectedMessagesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<AffectedMessagesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteMessages(){
Channel = channelResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReportSpamAsync(long channel, PeerId participant, List<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
if(participantToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
}
var participantResolved = participantToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReportSpam(){
Channel = channelResolved,
Participant = participantResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<MessagesBase>> GetMessagesAsync(long channel, List<InputMessageBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<MessagesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<MessagesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetMessages(){
Channel = channelResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ChannelParticipantsBase>> GetParticipantsAsync(long channel, ChannelParticipantsFilterBase filter, int offset, int limit, long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<ChannelParticipantsBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<ChannelParticipantsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetParticipants(){
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
public async Task<RpcResponse<ChannelParticipantBase>> GetParticipantAsync(long channel, PeerId participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<ChannelParticipantBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
if(participantToResolve is null) {
return RpcResponse<ChannelParticipantBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
}
var participantResolved = participantToResolve;
var rpcResponse = new RpcResponse<ChannelParticipantBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetParticipant(){
Channel = channelResolved,
Participant = participantResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<ChatsBase>> InternalGetChannelsAsync(List<long> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idResolved = new List<InputChannelBase>();
for (var i = 0; i < id.Count; i++){
var idToResolveOut = id[i];
var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(idToResolveOut);
if(idToResolve is null) {
return RpcResponse<ChatsBase>.FromError(new PeerNotFoundError(idToResolveOut, PeerType.Channel));
}
idResolved.Add(idToResolve);
}
var rpcResponse = new RpcResponse<ChatsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetChannels(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<ChatFullBase>> InternalGetFullChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<ChatFullBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<ChatFullBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetFullChannel(){
Channel = channelResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditAdminAsync(long channel, long userId, ChatAdminRightsBase adminRights, string rank, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(userId, PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditAdmin(){
Channel = channelResolved,
UserId = userIdResolved,
AdminRights = adminRights,
Rank = rank,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditTitleAsync(long channel, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditTitle(){
Channel = channelResolved,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditPhotoAsync(long channel, InputChatPhotoBase photo, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditPhoto(){
Channel = channelResolved,
Photo = photo,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CheckUsernameAsync(long channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CheckUsername(){
Channel = channelResolved,
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdateUsernameAsync(long channel, string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateUsername(){
Channel = channelResolved,
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> JoinChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new JoinChannel(){
Channel = channelResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> LeaveChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new LeaveChannel(){
Channel = channelResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> InviteToChannelAsync(long channel, List<long> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var usersResolved = new List<InputUserBase>();
for (var i = 0; i < users.Count; i++){
var usersToResolveOut = users[i];
var usersToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(usersToResolveOut);
if(usersToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(usersToResolveOut, PeerType.User));
}
usersResolved.Add(usersToResolve);
}
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new InviteToChannel(){
Channel = channelResolved,
Users = usersResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> DeleteChannelAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteChannel(){
Channel = channelResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ExportedMessageLinkBase>> ExportMessageLinkAsync(long channel, int id, bool grouped = false, bool thread = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<ExportedMessageLinkBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<ExportedMessageLinkBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ExportMessageLink(){
Channel = channelResolved,
Id = id,
Grouped = grouped,
Thread = thread,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleSignaturesAsync(long channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleSignatures(){
Channel = channelResolved,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditBannedAsync(long channel, PeerId participant, ChatBannedRightsBase bannedRights, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
if(participantToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
}
var participantResolved = participantToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditBanned(){
Channel = channelResolved,
Participant = participantResolved,
BannedRights = bannedRights,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AdminLogResultsBase>> GetAdminLogAsync(long channel, string q, long maxId, long minId, int limit, ChannelAdminLogEventsFilterBase? eventsFilter = null, List<long>? admins = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<AdminLogResultsBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var adminsResolved = new List<InputUserBase>();
if(admins is not null){
for (var i = 0; i < admins.Count; i++){
var adminsToResolveOut = admins[i];
var adminsToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(adminsToResolveOut);
if(adminsToResolve is null) {
return RpcResponse<AdminLogResultsBase>.FromError(new PeerNotFoundError(adminsToResolveOut, PeerType.User));
}
adminsResolved.Add(adminsToResolve);
}
}
var rpcResponse = new RpcResponse<AdminLogResultsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAdminLog(){
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
public async Task<RpcResponse<bool>> SetStickersAsync(long channel, InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetStickers(){
Channel = channelResolved,
Stickerset = stickerset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReadMessageContentsAsync(long channel, List<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReadMessageContents(){
Channel = channelResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> DeleteHistoryAsync(long channel, int maxId, bool forEveryone = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteHistory(){
Channel = channelResolved,
MaxId = maxId,
ForEveryone = forEveryone,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> TogglePreHistoryHiddenAsync(long channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new TogglePreHistoryHidden(){
Channel = channelResolved,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetDiscussionGroupAsync(long broadcast, long group, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var broadcastToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(broadcast);
if(broadcastToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(broadcast, PeerType.Channel));
}
var broadcastResolved = broadcastToResolve;
var groupToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(group);
if(groupToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(group, PeerType.Channel));
}
var groupResolved = groupToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetDiscussionGroup(){
Broadcast = broadcastResolved,
Group = groupResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditCreatorAsync(long channel, long userId, InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(userId, PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditCreator(){
Channel = channelResolved,
UserId = userIdResolved,
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> EditLocationAsync(long channel, InputGeoPointBase geoPoint, string address, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditLocation(){
Channel = channelResolved,
GeoPoint = geoPoint,
Address = address,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleSlowModeAsync(long channel, int seconds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleSlowMode(){
Channel = channelResolved,
Seconds = seconds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ConvertToGigagroupAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ConvertToGigagroup(){
Channel = channelResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ViewSponsoredMessageAsync(long channel, byte[] randomId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ViewSponsoredMessage(){
Channel = channelResolved,
RandomId = randomId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SponsoredMessagesBase>> GetSponsoredMessagesAsync(long channel, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<SponsoredMessagesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<SponsoredMessagesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSponsoredMessages(){
Channel = channelResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SendAsPeersBase>> GetSendAsAsync(PeerId peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<SendAsPeersBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<SendAsPeersBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSendAs(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AffectedHistoryBase>> DeleteParticipantHistoryAsync(long channel, PeerId participant, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<AffectedHistoryBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
if(participantToResolve is null) {
return RpcResponse<AffectedHistoryBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
}
var participantResolved = participantToResolve;
var rpcResponse = new RpcResponse<AffectedHistoryBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteParticipantHistory(){
Channel = channelResolved,
Participant = participantResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleJoinToSendAsync(long channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleJoinToSend(){
Channel = channelResolved,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleJoinRequestAsync(long channel, bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var channelToResolve = _client.DatabaseManager.PeerDatabase.ResolveChannel(channel);
if(channelToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(channel, PeerType.Channel));
}
var channelResolved = channelToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleJoinRequest(){
Channel = channelResolved,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}