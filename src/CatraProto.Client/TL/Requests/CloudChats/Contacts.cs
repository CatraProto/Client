using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Contacts;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Contacts
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Contacts(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<RpcVector<int>>> GetContactIDsAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<int>>();
			rpcResponse.Response = new RpcVector<int>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetContactIDs
			{
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<ContactStatusBase>>> GetStatusesAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<ContactStatusBase>>();
			rpcResponse.Response = new RpcVector<ContactStatusBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetStatuses
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ContactsBase>> GetContactsAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ContactsBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetContacts
			{
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ImportedContactsBase>> ImportContactsAsync(IList<InputContactBase> contacts, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ImportedContactsBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new ImportContacts
			{
Contacts = contacts,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> DeleteContactsAsync(IList<InputUserBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new DeleteContacts
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> DeleteByPhonesAsync(IList<string> phones, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DeleteByPhones
{
Phones = phones,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> BlockAsync(InputPeerBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new Block
{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UnblockAsync(InputPeerBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new Unblock
{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<BlockedBase>> GetBlockedAsync(int offset, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<BlockedBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetBlocked
			{
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<FoundBase>> SearchAsync(string q, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FoundBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new Search
			{
Q = q,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<ResolvedPeerBase>> ResolveUsernameAsync(string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ResolvedPeerBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new ResolveUsername
			{
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<TopPeersBase>> GetTopPeersAsync(int offset, int limit, int hash, bool correspondents = true, bool botsPm = true, bool botsInline = true, bool phoneCalls = true, bool forwardUsers = true, bool forwardChats = true, bool groups = true, bool channels = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<TopPeersBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetTopPeers
			{
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
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetTopPeerRatingAsync(TopPeerCategoryBase category, InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ResetTopPeerRating
{
Category = category,
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetSavedAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ResetSaved
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<SavedContactBase>>> GetSavedAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<SavedContactBase>>();
			rpcResponse.Response = new RpcVector<SavedContactBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetSaved
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ToggleTopPeersAsync(bool enabled, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new ToggleTopPeers
{
Enabled = enabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> AddContactAsync(InputUserBase id, string firstName, string lastName, string phone, bool addPhonePrivacyException = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new AddContact
			{
Id = id,
FirstName = firstName,
LastName = lastName,
Phone = phone,
AddPhonePrivacyException = addPhonePrivacyException,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> AcceptContactAsync(InputUserBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new AcceptContact
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> GetLocatedAsync(InputGeoPointBase geoPoint, bool background = true, int? selfExpires = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new GetLocated
			{
GeoPoint = geoPoint,
Background = background,
SelfExpires = selfExpires,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> BlockFromRepliesAsync(int msgId, bool deleteMessage = true, bool deleteHistory = true, bool reportSpam = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new BlockFromReplies
			{
MsgId = msgId,
DeleteMessage = deleteMessage,
DeleteHistory = deleteHistory,
ReportSpam = reportSpam,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}