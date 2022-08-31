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


namespace CatraProto.Client.TL.Requests
{
	public partial class MTProtoApi
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal MTProtoApi(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>> ReqPqAsync(System.Numerics.BigInteger nonce, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = false;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.ReqPq(){
Nonce = nonce,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>> ReqPqMultiAsync(System.Numerics.BigInteger nonce, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = false;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.ReqPqMulti(){
Nonce = nonce,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase>> ReqDHParamsAsync(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] p, byte[] q, long publicKeyFingerprint, byte[] encryptedData, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = false;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.ReqDHParams(){
Nonce = nonce,
ServerNonce = serverNonce,
P = p,
Q = q,
PublicKeyFingerprint = publicKeyFingerprint,
EncryptedData = encryptedData,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase>> SetClientDHParamsAsync(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] encryptedData, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = false;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.SetClientDHParams(){
Nonce = nonce,
ServerNonce = serverNonce,
EncryptedData = encryptedData,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase>> RpcDropAnswerAsync(long reqMsgId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswer(){
ReqMsgId = reqMsgId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase>> GetFutureSaltsAsync(int num, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.GetFutureSalts(){
Num = num,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.PongBase>> PingAsync(long pingId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.PongBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.Ping(){
PingId = pingId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.PongBase>> PingDelayDisconnectAsync(long pingId, int disconnectDelay, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.PongBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.PingDelayDisconnect(){
PingId = pingId,
DisconnectDelay = disconnectDelay,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase>> DestroySessionAsync(long sessionId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.DestroySession(){
SessionId = sessionId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.HttpWaitBase>> HttpWaitAsync(int maxDelay, int waitAfter, int maxWait, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.HttpWaitBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.HttpWait(){
MaxDelay = maxDelay,
WaitAfter = waitAfter,
MaxWait = maxWait,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase>> MsgsStateReqAsync(List<long> msgIds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.MsgsStateReq(){
MsgIds = msgIds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase>> MsgResendReqAsync(List<long> msgIds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.MsgResendReq(){
MsgIds = msgIds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase>> MsgResendAnsReqAsync(List<long> msgIds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.MTProto.MsgResendAnsReq(){
MsgIds = msgIds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}