using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using ChatFullBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase;
using MessageViewsBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase;
using StickerSetBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase;
using UpdateDialogFilter = CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFilter;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Messages
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Messages(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<MessagesBase>> GetMessagesAsync(IList<InputMessageBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMessages(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<DialogsBase>> GetDialogsAsync(int offsetDate, int offsetId, InputPeerBase offsetPeer, int limit, int hash, bool excludePinned = true, int? folderId = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<DialogsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDialogs(){
OffsetDate = offsetDate,
OffsetId = offsetId,
OffsetPeer = offsetPeer,
Limit = limit,
Hash = hash,
ExcludePinned = excludePinned,
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetHistoryAsync(InputPeerBase peer, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetHistory(){
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
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> SearchAsync(InputPeerBase peer, string q, MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, int hash, InputPeerBase? fromId = null, int? topMsgId = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new Search(){
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
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedMessagesBase>> ReadHistoryAsync(InputPeerBase peer, int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AffectedMessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReadHistory(){
Peer = peer,
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedHistoryBase>> DeleteHistoryAsync(InputPeerBase peer, int maxId, bool justClear = true, bool revoke = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AffectedHistoryBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DeleteHistory(){
Peer = peer,
MaxId = maxId,
JustClear = justClear,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedMessagesBase>> DeleteMessagesAsync(IList<int> id, bool revoke = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AffectedMessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DeleteMessages(){
Id = id,
Revoke = revoke,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<ReceivedNotifyMessageBase>>> ReceivedMessagesAsync(int maxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<ReceivedNotifyMessageBase>>();
rpcResponse.Response = new RpcVector<ReceivedNotifyMessageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReceivedMessages(){
MaxId = maxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetTypingAsync(InputPeerBase peer, SendMessageActionBase action, int? topMsgId = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetTyping(){
Peer = peer,
Action = action,
TopMsgId = topMsgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendMessageAsync(InputPeerBase peer, string message, long randomId, bool noWebpage = true, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, ReplyMarkupBase? replyMarkup = null, IList<MessageEntityBase>? entities = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendMessage(){
Peer = peer,
Message = message,
RandomId = randomId,
NoWebpage = noWebpage,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
ReplyToMsgId = replyToMsgId,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendMediaAsync(InputPeerBase peer, InputMediaBase media, string message, long randomId, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, ReplyMarkupBase? replyMarkup = null, IList<MessageEntityBase>? entities = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendMedia(){
Peer = peer,
Media = media,
Message = message,
RandomId = randomId,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
ReplyToMsgId = replyToMsgId,
ReplyMarkup = replyMarkup,
Entities = entities,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> ForwardMessagesAsync(InputPeerBase fromPeer, IList<int> id, IList<long> randomId, InputPeerBase toPeer, bool silent = true, bool background = true, bool withMyScore = true, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ForwardMessages(){
FromPeer = fromPeer,
Id = id,
RandomId = randomId,
ToPeer = toPeer,
Silent = silent,
Background = background,
WithMyScore = withMyScore,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReportSpamAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReportSpam(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<PeerSettingsBase>> GetPeerSettingsAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<PeerSettingsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPeerSettings(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReportAsync(InputPeerBase peer, IList<int> id, ReportReasonBase reason, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new Report(){
Peer = peer,
Id = id,
Reason = reason,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetChatsAsync(IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ChatsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetChats(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatFullBase>> GetFullChatAsync(int chatId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ChatFullBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetFullChat(){
ChatId = chatId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditChatTitleAsync(int chatId, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditChatTitle(){
ChatId = chatId,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditChatPhotoAsync(int chatId, InputChatPhotoBase photo, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditChatPhoto(){
ChatId = chatId,
Photo = photo,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> AddChatUserAsync(int chatId, InputUserBase userId, int fwdLimit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new AddChatUser(){
ChatId = chatId,
UserId = userId,
FwdLimit = fwdLimit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> DeleteChatUserAsync(int chatId, InputUserBase userId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DeleteChatUser(){
ChatId = chatId,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> CreateChatAsync(IList<InputUserBase> users, string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new CreateChat(){
Users = users,
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<DhConfigBase>> GetDhConfigAsync(int version, int randomLength, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<DhConfigBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDhConfig(){
Version = version,
RandomLength = randomLength,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<EncryptedChatBase>> RequestEncryptionAsync(InputUserBase userId, int randomId, byte[] gA, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<EncryptedChatBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new RequestEncryption(){
UserId = userId,
RandomId = randomId,
GA = gA,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<EncryptedChatBase>> AcceptEncryptionAsync(InputEncryptedChatBase peer, byte[] gB, long keyFingerprint, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<EncryptedChatBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new AcceptEncryption(){
Peer = peer,
GB = gB,
KeyFingerprint = keyFingerprint,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> DiscardEncryptionAsync(int chatId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DiscardEncryption(){
ChatId = chatId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetEncryptedTypingAsync(InputEncryptedChatBase peer, bool typing, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetEncryptedTyping(){
Peer = peer,
Typing = typing,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReadEncryptedHistoryAsync(InputEncryptedChatBase peer, int maxDate, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReadEncryptedHistory(){
Peer = peer,
MaxDate = maxDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<SentEncryptedMessageBase>> SendEncryptedAsync(InputEncryptedChatBase peer, long randomId, byte[] data, bool silent = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<SentEncryptedMessageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendEncrypted(){
Peer = peer,
RandomId = randomId,
Data = data,
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<SentEncryptedMessageBase>> SendEncryptedFileAsync(InputEncryptedChatBase peer, long randomId, byte[] data, InputEncryptedFileBase file, bool silent = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<SentEncryptedMessageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendEncryptedFile(){
Peer = peer,
RandomId = randomId,
Data = data,
File = file,
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<SentEncryptedMessageBase>> SendEncryptedServiceAsync(InputEncryptedChatBase peer, long randomId, byte[] data, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<SentEncryptedMessageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendEncryptedService(){
Peer = peer,
RandomId = randomId,
Data = data,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<long>>> ReceivedQueueAsync(int maxQts, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<long>>();
rpcResponse.Response = new RpcVector<long>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReceivedQueue(){
MaxQts = maxQts,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReportEncryptedSpamAsync(InputEncryptedChatBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReportEncryptedSpam(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedMessagesBase>> ReadMessageContentsAsync(IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AffectedMessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReadMessageContents(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickersBase>> GetStickersAsync(string emoticon, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<StickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetStickers(){
Emoticon = emoticon,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AllStickersBase>> GetAllStickersAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AllStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAllStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessageMediaBase>> GetWebPagePreviewAsync(string message, IList<MessageEntityBase>? entities = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessageMediaBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetWebPagePreview(){
Message = message,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ExportedChatInviteBase>> ExportChatInviteAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ExportedChatInviteBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ExportChatInvite(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatInviteBase>> CheckChatInviteAsync(string hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ChatInviteBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new CheckChatInvite(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> ImportChatInviteAsync(string hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ImportChatInvite(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickerSetBase>> GetStickerSetAsync(InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<StickerSetBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetStickerSet(){
Stickerset = stickerset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickerSetInstallResultBase>> InstallStickerSetAsync(InputStickerSetBase stickerset, bool archived, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<StickerSetInstallResultBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InstallStickerSet(){
Stickerset = stickerset,
Archived = archived,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UninstallStickerSetAsync(InputStickerSetBase stickerset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UninstallStickerSet(){
Stickerset = stickerset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> StartBotAsync(InputUserBase bot, InputPeerBase peer, long randomId, string startParam, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new StartBot(){
Bot = bot,
Peer = peer,
RandomId = randomId,
StartParam = startParam,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessageViewsBase>> GetMessagesViewsAsync(InputPeerBase peer, IList<int> id, bool increment, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessageViewsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMessagesViews(){
Peer = peer,
Id = id,
Increment = increment,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> EditChatAdminAsync(int chatId, InputUserBase userId, bool isAdmin, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditChatAdmin(){
ChatId = chatId,
UserId = userId,
IsAdmin = isAdmin,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> MigrateChatAsync(int chatId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new MigrateChat(){
ChatId = chatId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> SearchGlobalAsync(string q, MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, InputPeerBase offsetPeer, int offsetId, int limit, int? folderId = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SearchGlobal(){
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
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReorderStickerSetsAsync(IList<long> order, bool masks = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReorderStickerSets(){
Order = order,
Masks = masks,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<DocumentBase>> GetDocumentByHashAsync(byte[] sha256, int size, string mimeType, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<DocumentBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDocumentByHash(){
Sha256 = sha256,
Size = size,
MimeType = mimeType,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<SavedGifsBase>> GetSavedGifsAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<SavedGifsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetSavedGifs(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveGifAsync(InputDocumentBase id, bool unsave, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SaveGif(){
Id = id,
Unsave = unsave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<BotResultsBase>> GetInlineBotResultsAsync(InputUserBase bot, InputPeerBase peer, string query, string offset, InputGeoPointBase? geoPoint = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<BotResultsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetInlineBotResults(){
Bot = bot,
Peer = peer,
Query = query,
Offset = offset,
GeoPoint = geoPoint,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetInlineBotResultsAsync(long queryId, IList<InputBotInlineResultBase> results, int cacheTime, bool gallery = true, bool pprivate = true, string? nextOffset = null, InlineBotSwitchPMBase? switchPm = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetInlineBotResults(){
QueryId = queryId,
Results = results,
CacheTime = cacheTime,
Gallery = gallery,
Private = pprivate,
NextOffset = nextOffset,
SwitchPm = switchPm,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendInlineBotResultAsync(InputPeerBase peer, long randomId, long queryId, string id, bool silent = true, bool background = true, bool clearDraft = true, bool hideVia = true, int? replyToMsgId = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendInlineBotResult(){
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
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessageEditDataBase>> GetMessageEditDataAsync(InputPeerBase peer, int id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessageEditDataBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMessageEditData(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditMessageAsync(InputPeerBase peer, int id, bool noWebpage = true, string? message = null, InputMediaBase? media = null, ReplyMarkupBase? replyMarkup = null, IList<MessageEntityBase>? entities = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditMessage(){
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
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> EditInlineBotMessageAsync(InputBotInlineMessageIDBase id, bool noWebpage = true, string? message = null, InputMediaBase? media = null, ReplyMarkupBase? replyMarkup = null, IList<MessageEntityBase>? entities = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditInlineBotMessage(){
Id = id,
NoWebpage = noWebpage,
Message = message,
Media = media,
ReplyMarkup = replyMarkup,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<BotCallbackAnswerBase>> GetBotCallbackAnswerAsync(InputPeerBase peer, int msgId, bool game = true, byte[]? data = null, InputCheckPasswordSRPBase? password = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<BotCallbackAnswerBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetBotCallbackAnswer(){
Peer = peer,
MsgId = msgId,
Game = game,
Data = data,
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetBotCallbackAnswerAsync(long queryId, int cacheTime, bool alert = true, string? message = null, string? url = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetBotCallbackAnswer(){
QueryId = queryId,
CacheTime = cacheTime,
Alert = alert,
Message = message,
Url = url,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<PeerDialogsBase>> GetPeerDialogsAsync(IList<InputDialogPeerBase> peers, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<PeerDialogsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPeerDialogs(){
Peers = peers,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveDraftAsync(InputPeerBase peer, string message, bool noWebpage = true, int? replyToMsgId = null, IList<MessageEntityBase>? entities = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SaveDraft(){
Peer = peer,
Message = message,
NoWebpage = noWebpage,
ReplyToMsgId = replyToMsgId,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> GetAllDraftsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAllDrafts(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<FeaturedStickersBase>> GetFeaturedStickersAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<FeaturedStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetFeaturedStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReadFeaturedStickersAsync(IList<long> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReadFeaturedStickers(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RecentStickersBase>> GetRecentStickersAsync(int hash, bool attached = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RecentStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetRecentStickers(){
Hash = hash,
Attached = attached,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveRecentStickerAsync(InputDocumentBase id, bool unsave, bool attached = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SaveRecentSticker(){
Id = id,
Unsave = unsave,
Attached = attached,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ClearRecentStickersAsync(bool attached = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ClearRecentStickers(){
Attached = attached,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ArchivedStickersBase>> GetArchivedStickersAsync(long offsetId, int limit, bool masks = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ArchivedStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetArchivedStickers(){
OffsetId = offsetId,
Limit = limit,
Masks = masks,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AllStickersBase>> GetMaskStickersAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AllStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMaskStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<StickerSetCoveredBase>>> GetAttachedStickersAsync(InputStickeredMediaBase media, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<StickerSetCoveredBase>>();
rpcResponse.Response = new RpcVector<StickerSetCoveredBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAttachedStickers(){
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SetGameScoreAsync(InputPeerBase peer, int id, InputUserBase userId, int score, bool editMessage = true, bool force = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetGameScore(){
Peer = peer,
Id = id,
UserId = userId,
Score = score,
EditMessage = editMessage,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetInlineGameScoreAsync(InputBotInlineMessageIDBase id, InputUserBase userId, int score, bool editMessage = true, bool force = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetInlineGameScore(){
Id = id,
UserId = userId,
Score = score,
EditMessage = editMessage,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<HighScoresBase>> GetGameHighScoresAsync(InputPeerBase peer, int id, InputUserBase userId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<HighScoresBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetGameHighScores(){
Peer = peer,
Id = id,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<HighScoresBase>> GetInlineGameHighScoresAsync(InputBotInlineMessageIDBase id, InputUserBase userId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<HighScoresBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetInlineGameHighScores(){
Id = id,
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetCommonChatsAsync(InputUserBase userId, int maxId, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ChatsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetCommonChats(){
UserId = userId,
MaxId = maxId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatsBase>> GetAllChatsAsync(IList<int> exceptIds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ChatsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAllChats(){
ExceptIds = exceptIds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<WebPageBase>> GetWebPageAsync(string url, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<WebPageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetWebPage(){
Url = url,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ToggleDialogPinAsync(InputDialogPeerBase peer, bool pinned = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ToggleDialogPin(){
Peer = peer,
Pinned = pinned,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReorderPinnedDialogsAsync(int folderId, IList<InputDialogPeerBase> order, bool force = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReorderPinnedDialogs(){
FolderId = folderId,
Order = order,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<PeerDialogsBase>> GetPinnedDialogsAsync(int folderId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<PeerDialogsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPinnedDialogs(){
FolderId = folderId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetBotShippingResultsAsync(long queryId, string? error = null, IList<ShippingOptionBase>? shippingOptions = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetBotShippingResults(){
QueryId = queryId,
Error = error,
ShippingOptions = shippingOptions,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetBotPrecheckoutResultsAsync(long queryId, bool success = true, string? error = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetBotPrecheckoutResults(){
QueryId = queryId,
Success = success,
Error = error,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessageMediaBase>> UploadMediaAsync(InputPeerBase peer, InputMediaBase media, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessageMediaBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UploadMedia(){
Peer = peer,
Media = media,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendScreenshotNotificationAsync(InputPeerBase peer, int replyToMsgId, long randomId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendScreenshotNotification(){
Peer = peer,
ReplyToMsgId = replyToMsgId,
RandomId = randomId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<FavedStickersBase>> GetFavedStickersAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<FavedStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetFavedStickers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> FaveStickerAsync(InputDocumentBase id, bool unfave, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new FaveSticker(){
Id = id,
Unfave = unfave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetUnreadMentionsAsync(InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetUnreadMentions(){
Peer = peer,
OffsetId = offsetId,
AddOffset = addOffset,
Limit = limit,
MaxId = maxId,
MinId = minId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedHistoryBase>> ReadMentionsAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AffectedHistoryBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReadMentions(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetRecentLocationsAsync(InputPeerBase peer, int limit, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetRecentLocations(){
Peer = peer,
Limit = limit,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendMultiMediaAsync(InputPeerBase peer, IList<InputSingleMediaBase> multiMedia, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, int? scheduleDate = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendMultiMedia(){
Peer = peer,
MultiMedia = multiMedia,
Silent = silent,
Background = background,
ClearDraft = clearDraft,
ReplyToMsgId = replyToMsgId,
ScheduleDate = scheduleDate,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<EncryptedFileBase>> UploadEncryptedFileAsync(InputEncryptedChatBase peer, InputEncryptedFileBase file, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<EncryptedFileBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UploadEncryptedFile(){
Peer = peer,
File = file,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<FoundStickerSetsBase>> SearchStickerSetsAsync(string q, int hash, bool excludeFeatured = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<FoundStickerSetsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SearchStickerSets(){
Q = q,
Hash = hash,
ExcludeFeatured = excludeFeatured,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<MessageRangeBase>>> GetSplitRangesAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<MessageRangeBase>>();
rpcResponse.Response = new RpcVector<MessageRangeBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetSplitRanges(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> MarkDialogUnreadAsync(InputDialogPeerBase peer, bool unread = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new MarkDialogUnread(){
Peer = peer,
Unread = unread,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<DialogPeerBase>>> GetDialogUnreadMarksAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<DialogPeerBase>>();
rpcResponse.Response = new RpcVector<DialogPeerBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDialogUnreadMarks(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ClearAllDraftsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ClearAllDrafts(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> UpdatePinnedMessageAsync(InputPeerBase peer, int id, bool silent = true, bool unpin = true, bool pmOneside = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UpdatePinnedMessage(){
Peer = peer,
Id = id,
Silent = silent,
Unpin = unpin,
PmOneside = pmOneside,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendVoteAsync(InputPeerBase peer, int msgId, IList<byte[]> options, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendVote(){
Peer = peer,
MsgId = msgId,
Options = options,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> GetPollResultsAsync(InputPeerBase peer, int msgId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPollResults(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ChatOnlinesBase>> GetOnlinesAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ChatOnlinesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetOnlines(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StatsURLBase>> GetStatsURLAsync(InputPeerBase peer, string pparams, bool dark = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<StatsURLBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetStatsURL(){
Peer = peer,
Params = pparams,
Dark = dark,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> EditChatAboutAsync(InputPeerBase peer, string about, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditChatAbout(){
Peer = peer,
About = about,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> EditChatDefaultBannedRightsAsync(InputPeerBase peer, ChatBannedRightsBase bannedRights, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditChatDefaultBannedRights(){
Peer = peer,
BannedRights = bannedRights,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<EmojiKeywordsDifferenceBase>> GetEmojiKeywordsAsync(string langCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<EmojiKeywordsDifferenceBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetEmojiKeywords(){
LangCode = langCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<EmojiKeywordsDifferenceBase>> GetEmojiKeywordsDifferenceAsync(string langCode, int fromVersion, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<EmojiKeywordsDifferenceBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetEmojiKeywordsDifference(){
LangCode = langCode,
FromVersion = fromVersion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<EmojiLanguageBase>>> GetEmojiKeywordsLanguagesAsync(IList<string> langCodes, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<EmojiLanguageBase>>();
rpcResponse.Response = new RpcVector<EmojiLanguageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetEmojiKeywordsLanguages(){
LangCodes = langCodes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<EmojiURLBase>> GetEmojiURLAsync(string langCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<EmojiURLBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetEmojiURL(){
LangCode = langCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<SearchCounterBase>>> GetSearchCountersAsync(InputPeerBase peer, IList<MessagesFilterBase> filters, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<SearchCounterBase>>();
rpcResponse.Response = new RpcVector<SearchCounterBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetSearchCounters(){
Peer = peer,
Filters = filters,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UrlAuthResultBase>> RequestUrlAuthAsync(InputPeerBase peer, int msgId, int buttonId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UrlAuthResultBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new RequestUrlAuth(){
Peer = peer,
MsgId = msgId,
ButtonId = buttonId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UrlAuthResultBase>> AcceptUrlAuthAsync(InputPeerBase peer, int msgId, int buttonId, bool writeAllowed = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UrlAuthResultBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new AcceptUrlAuth(){
Peer = peer,
MsgId = msgId,
ButtonId = buttonId,
WriteAllowed = writeAllowed,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> HidePeerSettingsBarAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new HidePeerSettingsBar(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetScheduledHistoryAsync(InputPeerBase peer, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetScheduledHistory(){
Peer = peer,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetScheduledMessagesAsync(InputPeerBase peer, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetScheduledMessages(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SendScheduledMessagesAsync(InputPeerBase peer, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SendScheduledMessages(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> DeleteScheduledMessagesAsync(InputPeerBase peer, IList<int> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DeleteScheduledMessages(){
Peer = peer,
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<VotesListBase>> GetPollVotesAsync(InputPeerBase peer, int id, int limit, byte[]? option = null, string? offset = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<VotesListBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPollVotes(){
Peer = peer,
Id = id,
Limit = limit,
Option = option,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ToggleStickerSetsAsync(IList<InputStickerSetBase> stickersets, bool uninstall = true, bool archive = true, bool unarchive = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ToggleStickerSets(){
Stickersets = stickersets,
Uninstall = uninstall,
Archive = archive,
Unarchive = unarchive,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<DialogFilterBase>>> GetDialogFiltersAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<DialogFilterBase>>();
rpcResponse.Response = new RpcVector<DialogFilterBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDialogFilters(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<DialogFilterSuggestedBase>>> GetSuggestedDialogFiltersAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RpcVector<DialogFilterSuggestedBase>>();
rpcResponse.Response = new RpcVector<DialogFilterSuggestedBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetSuggestedDialogFilters(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdateDialogFilterAsync(int id, DialogFilterBase? filter = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UpdateDialogFilter(){
Id = id,
Filter = filter,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdateDialogFiltersOrderAsync(IList<int> order, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UpdateDialogFiltersOrder(){
Order = order,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<FeaturedStickersBase>> GetOldFeaturedStickersAsync(int offset, int limit, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<FeaturedStickersBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetOldFeaturedStickers(){
Offset = offset,
Limit = limit,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetRepliesAsync(InputPeerBase peer, int msgId, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetReplies(){
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
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<DiscussionMessageBase>> GetDiscussionMessageAsync(InputPeerBase peer, int msgId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<DiscussionMessageBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDiscussionMessage(){
Peer = peer,
MsgId = msgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReadDiscussionAsync(InputPeerBase peer, int msgId, int readMaxId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ReadDiscussion(){
Peer = peer,
MsgId = msgId,
ReadMaxId = readMaxId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AffectedHistoryBase>> UnpinAllMessagesAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AffectedHistoryBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new UnpinAllMessages(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}