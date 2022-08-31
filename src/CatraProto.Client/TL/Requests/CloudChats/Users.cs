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
using CatraProto.Client.TL.Schemas.CloudChats.Users;
using UserFullBase = CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase;

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Users
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Users(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    internal async Task<RpcResponse<RpcVector<UserBase>>> InternalGetUsersAsync(List<InputUserBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<UserBase>>(
new RpcVector<UserBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetUsers(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UserFullBase>> InternalGetFullUserAsync(InputUserBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UserFullBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetFullUser(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalSetSecureValueErrorsAsync(InputUserBase id, List<SecureValueErrorBase> errors, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetSecureValueErrors(){
Id = id,
Errors = errors,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<RpcVector<UserBase>>> InternalGetUsersAsync(List<long> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idResolved = new List<InputUserBase>();
for (var i = 0; i < id.Count; i++){
var idToResolveOut = id[i];
var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(idToResolveOut);
if(idToResolve is null) {
return RpcResponse<RpcVector<UserBase>>.FromError(new PeerNotFoundError(idToResolveOut, PeerType.User));
}
idResolved.Add(idToResolve);
}
var rpcResponse = new RpcResponse<RpcVector<UserBase>>(
new RpcVector<UserBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetUsers(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<UserFullBase>> InternalGetFullUserAsync(long id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
if(idToResolve is null) {
return RpcResponse<UserFullBase>.FromError(new PeerNotFoundError(id, PeerType.User));
}
var idResolved = idToResolve;
var rpcResponse = new RpcResponse<UserFullBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetFullUser(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetSecureValueErrorsAsync(long id, List<SecureValueErrorBase> errors, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
if(idToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(id, PeerType.User));
}
var idResolved = idToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetSecureValueErrors(){
Id = idResolved,
Errors = errors,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}