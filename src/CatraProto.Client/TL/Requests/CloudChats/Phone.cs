using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using CatraProto.Client;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using System.Collections.Generic;
using System.Numerics;


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
	    
	    public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>> GetCallConfigAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetCallConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> InternalRequestCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gAHash, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, bool video = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.RequestCall(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> AcceptCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gB, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.AcceptCall(){
Peer = peer,
GB = gB,
Protocol = protocol,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> ConfirmCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gA, long keyFingerprint, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ConfirmCall(){
Peer = peer,
GA = gA,
KeyFingerprint = keyFingerprint,
Protocol = protocol,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReceivedCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ReceivedCall(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DiscardCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int duration, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase reason, long connectionId, bool video = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.DiscardCall(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetCallRatingAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int rating, string comment, bool userInitiative = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SetCallRating(){
Peer = peer,
Rating = rating,
Comment = comment,
UserInitiative = userInitiative,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveCallDebugAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase debug, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveCallDebug(){
Peer = peer,
Debug = debug,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SendSignalingDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] data, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SendSignalingData(){
Peer = peer,
Data = data,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalCreateGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int randomId, bool rtmpStream = false, string? title = null, int? scheduleDate = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.CreateGroupCall(){
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
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalJoinGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase joinAs, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams, bool muted = false, bool videoStopped = false, string? inviteHash = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinGroupCall(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> LeaveGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, int source, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.LeaveGroupCall(){
Call = call,
Source = source,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalInviteToGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.InviteToGroupCall(){
Call = call,
Users = users,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DiscardGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.DiscardGroupCall(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleGroupCallSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, bool resetInviteHash = false, bool? joinMuted = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ToggleGroupCallSettings(){
Call = call,
ResetInviteHash = resetInviteHash,
JoinMuted = joinMuted,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase>> GetGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCall(){
Call = call,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase>> InternalGetGroupParticipantsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase> ids, List<int> sources, string offset, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupParticipants(){
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
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<int>>> CheckGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<int> sources, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<int>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<int>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.CheckGroupCall(){
Call = call,
Sources = sources,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleGroupCallRecordAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, bool start = false, bool video = false, string? title = null, bool? videoPortrait = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ToggleGroupCallRecord(){
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
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditGroupCallParticipantAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase participant, bool? muted = null, int? volume = null, bool? raiseHand = null, bool? videoStopped = null, bool? videoPaused = null, bool? presentationPaused = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.EditGroupCallParticipant(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditGroupCallTitleAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.EditGroupCallTitle(){
Call = call,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeersBase>> InternalGetGroupCallJoinAsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallJoinAs(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportedGroupCallInviteBase>> ExportGroupCallInviteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, bool canSelfUnmute = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportedGroupCallInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ExportGroupCallInvite(){
Call = call,
CanSelfUnmute = canSelfUnmute,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleGroupCallStartSubscriptionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, bool subscribed, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ToggleGroupCallStartSubscription(){
Call = call,
Subscribed = subscribed,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> StartScheduledGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.StartScheduledGroupCall(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSaveDefaultGroupCallJoinAsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase joinAs, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveDefaultGroupCallJoinAs(){
Peer = peer,
JoinAs = joinAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> JoinGroupCallPresentationAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinGroupCallPresentation(){
Call = call,
Params = pparams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> LeaveGroupCallPresentationAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.LeaveGroupCallPresentation(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamChannelsBase>> GetGroupCallStreamChannelsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamChannelsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallStreamChannels(){
Call = call,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrlBase>> InternalGetGroupCallStreamRtmpUrlAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool revoke, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrlBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallStreamRtmpUrl(){
Peer = peer,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveCallLogAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveCallLog(){
Peer = peer,
File = file,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> RequestCallAsync(long userId, int randomId, byte[] gAHash, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, bool video = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.RequestCall(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateGroupCallAsync(CatraProto.Client.MTProto.PeerId peer, int randomId, bool rtmpStream = false, string? title = null, int? scheduleDate = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.CreateGroupCall(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> JoinGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.MTProto.PeerId joinAs, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams, bool muted = false, bool videoStopped = false, string? inviteHash = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var joinAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(joinAs);
if(joinAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(joinAs.Id, joinAs.Type));
}
var joinAsResolved = joinAsToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinGroupCall(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InviteToGroupCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<long> users, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var usersResolved = new List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
for (var i = 0; i < users.Count; i++){
var usersToResolveOut = users[i];
var usersToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(usersToResolveOut);
if(usersToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(usersToResolveOut, CatraProto.Client.MTProto.PeerType.User));
}
usersResolved.Add(usersToResolve);
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.InviteToGroupCall(){
Call = call,
Users = usersResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase>> GetGroupParticipantsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, List<CatraProto.Client.MTProto.PeerId> ids, List<int> sources, string offset, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idsResolved = new List<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
for (var i = 0; i < ids.Count; i++){
var idsToResolveOut = ids[i];
var idsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(idsToResolveOut);
if(idsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase>.FromError(new PeerNotFoundError(idsToResolveOut.Id, idsToResolveOut.Type));
}
idsResolved.Add(idsToResolve);
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupParticipantsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupParticipants(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditGroupCallParticipantAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, CatraProto.Client.MTProto.PeerId participant, bool? muted = null, int? volume = null, bool? raiseHand = null, bool? videoStopped = null, bool? videoPaused = null, bool? presentationPaused = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var participantToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(participant);
if(participantToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(participant.Id, participant.Type));
}
var participantResolved = participantToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.EditGroupCallParticipant(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeersBase>> GetGroupCallJoinAsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeersBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.JoinAsPeersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallJoinAs(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveDefaultGroupCallJoinAsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.MTProto.PeerId joinAs, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
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
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveDefaultGroupCallJoinAs(){
Peer = peerResolved,
JoinAs = joinAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrlBase>> GetGroupCallStreamRtmpUrlAsync(CatraProto.Client.MTProto.PeerId peer, bool revoke, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrlBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Phone.GroupCallStreamRtmpUrlBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetGroupCallStreamRtmpUrl(){
Peer = peerResolved,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}