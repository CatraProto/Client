#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Phone;
using GroupCallBase = CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase;
using PhoneCallBase = CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase;

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Phone
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Phone(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<DataJSONBase>> GetCallConfigAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<DataJSONBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetCallConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<PhoneCallBase>> InternalRequestCallAsync(InputUserBase userId, int randomId, byte[] gAHash, PhoneCallProtocolBase protocol, bool video = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PhoneCallBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new RequestCall(){
UserId = userId,
RandomId = randomId,
GAHash = gAHash,
Protocol = protocol,
Video = video,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PhoneCallBase>> AcceptCallAsync(InputPhoneCallBase peer, byte[] gB, PhoneCallProtocolBase protocol, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PhoneCallBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AcceptCall(){
Peer = peer,
GB = gB,
Protocol = protocol,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PhoneCallBase>> ConfirmCallAsync(InputPhoneCallBase peer, byte[] gA, long keyFingerprint, PhoneCallProtocolBase protocol, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PhoneCallBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ConfirmCall(){
Peer = peer,
GA = gA,
KeyFingerprint = keyFingerprint,
Protocol = protocol,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReceivedCallAsync(InputPhoneCallBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReceivedCall(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> DiscardCallAsync(InputPhoneCallBase peer, int duration, PhoneCallDiscardReasonBase reason, long connectionId, bool video = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DiscardCall(){
Peer = peer,
Duration = duration,
Reason = reason,
ConnectionId = connectionId,
Video = video,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> SetCallRatingAsync(InputPhoneCallBase peer, int rating, string comment, bool userInitiative = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetCallRating(){
Peer = peer,
Rating = rating,
Comment = comment,
UserInitiative = userInitiative,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveCallDebugAsync(InputPhoneCallBase peer, DataJSONBase debug, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveCallDebug(){
Peer = peer,
Debug = debug,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SendSignalingDataAsync(InputPhoneCallBase peer, byte[] data, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SendSignalingData(){
Peer = peer,
Data = data,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalCreateGroupCallAsync(InputPeerBase peer, int randomId, bool rtmpStream = false, string? title = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CreateGroupCall(){
Peer = peer,
RandomId = randomId,
RtmpStream = rtmpStream,
Title = title,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalJoinGroupCallAsync(InputGroupCallBase call, InputPeerBase joinAs, DataJSONBase pparams, bool muted = false, bool videoStopped = false, string? inviteHash = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new JoinGroupCall(){
Call = call,
JoinAs = joinAs,
Params = pparams,
Muted = muted,
VideoStopped = videoStopped,
InviteHash = inviteHash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> LeaveGroupCallAsync(InputGroupCallBase call, int source, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new LeaveGroupCall(){
Call = call,
Source = source,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalInviteToGroupCallAsync(InputGroupCallBase call, List<InputUserBase> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new InviteToGroupCall(){
Call = call,
Users = users,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> DiscardGroupCallAsync(InputGroupCallBase call, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DiscardGroupCall(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleGroupCallSettingsAsync(InputGroupCallBase call, bool resetInviteHash = false, bool? joinMuted = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleGroupCallSettings(){
Call = call,
ResetInviteHash = resetInviteHash,
JoinMuted = joinMuted,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<GroupCallBase>> GetGroupCallAsync(InputGroupCallBase call, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<GroupCallBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupCall(){
Call = call,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<GroupParticipantsBase>> InternalGetGroupParticipantsAsync(InputGroupCallBase call, List<InputPeerBase> ids, List<int> sources, string offset, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<GroupParticipantsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupParticipants(){
Call = call,
Ids = ids,
Sources = sources,
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<int>>> CheckGroupCallAsync(InputGroupCallBase call, List<int> sources, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<int>>(
new RpcVector<int>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CheckGroupCall(){
Call = call,
Sources = sources,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleGroupCallRecordAsync(InputGroupCallBase call, bool start = false, bool video = false, string? title = null, bool? videoPortrait = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleGroupCallRecord(){
Call = call,
Start = start,
Video = video,
Title = title,
VideoPortrait = videoPortrait,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalEditGroupCallParticipantAsync(InputGroupCallBase call, InputPeerBase participant, bool? muted = null, int? volume = null, bool? raiseHand = null, bool? videoStopped = null, bool? videoPaused = null, bool? presentationPaused = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditGroupCallParticipant(){
Call = call,
Participant = participant,
Muted = muted,
Volume = volume,
RaiseHand = raiseHand,
VideoStopped = videoStopped,
VideoPaused = videoPaused,
PresentationPaused = presentationPaused,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditGroupCallTitleAsync(InputGroupCallBase call, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditGroupCallTitle(){
Call = call,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<JoinAsPeersBase>> InternalGetGroupCallJoinAsAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<JoinAsPeersBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupCallJoinAs(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ExportedGroupCallInviteBase>> ExportGroupCallInviteAsync(InputGroupCallBase call, bool canSelfUnmute = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ExportedGroupCallInviteBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ExportGroupCallInvite(){
Call = call,
CanSelfUnmute = canSelfUnmute,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> ToggleGroupCallStartSubscriptionAsync(InputGroupCallBase call, bool subscribed, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleGroupCallStartSubscription(){
Call = call,
Subscribed = subscribed,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> StartScheduledGroupCallAsync(InputGroupCallBase call, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new StartScheduledGroupCall(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSaveDefaultGroupCallJoinAsAsync(InputPeerBase peer, InputPeerBase joinAs, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveDefaultGroupCallJoinAs(){
Peer = peer,
JoinAs = joinAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> JoinGroupCallPresentationAsync(InputGroupCallBase call, DataJSONBase pparams, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new JoinGroupCallPresentation(){
Call = call,
Params = pparams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> LeaveGroupCallPresentationAsync(InputGroupCallBase call, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new LeaveGroupCallPresentation(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<GroupCallStreamChannelsBase>> GetGroupCallStreamChannelsAsync(InputGroupCallBase call, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<GroupCallStreamChannelsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupCallStreamChannels(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<GroupCallStreamRtmpUrlBase>> InternalGetGroupCallStreamRtmpUrlAsync(InputPeerBase peer, bool revoke, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<GroupCallStreamRtmpUrlBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupCallStreamRtmpUrl(){
Peer = peer,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveCallLogAsync(InputPhoneCallBase peer, InputFileBase file, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveCallLog(){
Peer = peer,
File = file,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PhoneCallBase>> RequestCallAsync(long userId, int randomId, byte[] gAHash, PhoneCallProtocolBase protocol, bool video = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<PhoneCallBase>.FromError(new PeerNotFoundError(userId, PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<PhoneCallBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new RequestCall(){
UserId = userIdResolved,
RandomId = randomId,
GAHash = gAHash,
Protocol = protocol,
Video = video,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> CreateGroupCallAsync(PeerId peer, int randomId, bool rtmpStream = false, string? title = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CreateGroupCall(){
Peer = peerResolved,
RandomId = randomId,
RtmpStream = rtmpStream,
Title = title,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> JoinGroupCallAsync(InputGroupCallBase call, PeerId joinAs, DataJSONBase pparams, bool muted = false, bool videoStopped = false, string? inviteHash = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var joinAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(joinAs);
if(joinAsToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(joinAs.Id, joinAs.Type));
}
var joinAsResolved = joinAsToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new JoinGroupCall(){
Call = call,
JoinAs = joinAsResolved,
Params = pparams,
Muted = muted,
VideoStopped = videoStopped,
InviteHash = inviteHash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> InviteToGroupCallAsync(InputGroupCallBase call, List<long> users, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

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
var methodBody = new InviteToGroupCall(){
Call = call,
Users = usersResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<GroupParticipantsBase>> GetGroupParticipantsAsync(InputGroupCallBase call, List<PeerId> ids, List<int> sources, string offset, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idsResolved = new List<InputPeerBase>();
for (var i = 0; i < ids.Count; i++){
var idsToResolveOut = ids[i];
var idsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(idsToResolveOut);
if(idsToResolve is null) {
return RpcResponse<GroupParticipantsBase>.FromError(new PeerNotFoundError(idsToResolveOut.Id, idsToResolveOut.Type));
}
idsResolved.Add(idsToResolve);
}
var rpcResponse = new RpcResponse<GroupParticipantsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupParticipants(){
Call = call,
Ids = idsResolved,
Sources = sources,
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> EditGroupCallParticipantAsync(InputGroupCallBase call, PeerId participant, bool? muted = null, int? volume = null, bool? raiseHand = null, bool? videoStopped = null, bool? videoPaused = null, bool? presentationPaused = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
if(participantToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
}
var participantResolved = participantToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new EditGroupCallParticipant(){
Call = call,
Participant = participantResolved,
Muted = muted,
Volume = volume,
RaiseHand = raiseHand,
VideoStopped = videoStopped,
VideoPaused = videoPaused,
PresentationPaused = presentationPaused,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<JoinAsPeersBase>> GetGroupCallJoinAsAsync(PeerId peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<JoinAsPeersBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<JoinAsPeersBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupCallJoinAs(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveDefaultGroupCallJoinAsAsync(PeerId peer, PeerId joinAs, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var joinAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(joinAs);
if(joinAsToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(joinAs.Id, joinAs.Type));
}
var joinAsResolved = joinAsToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveDefaultGroupCallJoinAs(){
Peer = peerResolved,
JoinAs = joinAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<GroupCallStreamRtmpUrlBase>> GetGroupCallStreamRtmpUrlAsync(PeerId peer, bool revoke, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<GroupCallStreamRtmpUrlBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<GroupCallStreamRtmpUrlBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGroupCallStreamRtmpUrl(){
Peer = peerResolved,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}