using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace CatraProto.Client.TL.Requests
{
	public partial class CloudChatsApi
	{
		
public CatraProto.Client.TL.Requests.CloudChats.Auth Auth { get; }
public CatraProto.Client.TL.Requests.CloudChats.Account Account { get; }
public CatraProto.Client.TL.Requests.CloudChats.Users Users { get; }
public CatraProto.Client.TL.Requests.CloudChats.Contacts Contacts { get; }
public CatraProto.Client.TL.Requests.CloudChats.Messages Messages { get; }
public CatraProto.Client.TL.Requests.CloudChats.Updates Updates { get; }
public CatraProto.Client.TL.Requests.CloudChats.Photos Photos { get; }
public CatraProto.Client.TL.Requests.CloudChats.Upload Upload { get; }
public CatraProto.Client.TL.Requests.CloudChats.Help Help { get; }
public CatraProto.Client.TL.Requests.CloudChats.Channels Channels { get; }
public CatraProto.Client.TL.Requests.CloudChats.Bots Bots { get; }
public CatraProto.Client.TL.Requests.CloudChats.Payments Payments { get; }
public CatraProto.Client.TL.Requests.CloudChats.Stickers Stickers { get; }
public CatraProto.Client.TL.Requests.CloudChats.Phone Phone { get; }
public CatraProto.Client.TL.Requests.CloudChats.Langpack Langpack { get; }
public CatraProto.Client.TL.Requests.CloudChats.Folders Folders { get; }
public CatraProto.Client.TL.Requests.CloudChats.Stats Stats { get; }
	    private readonly MessagesQueue _messagesQueue;
	    internal CloudChatsApi(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
Auth = new CatraProto.Client.TL.Requests.CloudChats.Auth(messagesQueue);
Account = new CatraProto.Client.TL.Requests.CloudChats.Account(messagesQueue);
Users = new CatraProto.Client.TL.Requests.CloudChats.Users(messagesQueue);
Contacts = new CatraProto.Client.TL.Requests.CloudChats.Contacts(messagesQueue);
Messages = new CatraProto.Client.TL.Requests.CloudChats.Messages(messagesQueue);
Updates = new CatraProto.Client.TL.Requests.CloudChats.Updates(messagesQueue);
Photos = new CatraProto.Client.TL.Requests.CloudChats.Photos(messagesQueue);
Upload = new CatraProto.Client.TL.Requests.CloudChats.Upload(messagesQueue);
Help = new CatraProto.Client.TL.Requests.CloudChats.Help(messagesQueue);
Channels = new CatraProto.Client.TL.Requests.CloudChats.Channels(messagesQueue);
Bots = new CatraProto.Client.TL.Requests.CloudChats.Bots(messagesQueue);
Payments = new CatraProto.Client.TL.Requests.CloudChats.Payments(messagesQueue);
Stickers = new CatraProto.Client.TL.Requests.CloudChats.Stickers(messagesQueue);
Phone = new CatraProto.Client.TL.Requests.CloudChats.Phone(messagesQueue);
Langpack = new CatraProto.Client.TL.Requests.CloudChats.Langpack(messagesQueue);
Folders = new CatraProto.Client.TL.Requests.CloudChats.Folders(messagesQueue);
Stats = new CatraProto.Client.TL.Requests.CloudChats.Stats(messagesQueue);
	    }
	    
	    public async Task<RpcMessage<IObject>> InvokeAfterMsgAsync(long msgId, IObject query, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsg(){
MsgId = msgId,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<IObject>> InvokeAfterMsgsAsync(IList<long> msgIds, IObject query, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsgs(){
MsgIds = msgIds,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<IObject>> InitConnectionAsync(int apiId, string deviceModel, string systemVersion, string appVersion, string systemLangCode, string langPack, string langCode, IObject query, CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase? proxy = null, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase? pparams = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InitConnection(){
ApiId = apiId,
DeviceModel = deviceModel,
SystemVersion = systemVersion,
AppVersion = appVersion,
SystemLangCode = systemLangCode,
LangPack = langPack,
LangCode = langCode,
Query = query,
Proxy = proxy,
Params = pparams,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<IObject>> InvokeWithLayerAsync(int layer, IObject query, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithLayer(){
Layer = layer,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<IObject>> InvokeWithoutUpdatesAsync(IObject query, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithoutUpdates(){
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<IObject>> InvokeWithMessagesRangeAsync(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase range, IObject query, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithMessagesRange(){
Range = range,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<IObject>> InvokeWithTakeoutAsync(long takeoutId, IObject query, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithTakeout(){
TakeoutId = takeoutId,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}