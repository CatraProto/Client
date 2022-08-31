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
	public partial class Messages
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Messages(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessagesAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessages(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>> InternalGetDialogsAsync(int offsetDate, int offsetId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int limit, long hash, bool excludePinned = false, int? folderId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogs(){
OffsetDate = offsetDate,
OffsetId = offsetId,
OffsetPeer = offsetPeer,
Limit = limit,
Hash = hash,
ExcludePinned = excludePinned,
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetHistory(){
Peer = peer,
OffsetId = offsetId,
OffsetDate = offsetDate,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalSearchAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, long hash, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? fromId = null, int? topMsgId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.Search(){
Peer = peer,
Q = q,
Filter = filter,
MinDate = minDate,
MaxDate = maxDate,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
Hash = hash,
FromId = fromId,
TopMsgId = topMsgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> InternalReadHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadHistory(){
Peer = peer,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> InternalDeleteHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId, bool justClear = false, bool revoke = false, int? minDate = null, int? maxDate = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteHistory(){
Peer = peer,
MaxId = maxId,
JustClear = justClear,
Revoke = revoke,
MinDate = minDate,
MaxDate = maxDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> DeleteMessagesAsync(List<int> id, bool revoke = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteMessages(){
Id = id,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>>> ReceivedMessagesAsync(int maxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedMessages(){
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSetTypingAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action, int? topMsgId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetTyping(){
Peer = peer,
Action = action,
TopMsgId = topMsgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message, long randomId, bool noWebpage = false, bool silent = false, bool background = false, bool clearDraft = false, bool noforwards = false, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMessage(){
Peer = peer,
Message = message,
RandomId = randomId,
NoWebpage = noWebpage,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
Noforwards = noforwards,
ReplyToMsgId = replyToMsgId,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, string message, long randomId, bool silent = false, bool background = false, bool clearDraft = false, bool noforwards = false, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMedia(){
Peer = peer,
Media = media,
Message = message,
RandomId = randomId,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
Noforwards = noforwards,
ReplyToMsgId = replyToMsgId,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalForwardMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase fromPeer, List<int> id, List<long> randomId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase toPeer, bool silent = false, bool background = false, bool withMyScore = false, bool dropAuthor = false, bool dropMediaCaptions = false, bool noforwards = false, int? scheduleDate = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ForwardMessages(){
FromPeer = fromPeer,
Id = id,
RandomId = randomId,
ToPeer = toPeer,
Silent = silent,
Background = background,
WithMyScore = withMyScore,
DropAuthor = dropAuthor,
DropMediaCaptions = dropMediaCaptions,
Noforwards = noforwards,
ScheduleDate = scheduleDate,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReportSpamAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportSpam(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettingsBase>> InternalGetPeerSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettingsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerSettings(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReportAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, string message, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.Report(){
Peer = peer,
Id = id,
Reason = reason,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> InternalGetChatsAsync(List<long> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChats(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> InternalGetFullChatAsync(long chatId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFullChat(){
ChatId = chatId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatTitleAsync(long chatId, string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatTitle(){
ChatId = chatId,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatPhotoAsync(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatPhoto(){
ChatId = chatId,
Photo = photo,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalAddChatUserAsync(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int fwdLimit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AddChatUser(){
ChatId = chatId,
UserId = userId,
FwdLimit = fwdLimit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalDeleteChatUserAsync(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, bool revokeHistory = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChatUser(){
ChatId = chatId,
UserId = userId,
RevokeHistory = revokeHistory,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalCreateChatAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CreateChat(){
Users = users,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase>> GetDhConfigAsync(int version, int randomLength, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDhConfig(){
Version = version,
RandomLength = randomLength,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> InternalRequestEncryptionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gA, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestEncryption(){
UserId = userId,
RandomId = randomId,
GA = gA,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> AcceptEncryptionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] gB, long keyFingerprint, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptEncryption(){
Peer = peer,
GB = gB,
KeyFingerprint = keyFingerprint,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DiscardEncryptionAsync(int chatId, bool deleteHistory = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscardEncryption(){
ChatId = chatId,
DeleteHistory = deleteHistory,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetEncryptedTypingAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, bool typing, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetEncryptedTyping(){
Peer = peer,
Typing = typing,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReadEncryptedHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, int maxDate, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadEncryptedHistory(){
Peer = peer,
MaxDate = maxDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> InternalSendEncryptedAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, bool silent = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncrypted(){
Peer = peer,
RandomId = randomId,
Data = data,
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> InternalSendEncryptedFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, bool silent = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedFile(){
Peer = peer,
RandomId = randomId,
Data = data,
File = file,
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> InternalSendEncryptedServiceAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedService(){
Peer = peer,
RandomId = randomId,
Data = data,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>> ReceivedQueueAsync(int maxQts, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedQueue(){
MaxQts = maxQts,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReportEncryptedSpamAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportEncryptedSpam(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> ReadMessageContentsAsync(List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMessageContents(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase>> GetStickersAsync(string emoticon, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickers(){
Emoticon = emoticon,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>> GetAllStickersAsync(long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> GetWebPagePreviewAsync(string message, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPagePreview(){
Message = message,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>> InternalExportChatInviteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool legacyRevokePermanent = false, bool requestNeeded = false, int? expireDate = null, int? usageLimit = null, string? title = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportChatInvite(){
Peer = peer,
LegacyRevokePermanent = legacyRevokePermanent,
RequestNeeded = requestNeeded,
ExpireDate = expireDate,
UsageLimit = usageLimit,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>> CheckChatInviteAsync(string hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckChatInvite(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ImportChatInviteAsync(string hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ImportChatInvite(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> GetStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, int hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickerSet(){
Stickerset = stickerset,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase>> InstallStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, bool archived, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.InstallStickerSet(){
Stickerset = stickerset,
Archived = archived,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UninstallStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UninstallStickerSet(){
Stickerset = stickerset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalStartBotAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, string startParam, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartBot(){
Bot = bot,
Peer = peer,
RandomId = randomId,
StartParam = startParam,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>> InternalGetMessagesViewsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, bool increment, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesViews(){
Peer = peer,
Id = id,
Increment = increment,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalEditChatAdminAsync(long chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, bool isAdmin, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAdmin(){
ChatId = chatId,
UserId = userId,
IsAdmin = isAdmin,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> MigrateChatAsync(long chatId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.MigrateChat(){
ChatId = chatId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalSearchGlobalAsync(string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit, int? folderId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchGlobal(){
Q = q,
Filter = filter,
MinDate = minDate,
MaxDate = maxDate,
OffsetRate = offsetRate,
OffsetPeer = offsetPeer,
OffsetId = offsetId,
Limit = limit,
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReorderStickerSetsAsync(List<long> order, bool masks = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderStickerSets(){
Order = order,
Masks = masks,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>> GetDocumentByHashAsync(byte[] sha256, long size, string mimeType, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDocumentByHash(){
Sha256 = sha256,
Size = size,
MimeType = mimeType,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase>> GetSavedGifsAsync(long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSavedGifs(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveGifAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveGif(){
Id = id,
Unsave = unsave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>> InternalGetInlineBotResultsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string query, string offset, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase? geoPoint = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineBotResults(){
Bot = bot,
Peer = peer,
Query = query,
Offset = offset,
GeoPoint = geoPoint,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetInlineBotResultsAsync(long queryId, List<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> results, int cacheTime, bool gallery = false, bool pprivate = false, string? nextOffset = null, CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase? switchPm = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineBotResults(){
QueryId = queryId,
Results = results,
CacheTime = cacheTime,
Gallery = gallery,
Private = pprivate,
NextOffset = nextOffset,
SwitchPm = switchPm,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendInlineBotResultAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, long queryId, string id, bool silent = false, bool background = false, bool clearDraft = false, bool hideVia = false, int? replyToMsgId = null, int? scheduleDate = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendInlineBotResult(){
Peer = peer,
RandomId = randomId,
QueryId = queryId,
Id = id,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
HideVia = hideVia,
ReplyToMsgId = replyToMsgId,
ScheduleDate = scheduleDate,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>> InternalGetMessageEditDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageEditData(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, bool noWebpage = false, string? message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase? media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditMessage(){
Peer = peer,
Id = id,
NoWebpage = noWebpage,
Message = message,
Media = media,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> EditInlineBotMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, bool noWebpage = false, string? message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase? media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditInlineBotMessage(){
Id = id,
NoWebpage = noWebpage,
Message = message,
Media = media,
ReplyMarkup = replyMarkup,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>> InternalGetBotCallbackAnswerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, bool game = false, byte[]? data = null, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase? password = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetBotCallbackAnswer(){
Peer = peer,
MsgId = msgId,
Game = game,
Data = data,
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetBotCallbackAnswerAsync(long queryId, int cacheTime, bool alert = false, string? message = null, string? url = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotCallbackAnswer(){
QueryId = queryId,
CacheTime = cacheTime,
Alert = alert,
Message = message,
Url = url,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>> GetPeerDialogsAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> peers, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerDialogs(){
Peers = peers,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSaveDraftAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message, bool noWebpage = false, int? replyToMsgId = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDraft(){
Peer = peer,
Message = message,
NoWebpage = noWebpage,
ReplyToMsgId = replyToMsgId,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetAllDraftsAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllDrafts(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>> GetFeaturedStickersAsync(long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFeaturedStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReadFeaturedStickersAsync(List<long> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadFeaturedStickers(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase>> GetRecentStickersAsync(long hash, bool attached = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentStickers(){
Hash = hash,
Attached = attached,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveRecentStickerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave, bool attached = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveRecentSticker(){
Id = id,
Unsave = unsave,
Attached = attached,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ClearRecentStickersAsync(bool attached = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearRecentStickers(){
Attached = attached,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase>> GetArchivedStickersAsync(long offsetId, int limit, bool masks = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetArchivedStickers(){
OffsetId = offsetId,
Limit = limit,
Masks = masks,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>> GetMaskStickersAsync(long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMaskStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>>> GetAttachedStickersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase media, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachedStickers(){
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSetGameScoreAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score, bool editMessage = false, bool force = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetGameScore(){
Peer = peer,
Id = id,
UserId = userId,
Score = score,
EditMessage = editMessage,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSetInlineGameScoreAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score, bool editMessage = false, bool force = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineGameScore(){
Id = id,
UserId = userId,
Score = score,
EditMessage = editMessage,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> InternalGetGameHighScoresAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetGameHighScores(){
Peer = peer,
Id = id,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> InternalGetInlineGameHighScoresAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineGameHighScores(){
Id = id,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> InternalGetCommonChatsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, long maxId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetCommonChats(){
UserId = userId,
MaxId = maxId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetAllChatsAsync(List<long> exceptIds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllChats(){
ExceptIds = exceptIds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>> GetWebPageAsync(string url, int hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPage(){
Url = url,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ToggleDialogPinAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer, bool pinned = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleDialogPin(){
Peer = peer,
Pinned = pinned,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReorderPinnedDialogsAsync(int folderId, List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> order, bool force = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderPinnedDialogs(){
FolderId = folderId,
Order = order,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>> GetPinnedDialogsAsync(int folderId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPinnedDialogs(){
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetBotShippingResultsAsync(long queryId, string? error = null, List<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>? shippingOptions = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotShippingResults(){
QueryId = queryId,
Error = error,
ShippingOptions = shippingOptions,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetBotPrecheckoutResultsAsync(long queryId, bool success = false, string? error = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotPrecheckoutResults(){
QueryId = queryId,
Success = success,
Error = error,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> InternalUploadMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadMedia(){
Peer = peer,
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendScreenshotNotificationAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int replyToMsgId, long randomId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScreenshotNotification(){
Peer = peer,
ReplyToMsgId = replyToMsgId,
RandomId = randomId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase>> GetFavedStickersAsync(long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFavedStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> FaveStickerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unfave, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.FaveSticker(){
Id = id,
Unfave = unfave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetUnreadMentionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadMentions(){
Peer = peer,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> InternalReadMentionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMentions(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetRecentLocationsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int limit, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentLocations(){
Peer = peer,
Limit = limit,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendMultiMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> multiMedia, bool silent = false, bool background = false, bool clearDraft = false, bool noforwards = false, int? replyToMsgId = null, int? scheduleDate = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMultiMedia(){
Peer = peer,
MultiMedia = multiMedia,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
Noforwards = noforwards,
ReplyToMsgId = replyToMsgId,
ScheduleDate = scheduleDate,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>> UploadEncryptedFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadEncryptedFile(){
Peer = peer,
File = file,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase>> SearchStickerSetsAsync(string q, long hash, bool excludeFeatured = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchStickerSets(){
Q = q,
Hash = hash,
ExcludeFeatured = excludeFeatured,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>>> GetSplitRangesAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSplitRanges(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> MarkDialogUnreadAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer, bool unread = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.MarkDialogUnread(){
Peer = peer,
Unread = unread,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>>> GetDialogUnreadMarksAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogUnreadMarks(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ClearAllDraftsAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearAllDrafts(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalUpdatePinnedMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, bool silent = false, bool unpin = false, bool pmOneside = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdatePinnedMessage(){
Peer = peer,
Id = id,
Silent = silent,
Unpin = unpin,
PmOneside = pmOneside,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendVoteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, List<byte[]> options, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendVote(){
Peer = peer,
MsgId = msgId,
Options = options,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalGetPollResultsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollResults(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>> InternalGetOnlinesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOnlines(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalEditChatAboutAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string about, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAbout(){
Peer = peer,
About = about,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalEditChatDefaultBannedRightsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatDefaultBannedRights(){
Peer = peer,
BannedRights = bannedRights,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>> GetEmojiKeywordsAsync(string langCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywords(){
LangCode = langCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>> GetEmojiKeywordsDifferenceAsync(string langCode, int fromVersion, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywordsDifference(){
LangCode = langCode,
FromVersion = fromVersion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>>> GetEmojiKeywordsLanguagesAsync(List<string> langCodes, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywordsLanguages(){
LangCodes = langCodes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase>> GetEmojiURLAsync(string langCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiURL(){
LangCode = langCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>> InternalGetSearchCountersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> filters, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchCounters(){
Peer = peer,
Filters = filters,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> InternalRequestUrlAuthAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? peer = null, int? msgId = null, int? buttonId = null, string? url = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestUrlAuth(){
Peer = peer,
MsgId = msgId,
ButtonId = buttonId,
Url = url,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> InternalAcceptUrlAuthAsync(bool writeAllowed = false, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? peer = null, int? msgId = null, int? buttonId = null, string? url = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptUrlAuth(){
WriteAllowed = writeAllowed,
Peer = peer,
MsgId = msgId,
ButtonId = buttonId,
Url = url,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalHidePeerSettingsBarAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HidePeerSettingsBar(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetScheduledHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledHistory(){
Peer = peer,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetScheduledMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledMessages(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendScheduledMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScheduledMessages(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalDeleteScheduledMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteScheduledMessages(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>> InternalGetPollVotesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, int limit, byte[]? option = null, string? offset = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollVotes(){
Peer = peer,
Id = id,
Limit = limit,
Option = option,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ToggleStickerSetsAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> stickersets, bool uninstall = false, bool archive = false, bool unarchive = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleStickerSets(){
Stickersets = stickersets,
Uninstall = uninstall,
Archive = archive,
Unarchive = unarchive,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>>> GetDialogFiltersAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogFilters(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>>> GetSuggestedDialogFiltersAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSuggestedDialogFilters(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdateDialogFilterAsync(int id, CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase? filter = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFilter(){
Id = id,
Filter = filter,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdateDialogFiltersOrderAsync(List<int> order, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFiltersOrder(){
Order = order,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>> GetOldFeaturedStickersAsync(int offset, int limit, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOldFeaturedStickers(){
Offset = offset,
Limit = limit,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetRepliesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetReplies(){
Peer = peer,
MsgId = msgId,
OffsetId = offsetId,
OffsetDate = offsetDate,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>> InternalGetDiscussionMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDiscussionMessage(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReadDiscussionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int readMaxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadDiscussion(){
Peer = peer,
MsgId = msgId,
ReadMaxId = readMaxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> InternalUnpinAllMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UnpinAllMessages(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeleteChatAsync(long chatId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChat(){
ChatId = chatId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedFoundMessagesBase>> DeletePhoneCallHistoryAsync(bool revoke = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedFoundMessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeletePhoneCallHistory(){
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsedBase>> CheckHistoryImportAsync(string importHead, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportParsedBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckHistoryImport(){
ImportHead = importHead,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase>> InternalInitHistoryImportAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, int mediaCount, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.InitHistoryImport(){
Peer = peer,
File = file,
MediaCount = mediaCount,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> InternalUploadImportedMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long importId, string fileName, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadImportedMedia(){
Peer = peer,
ImportId = importId,
FileName = fileName,
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalStartHistoryImportAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long importId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartHistoryImport(){
Peer = peer,
ImportId = importId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase>> InternalGetExportedChatInvitesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase adminId, int limit, bool revoked = false, int? offsetDate = null, string? offsetLink = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetExportedChatInvites(){
Peer = peer,
AdminId = adminId,
Limit = limit,
Revoked = revoked,
OffsetDate = offsetDate,
OffsetLink = offsetLink,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>> InternalGetExportedChatInviteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string link, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetExportedChatInvite(){
Peer = peer,
Link = link,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>> InternalEditExportedChatInviteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string link, bool revoked = false, int? expireDate = null, int? usageLimit = null, bool? requestNeeded = null, string? title = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditExportedChatInvite(){
Peer = peer,
Link = link,
Revoked = revoked,
ExpireDate = expireDate,
UsageLimit = usageLimit,
RequestNeeded = requestNeeded,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalDeleteRevokedExportedChatInvitesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase adminId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteRevokedExportedChatInvites(){
Peer = peer,
AdminId = adminId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalDeleteExportedChatInviteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string link, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteExportedChatInvite(){
Peer = peer,
Link = link,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase>> InternalGetAdminsWithInvitesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAdminsWithInvites(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase>> InternalGetChatInviteImportersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetDate, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase offsetUser, int limit, bool requested = false, string? link = null, string? q = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChatInviteImporters(){
Peer = peer,
OffsetDate = offsetDate,
OffsetUser = offsetUser,
Limit = limit,
Requested = requested,
Link = link,
Q = q,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSetHistoryTTLAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int period, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetHistoryTTL(){
Peer = peer,
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase>> InternalCheckHistoryImportPeerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckHistoryImportPeer(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSetChatThemeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string emoticon, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetChatTheme(){
Peer = peer,
Emoticon = emoticon,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>> InternalGetMessageReadParticipantsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageReadParticipants(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase>> InternalGetSearchResultsCalendarAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int offsetId, int offsetDate, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchResultsCalendar(){
Peer = peer,
Filter = filter,
OffsetId = offsetId,
OffsetDate = offsetDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase>> InternalGetSearchResultsPositionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int offsetId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchResultsPositions(){
Peer = peer,
Filter = filter,
OffsetId = offsetId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalHideChatJoinRequestAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, bool approved = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HideChatJoinRequest(){
Peer = peer,
UserId = userId,
Approved = approved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalHideAllChatJoinRequestsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool approved = false, string? link = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HideAllChatJoinRequests(){
Peer = peer,
Approved = approved,
Link = link,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalToggleNoForwardsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleNoForwards(){
Peer = peer,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSaveDefaultSendAsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase sendAs, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDefaultSendAs(){
Peer = peer,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendReactionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, bool big = false, string? reaction = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendReaction(){
Peer = peer,
MsgId = msgId,
Big = big,
Reaction = reaction,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalGetMessagesReactionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesReactions(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase>> InternalGetMessageReactionsListAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, int limit, string? reaction = null, string? offset = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageReactionsList(){
Peer = peer,
Id = id,
Limit = limit,
Reaction = reaction,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSetChatAvailableReactionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<string> availableReactions, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetChatAvailableReactions(){
Peer = peer,
AvailableReactions = availableReactions,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactionsBase>> GetAvailableReactionsAsync(int hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AvailableReactionsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAvailableReactions(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetDefaultReactionAsync(string reaction, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetDefaultReaction(){
Reaction = reaction,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase>> InternalTranslateTextAsync(string toLang, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? peer = null, int? msgId = null, string? text = null, string? fromLang = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslateText(){
ToLang = toLang,
Peer = peer,
MsgId = msgId,
Text = text,
FromLang = fromLang,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> InternalGetUnreadReactionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadReactions(){
Peer = peer,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> InternalReadReactionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadReactions(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> SearchSentMediaAsync(string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchSentMedia(){
Q = q,
Filter = filter,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBase>> GetAttachMenuBotsAsync(long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachMenuBots(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBotBase>> InternalGetAttachMenuBotAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBotBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachMenuBot(){
Bot = bot,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalToggleBotInAttachMenuAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleBotInAttachMenu(){
Bot = bot,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>> InternalRequestWebViewAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, bool fromBotMenu = false, bool silent = false, string? url = null, string? startParam = null, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase? themeParams = null, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestWebView(){
Peer = peer,
Bot = bot,
FromBotMenu = fromBotMenu,
Silent = silent,
Url = url,
StartParam = startParam,
ThemeParams = themeParams,
ReplyToMsgId = replyToMsgId,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalProlongWebViewAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, long queryId, bool silent = false, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ProlongWebView(){
Peer = peer,
Bot = bot,
QueryId = queryId,
Silent = silent,
ReplyToMsgId = replyToMsgId,
SendAs = sendAs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.SimpleWebViewResultBase>> InternalRequestSimpleWebViewAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, string url, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase? themeParams = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.SimpleWebViewResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestSimpleWebView(){
Bot = bot,
Url = url,
ThemeParams = themeParams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewMessageSentBase>> SendWebViewResultMessageAsync(string botQueryId, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase result, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewMessageSentBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendWebViewResultMessage(){
BotQueryId = botQueryId,
Result = result,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InternalSendWebViewDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, long randomId, string buttonText, string data, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendWebViewData(){
Bot = bot,
RandomId = randomId,
ButtonText = buttonText,
Data = data,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase>> InternalTranscribeAudioAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribeAudio(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalRateTranscribedAudioAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, long transcriptionId, bool good, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RateTranscribedAudio(){
Peer = peer,
MsgId = msgId,
TranscriptionId = transcriptionId,
Good = good,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>> GetDialogsAsync(int offsetDate, int offsetId, CatraProto.Client.MTProto.PeerId offsetPeer, int limit, long hash, bool excludePinned = false, int? folderId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var offsetPeerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(offsetPeer);
if(offsetPeerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>.FromError(new PeerNotFoundError(offsetPeer.Id, offsetPeer.Type));
}
var offsetPeerResolved = offsetPeerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogs(){
OffsetDate = offsetDate,
OffsetId = offsetId,
OffsetPeer = offsetPeerResolved,
Limit = limit,
Hash = hash,
ExcludePinned = excludePinned,
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetHistoryAsync(CatraProto.Client.MTProto.PeerId peer, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetHistory(){
Peer = peerResolved,
OffsetId = offsetId,
OffsetDate = offsetDate,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> SearchAsync(CatraProto.Client.MTProto.PeerId peer, string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, long hash, CatraProto.Client.MTProto.PeerId? fromId = null, int? topMsgId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? fromIdResolved = null;
if(fromId is not null){
var fromIdToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(fromId.Value);
if(fromIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(fromId.Value.Id, fromId.Value.Type));
}
fromIdResolved = fromIdToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.Search(){
Peer = peerResolved,
Q = q,
Filter = filter,
MinDate = minDate,
MaxDate = maxDate,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
Hash = hash,
FromId = fromIdResolved,
TopMsgId = topMsgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> ReadHistoryAsync(CatraProto.Client.MTProto.PeerId peer, int maxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadHistory(){
Peer = peerResolved,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> DeleteHistoryAsync(CatraProto.Client.MTProto.PeerId peer, int maxId, bool justClear = false, bool revoke = false, int? minDate = null, int? maxDate = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteHistory(){
Peer = peerResolved,
MaxId = maxId,
JustClear = justClear,
Revoke = revoke,
MinDate = minDate,
MaxDate = maxDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetTypingAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action, int? topMsgId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetTyping(){
Peer = peerResolved,
Action = action,
TopMsgId = topMsgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMessageAsync(CatraProto.Client.MTProto.PeerId peer, string message, bool noWebpage = false, bool silent = false, bool background = false, bool clearDraft = false, bool noforwards = false, int? replyToMsgId = null, long? randomId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMessage(){
Peer = peerResolved,
Message = message,
NoWebpage = noWebpage,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
Noforwards = noforwards,
ReplyToMsgId = replyToMsgId,
RandomId = randomId.Value,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMediaAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, string message, bool silent = false, bool background = false, bool clearDraft = false, bool noforwards = false, int? replyToMsgId = null, long? randomId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMedia(){
Peer = peerResolved,
Media = media,
Message = message,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
Noforwards = noforwards,
ReplyToMsgId = replyToMsgId,
RandomId = randomId.Value,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ForwardMessagesAsync(CatraProto.Client.MTProto.PeerId fromPeer, List<int> id, CatraProto.Client.MTProto.PeerId toPeer, bool silent = false, bool background = false, bool withMyScore = false, bool dropAuthor = false, bool dropMediaCaptions = false, bool noforwards = false, List<long>? randomId = null, int? scheduleDate = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var fromPeerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(fromPeer);
if(fromPeerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(fromPeer.Id, fromPeer.Type));
}
var fromPeerResolved = fromPeerToResolve;
var toPeerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(toPeer);
if(toPeerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(toPeer.Id, toPeer.Type));
}
var toPeerResolved = toPeerToResolve;
if(randomId is null){
randomId = new List<long>();
for (var i = 0; i < id.Count; i++){
randomId.Add(_client.RandomIdHandler.GetNextId());
}
}
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ForwardMessages(){
FromPeer = fromPeerResolved,
Id = id,
ToPeer = toPeerResolved,
Silent = silent,
Background = background,
WithMyScore = withMyScore,
DropAuthor = dropAuthor,
DropMediaCaptions = dropMediaCaptions,
Noforwards = noforwards,
RandomId = randomId,
ScheduleDate = scheduleDate,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReportSpamAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportSpam(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettingsBase>> GetPeerSettingsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettingsBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerSettingsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerSettings(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReportAsync(CatraProto.Client.MTProto.PeerId peer, List<int> id, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, string message, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.Report(){
Peer = peerResolved,
Id = id,
Reason = reason,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> AddChatUserAsync(long chatId, long userId, int fwdLimit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AddChatUser(){
ChatId = chatId,
UserId = userIdResolved,
FwdLimit = fwdLimit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteChatUserAsync(long chatId, long userId, bool revokeHistory = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChatUser(){
ChatId = chatId,
UserId = userIdResolved,
RevokeHistory = revokeHistory,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateChatAsync(List<long> users, string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
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
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CreateChat(){
Users = usersResolved,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> RequestEncryptionAsync(long userId, int randomId, byte[] gA, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestEncryption(){
UserId = userIdResolved,
RandomId = randomId,
GA = gA,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] data, bool silent = false, long? randomId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncrypted(){
Peer = peer,
Data = data,
Silent = silent,
RandomId = randomId.Value,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] data, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, bool silent = false, long? randomId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedFile(){
Peer = peer,
Data = data,
File = file,
Silent = silent,
RandomId = randomId.Value,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedServiceAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] data, long? randomId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedService(){
Peer = peer,
Data = data,
RandomId = randomId.Value,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>> ExportChatInviteAsync(CatraProto.Client.MTProto.PeerId peer, bool legacyRevokePermanent = false, bool requestNeeded = false, int? expireDate = null, int? usageLimit = null, string? title = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportChatInvite(){
Peer = peerResolved,
LegacyRevokePermanent = legacyRevokePermanent,
RequestNeeded = requestNeeded,
ExpireDate = expireDate,
UsageLimit = usageLimit,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> StartBotAsync(long bot, CatraProto.Client.MTProto.PeerId peer, string startParam, long? randomId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartBot(){
Bot = botResolved,
Peer = peerResolved,
StartParam = startParam,
RandomId = randomId.Value,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>> GetMessagesViewsAsync(CatraProto.Client.MTProto.PeerId peer, List<int> id, bool increment, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesViews(){
Peer = peerResolved,
Id = id,
Increment = increment,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> EditChatAdminAsync(long chatId, long userId, bool isAdmin, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAdmin(){
ChatId = chatId,
UserId = userIdResolved,
IsAdmin = isAdmin,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> SearchGlobalAsync(string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, CatraProto.Client.MTProto.PeerId offsetPeer, int offsetId, int limit, int? folderId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var offsetPeerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(offsetPeer);
if(offsetPeerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(offsetPeer.Id, offsetPeer.Type));
}
var offsetPeerResolved = offsetPeerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchGlobal(){
Q = q,
Filter = filter,
MinDate = minDate,
MaxDate = maxDate,
OffsetRate = offsetRate,
OffsetPeer = offsetPeerResolved,
OffsetId = offsetId,
Limit = limit,
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>> GetInlineBotResultsAsync(long bot, CatraProto.Client.MTProto.PeerId peer, string query, string offset, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase? geoPoint = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineBotResults(){
Bot = botResolved,
Peer = peerResolved,
Query = query,
Offset = offset,
GeoPoint = geoPoint,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendInlineBotResultAsync(CatraProto.Client.MTProto.PeerId peer, long queryId, string id, bool silent = false, bool background = false, bool clearDraft = false, bool hideVia = false, int? replyToMsgId = null, long? randomId = null, int? scheduleDate = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendInlineBotResult(){
Peer = peerResolved,
QueryId = queryId,
Id = id,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
HideVia = hideVia,
ReplyToMsgId = replyToMsgId,
RandomId = randomId.Value,
ScheduleDate = scheduleDate,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>> GetMessageEditDataAsync(CatraProto.Client.MTProto.PeerId peer, int id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageEditData(){
Peer = peerResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditMessageAsync(CatraProto.Client.MTProto.PeerId peer, int id, bool noWebpage = false, string? message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase? media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditMessage(){
Peer = peerResolved,
Id = id,
NoWebpage = noWebpage,
Message = message,
Media = media,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>> GetBotCallbackAnswerAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, bool game = false, byte[]? data = null, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase? password = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetBotCallbackAnswer(){
Peer = peerResolved,
MsgId = msgId,
Game = game,
Data = data,
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveDraftAsync(CatraProto.Client.MTProto.PeerId peer, string message, bool noWebpage = false, int? replyToMsgId = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDraft(){
Peer = peerResolved,
Message = message,
NoWebpage = noWebpage,
ReplyToMsgId = replyToMsgId,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetGameScoreAsync(CatraProto.Client.MTProto.PeerId peer, int id, long userId, int score, bool editMessage = false, bool force = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetGameScore(){
Peer = peerResolved,
Id = id,
UserId = userIdResolved,
Score = score,
EditMessage = editMessage,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetInlineGameScoreAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, long userId, int score, bool editMessage = false, bool force = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineGameScore(){
Id = id,
UserId = userIdResolved,
Score = score,
EditMessage = editMessage,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> GetGameHighScoresAsync(CatraProto.Client.MTProto.PeerId peer, int id, long userId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetGameHighScores(){
Peer = peerResolved,
Id = id,
UserId = userIdResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> GetInlineGameHighScoresAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, long userId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineGameHighScores(){
Id = id,
UserId = userIdResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetCommonChatsAsync(long userId, long maxId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetCommonChats(){
UserId = userIdResolved,
MaxId = maxId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> UploadMediaAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadMedia(){
Peer = peerResolved,
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendScreenshotNotificationAsync(CatraProto.Client.MTProto.PeerId peer, int replyToMsgId, long? randomId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScreenshotNotification(){
Peer = peerResolved,
ReplyToMsgId = replyToMsgId,
RandomId = randomId.Value,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetUnreadMentionsAsync(CatraProto.Client.MTProto.PeerId peer, int offsetId, int addOffset, int limit, int maxId, int minId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadMentions(){
Peer = peerResolved,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> ReadMentionsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMentions(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetRecentLocationsAsync(CatraProto.Client.MTProto.PeerId peer, int limit, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentLocations(){
Peer = peerResolved,
Limit = limit,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMultiMediaAsync(CatraProto.Client.MTProto.PeerId peer, List<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> multiMedia, bool silent = false, bool background = false, bool clearDraft = false, bool noforwards = false, int? replyToMsgId = null, int? scheduleDate = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMultiMedia(){
Peer = peerResolved,
MultiMedia = multiMedia,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
Noforwards = noforwards,
ReplyToMsgId = replyToMsgId,
ScheduleDate = scheduleDate,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> UpdatePinnedMessageAsync(CatraProto.Client.MTProto.PeerId peer, int id, bool silent = false, bool unpin = false, bool pmOneside = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdatePinnedMessage(){
Peer = peerResolved,
Id = id,
Silent = silent,
Unpin = unpin,
PmOneside = pmOneside,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendVoteAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, List<byte[]> options, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendVote(){
Peer = peerResolved,
MsgId = msgId,
Options = options,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetPollResultsAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollResults(){
Peer = peerResolved,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>> GetOnlinesAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOnlines(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> EditChatAboutAsync(CatraProto.Client.MTProto.PeerId peer, string about, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAbout(){
Peer = peerResolved,
About = about,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatDefaultBannedRightsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatDefaultBannedRights(){
Peer = peerResolved,
BannedRights = bannedRights,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>> GetSearchCountersAsync(CatraProto.Client.MTProto.PeerId peer, List<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> filters, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchCounters(){
Peer = peerResolved,
Filters = filters,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> RequestUrlAuthAsync(CatraProto.Client.MTProto.PeerId? peer = null, int? msgId = null, int? buttonId = null, string? url = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? peerResolved = null;
if(peer is not null){
var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer.Value);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>.FromError(new PeerNotFoundError(peer.Value.Id, peer.Value.Type));
}
peerResolved = peerToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestUrlAuth(){
Peer = peerResolved,
MsgId = msgId,
ButtonId = buttonId,
Url = url,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> AcceptUrlAuthAsync(bool writeAllowed = false, CatraProto.Client.MTProto.PeerId? peer = null, int? msgId = null, int? buttonId = null, string? url = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? peerResolved = null;
if(peer is not null){
var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer.Value);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>.FromError(new PeerNotFoundError(peer.Value.Id, peer.Value.Type));
}
peerResolved = peerToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptUrlAuth(){
WriteAllowed = writeAllowed,
Peer = peerResolved,
MsgId = msgId,
ButtonId = buttonId,
Url = url,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> HidePeerSettingsBarAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HidePeerSettingsBar(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetScheduledHistoryAsync(CatraProto.Client.MTProto.PeerId peer, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledHistory(){
Peer = peerResolved,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetScheduledMessagesAsync(CatraProto.Client.MTProto.PeerId peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledMessages(){
Peer = peerResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendScheduledMessagesAsync(CatraProto.Client.MTProto.PeerId peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScheduledMessages(){
Peer = peerResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteScheduledMessagesAsync(CatraProto.Client.MTProto.PeerId peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteScheduledMessages(){
Peer = peerResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>> GetPollVotesAsync(CatraProto.Client.MTProto.PeerId peer, int id, int limit, byte[]? option = null, string? offset = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollVotes(){
Peer = peerResolved,
Id = id,
Limit = limit,
Option = option,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetRepliesAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, long hash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetReplies(){
Peer = peerResolved,
MsgId = msgId,
OffsetId = offsetId,
OffsetDate = offsetDate,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>> GetDiscussionMessageAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDiscussionMessage(){
Peer = peerResolved,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReadDiscussionAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, int readMaxId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadDiscussion(){
Peer = peerResolved,
MsgId = msgId,
ReadMaxId = readMaxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> UnpinAllMessagesAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UnpinAllMessages(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase>> InitHistoryImportAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, int mediaCount, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.HistoryImportBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.InitHistoryImport(){
Peer = peerResolved,
File = file,
MediaCount = mediaCount,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> UploadImportedMediaAsync(CatraProto.Client.MTProto.PeerId peer, long importId, string fileName, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadImportedMedia(){
Peer = peerResolved,
ImportId = importId,
FileName = fileName,
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> StartHistoryImportAsync(CatraProto.Client.MTProto.PeerId peer, long importId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartHistoryImport(){
Peer = peerResolved,
ImportId = importId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase>> GetExportedChatInvitesAsync(CatraProto.Client.MTProto.PeerId peer, long adminId, int limit, bool revoked = false, int? offsetDate = null, string? offsetLink = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var adminIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(adminId);
if(adminIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase>.FromError(new PeerNotFoundError(adminId, CatraProto.Client.MTProto.PeerType.User));
}
var adminIdResolved = adminIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetExportedChatInvites(){
Peer = peerResolved,
AdminId = adminIdResolved,
Limit = limit,
Revoked = revoked,
OffsetDate = offsetDate,
OffsetLink = offsetLink,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>> GetExportedChatInviteAsync(CatraProto.Client.MTProto.PeerId peer, string link, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetExportedChatInvite(){
Peer = peerResolved,
Link = link,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>> EditExportedChatInviteAsync(CatraProto.Client.MTProto.PeerId peer, string link, bool revoked = false, int? expireDate = null, int? usageLimit = null, bool? requestNeeded = null, string? title = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditExportedChatInvite(){
Peer = peerResolved,
Link = link,
Revoked = revoked,
ExpireDate = expireDate,
UsageLimit = usageLimit,
RequestNeeded = requestNeeded,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeleteRevokedExportedChatInvitesAsync(CatraProto.Client.MTProto.PeerId peer, long adminId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var adminIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(adminId);
if(adminIdToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(adminId, CatraProto.Client.MTProto.PeerType.User));
}
var adminIdResolved = adminIdToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteRevokedExportedChatInvites(){
Peer = peerResolved,
AdminId = adminIdResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeleteExportedChatInviteAsync(CatraProto.Client.MTProto.PeerId peer, string link, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteExportedChatInvite(){
Peer = peerResolved,
Link = link,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase>> GetAdminsWithInvitesAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAdminsWithInvites(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase>> GetChatInviteImportersAsync(CatraProto.Client.MTProto.PeerId peer, int offsetDate, long offsetUser, int limit, bool requested = false, string? link = null, string? q = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var offsetUserToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(offsetUser);
if(offsetUserToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase>.FromError(new PeerNotFoundError(offsetUser, CatraProto.Client.MTProto.PeerType.User));
}
var offsetUserResolved = offsetUserToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChatInviteImporters(){
Peer = peerResolved,
OffsetDate = offsetDate,
OffsetUser = offsetUserResolved,
Limit = limit,
Requested = requested,
Link = link,
Q = q,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetHistoryTTLAsync(CatraProto.Client.MTProto.PeerId peer, int period, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetHistoryTTL(){
Peer = peerResolved,
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase>> CheckHistoryImportPeerAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckedHistoryImportPeerBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckHistoryImportPeer(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetChatThemeAsync(CatraProto.Client.MTProto.PeerId peer, string emoticon, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetChatTheme(){
Peer = peerResolved,
Emoticon = emoticon,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>> GetMessageReadParticipantsAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<long>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageReadParticipants(){
Peer = peerResolved,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase>> GetSearchResultsCalendarAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int offsetId, int offsetDate, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsCalendarBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchResultsCalendar(){
Peer = peerResolved,
Filter = filter,
OffsetId = offsetId,
OffsetDate = offsetDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase>> GetSearchResultsPositionsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int offsetId, int limit, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchResultsPositions(){
Peer = peerResolved,
Filter = filter,
OffsetId = offsetId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> HideChatJoinRequestAsync(CatraProto.Client.MTProto.PeerId peer, long userId, bool approved = false, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HideChatJoinRequest(){
Peer = peerResolved,
UserId = userIdResolved,
Approved = approved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> HideAllChatJoinRequestsAsync(CatraProto.Client.MTProto.PeerId peer, bool approved = false, string? link = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HideAllChatJoinRequests(){
Peer = peerResolved,
Approved = approved,
Link = link,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleNoForwardsAsync(CatraProto.Client.MTProto.PeerId peer, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleNoForwards(){
Peer = peerResolved,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveDefaultSendAsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.MTProto.PeerId sendAs, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs);
if(sendAsToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(sendAs.Id, sendAs.Type));
}
var sendAsResolved = sendAsToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDefaultSendAs(){
Peer = peerResolved,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendReactionAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, bool big = false, string? reaction = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendReaction(){
Peer = peerResolved,
MsgId = msgId,
Big = big,
Reaction = reaction,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetMessagesReactionsAsync(CatraProto.Client.MTProto.PeerId peer, List<int> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesReactions(){
Peer = peerResolved,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase>> GetMessageReactionsListAsync(CatraProto.Client.MTProto.PeerId peer, int id, int limit, string? reaction = null, string? offset = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageReactionsList(){
Peer = peerResolved,
Id = id,
Limit = limit,
Reaction = reaction,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetChatAvailableReactionsAsync(CatraProto.Client.MTProto.PeerId peer, List<string> availableReactions, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetChatAvailableReactions(){
Peer = peerResolved,
AvailableReactions = availableReactions,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase>> TranslateTextAsync(string toLang, CatraProto.Client.MTProto.PeerId? peer = null, int? msgId = null, string? text = null, string? fromLang = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? peerResolved = null;
if(peer is not null){
var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer.Value);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase>.FromError(new PeerNotFoundError(peer.Value.Id, peer.Value.Type));
}
peerResolved = peerToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslatedTextBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranslateText(){
ToLang = toLang,
Peer = peerResolved,
MsgId = msgId,
Text = text,
FromLang = fromLang,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetUnreadReactionsAsync(CatraProto.Client.MTProto.PeerId peer, int offsetId, int addOffset, int limit, int maxId, int minId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadReactions(){
Peer = peerResolved,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> ReadReactionsAsync(CatraProto.Client.MTProto.PeerId peer, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadReactions(){
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBotBase>> GetAttachMenuBotAsync(long bot, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBotBase>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBotBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachMenuBot(){
Bot = botResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ToggleBotInAttachMenuAsync(long bot, bool enabled, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleBotInAttachMenu(){
Bot = botResolved,
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>> RequestWebViewAsync(CatraProto.Client.MTProto.PeerId peer, long bot, bool fromBotMenu = false, bool silent = false, string? url = null, string? startParam = null, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase? themeParams = null, int? replyToMsgId = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestWebView(){
Peer = peerResolved,
Bot = botResolved,
FromBotMenu = fromBotMenu,
Silent = silent,
Url = url,
StartParam = startParam,
ThemeParams = themeParams,
ReplyToMsgId = replyToMsgId,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ProlongWebViewAsync(CatraProto.Client.MTProto.PeerId peer, long bot, long queryId, bool silent = false, int? replyToMsgId = null, CatraProto.Client.MTProto.PeerId? sendAs = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? sendAsResolved = null;
if(sendAs is not null){
var sendAsToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(sendAs.Value);
if(sendAsToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(sendAs.Value.Id, sendAs.Value.Type));
}
sendAsResolved = sendAsToResolve;
}
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ProlongWebView(){
Peer = peerResolved,
Bot = botResolved,
QueryId = queryId,
Silent = silent,
ReplyToMsgId = replyToMsgId,
SendAs = sendAsResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.SimpleWebViewResultBase>> RequestSimpleWebViewAsync(long bot, string url, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase? themeParams = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.SimpleWebViewResultBase>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.SimpleWebViewResultBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestSimpleWebView(){
Bot = botResolved,
Url = url,
ThemeParams = themeParams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendWebViewDataAsync(long bot, string buttonText, string data, long? randomId = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var botToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(bot);
if(botToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>.FromError(new PeerNotFoundError(bot, CatraProto.Client.MTProto.PeerType.User));
}
var botResolved = botToResolve;
if(randomId is null){
randomId = _client.RandomIdHandler.GetNextId();
}
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendWebViewData(){
Bot = botResolved,
ButtonText = buttonText,
Data = data,
RandomId = randomId.Value,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase>> TranscribeAudioAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribedAudioBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.TranscribeAudio(){
Peer = peerResolved,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> RateTranscribedAudioAsync(CatraProto.Client.MTProto.PeerId peer, int msgId, long transcriptionId, bool good, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RateTranscribedAudio(){
Peer = peerResolved,
MsgId = msgId,
TranscriptionId = transcriptionId,
Good = good,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}