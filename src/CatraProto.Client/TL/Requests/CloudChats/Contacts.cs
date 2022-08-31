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
using CatraProto.Client.TL.Schemas.CloudChats.Contacts;

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Contacts
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Contacts(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<RpcVector<int>>> GetContactIDsAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<int>>(
new RpcVector<int>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetContactIDs(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<ContactStatusBase>>> GetStatusesAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<ContactStatusBase>>(
new RpcVector<ContactStatusBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetStatuses(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ContactsBase>> GetContactsAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ContactsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetContacts(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ImportedContactsBase>> ImportContactsAsync(List<InputContactBase> contacts, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ImportedContactsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ImportContacts(){
Contacts = contacts,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalDeleteContactsAsync(List<InputUserBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteContacts(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeleteByPhonesAsync(List<string> phones, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteByPhones(){
Phones = phones,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalBlockAsync(InputPeerBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new Block(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalUnblockAsync(InputPeerBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new Unblock(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<BlockedBase>> GetBlockedAsync(int offset, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<BlockedBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetBlocked(){
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<FoundBase>> SearchAsync(string q, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<FoundBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new Search(){
Q = q,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ResolvedPeerBase>> ResolveUsernameAsync(string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ResolvedPeerBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResolveUsername(){
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<TopPeersBase>> GetTopPeersAsync(int offset, int limit, long hash, bool correspondents = false, bool botsPm = false, bool botsInline = false, bool phoneCalls = false, bool forwardUsers = false, bool forwardChats = false, bool groups = false, bool channels = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<TopPeersBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetTopPeers(){
Offset = offset,
Limit = limit,
Hash = hash,
Correspondents = correspondents,
BotsPm = botsPm,
BotsInline = botsInline,
PhoneCalls = phoneCalls,
ForwardUsers = forwardUsers,
ForwardChats = forwardChats,
Groups = groups,
Channels = channels,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalResetTopPeerRatingAsync(TopPeerCategoryBase category, InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetTopPeerRating(){
Category = category,
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetSavedAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetSaved(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<SavedContactBase>>> GetSavedAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<SavedContactBase>>(
new RpcVector<SavedContactBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSaved(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ToggleTopPeersAsync(bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ToggleTopPeers(){
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalAddContactAsync(InputUserBase id, string firstName, string lastName, string phone, bool addPhonePrivacyException = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AddContact(){
Id = id,
FirstName = firstName,
LastName = lastName,
Phone = phone,
AddPhonePrivacyException = addPhonePrivacyException,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UpdatesBase>> InternalAcceptContactAsync(InputUserBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AcceptContact(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> GetLocatedAsync(InputGeoPointBase geoPoint, bool background = false, int? selfExpires = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetLocated(){
GeoPoint = geoPoint,
Background = background,
SelfExpires = selfExpires,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> BlockFromRepliesAsync(int msgId, bool deleteMessage = false, bool deleteHistory = false, bool reportSpam = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new BlockFromReplies(){
MsgId = msgId,
DeleteMessage = deleteMessage,
DeleteHistory = deleteHistory,
ReportSpam = reportSpam,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ResolvedPeerBase>> ResolvePhoneAsync(string phone, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ResolvedPeerBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResolvePhone(){
Phone = phone,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> DeleteContactsAsync(List<long> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idResolved = new List<InputUserBase>();
for (var i = 0; i < id.Count; i++){
var idToResolveOut = id[i];
var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(idToResolveOut);
if(idToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(idToResolveOut, PeerType.User));
}
idResolved.Add(idToResolve);
}
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteContacts(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> BlockAsync(PeerId id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(id);
if(idToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(id.Id, id.Type));
}
var idResolved = idToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new Block(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UnblockAsync(PeerId id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(id);
if(idToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(id.Id, id.Type));
}
var idResolved = idToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new Unblock(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetTopPeerRatingAsync(TopPeerCategoryBase category, PeerId peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetTopPeerRating(){
Category = category,
Peer = peerResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> AddContactAsync(long id, string firstName, string lastName, string phone, bool addPhonePrivacyException = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
if(idToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(id, PeerType.User));
}
var idResolved = idToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AddContact(){
Id = idResolved,
FirstName = firstName,
LastName = lastName,
Phone = phone,
AddPhonePrivacyException = addPhonePrivacyException,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> AcceptContactAsync(long id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
if(idToResolve is null) {
return RpcResponse<UpdatesBase>.FromError(new PeerNotFoundError(id, PeerType.User));
}
var idResolved = idToResolve;
var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AcceptContact(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}