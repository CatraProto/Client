using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using CatraProto.Client;
using CatraProto.Client.MTProto.Rpc.RpcErrors.CatraErrors;
using System.Collections.Generic;
using System.Numerics;


namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Users
	{
		
	    private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Users(TelegramClient client, MessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>> GetUsersAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.GetUsers(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase>> GetFullUserAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.GetFullUser(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SetSecureValueErrorsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> errors, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.SetSecureValueErrors(){
Id = id,
Errors = errors,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>> GetUsersAsync(IList<long> id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idResolved = new List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
for (var i = 0; i < id.Count; i++){
var idToResolveOut = id[i];
var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(idToResolveOut);
if(idToResolve is null) {
return RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>.FromError(new CantResolvePeer(idToResolveOut, CatraProto.Client.MTProto.PeerType.User));
}
idResolved.Add(idToResolve);
}
var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.GetUsers(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase>> GetFullUserAsync(long id, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
if(idToResolve is null) {
return RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase>.FromError(new CantResolvePeer(id, CatraProto.Client.MTProto.PeerType.User));
}
var idResolved = idToResolve;
var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.GetFullUser(){
Id = idResolved,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SetSecureValueErrorsAsync(long id, IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> errors, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var idToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(id);
if(idToResolve is null) {
return RpcMessage<bool>.FromError(new CantResolvePeer(id, CatraProto.Client.MTProto.PeerType.User));
}
var idResolved = idToResolve;
var rpcResponse = new RpcMessage<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Users.SetSecureValueErrors(){
Id = idResolved,
Errors = errors,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}