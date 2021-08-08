using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Requests.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Requests
{
	public partial class CloudChatsApi
	{
		
public Auth Auth { get; }
public Account Account { get; }
public Users Users { get; }
public Contacts Contacts { get; }
public Messages Messages { get; }
public Updates Updates { get; }
public Photos Photos { get; }
public Upload Upload { get; }
public Help Help { get; }
public Channels Channels { get; }
public Bots Bots { get; }
public Payments Payments { get; }
public Stickers Stickers { get; }
public Phone Phone { get; }
public Langpack Langpack { get; }
public Folders Folders { get; }
public Stats Stats { get; }
	    private readonly MessagesQueue _messagesQueue;
	    internal CloudChatsApi(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
Auth = new Auth(messagesQueue);
Account = new Account(messagesQueue);
Users = new Users(messagesQueue);
Contacts = new Contacts(messagesQueue);
Messages = new Messages(messagesQueue);
Updates = new Updates(messagesQueue);
Photos = new Photos(messagesQueue);
Upload = new Upload(messagesQueue);
Help = new Help(messagesQueue);
Channels = new Channels(messagesQueue);
Bots = new Bots(messagesQueue);
Payments = new Payments(messagesQueue);
Stickers = new Stickers(messagesQueue);
Phone = new Phone(messagesQueue);
Langpack = new Langpack(messagesQueue);
Folders = new Folders(messagesQueue);
Stats = new Stats(messagesQueue);
	    }

	    public async Task<RpcMessage<IObject>> InvokeAfterMsgAsync(long msgId, IObject query, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InvokeAfterMsg(){
MsgId = msgId,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<IObject>> InvokeAfterMsgsAsync(IList<long> msgIds, IObject query, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InvokeAfterMsgs(){
MsgIds = msgIds,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<IObject>> InitConnectionAsync(int apiId, string deviceModel, string systemVersion, string appVersion, string systemLangCode, string langPack, string langCode, IObject query, InputClientProxyBase? proxy = null, JSONValueBase? pparams = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InitConnection(){
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

	    public async Task<RpcMessage<IObject>> InvokeWithLayerAsync(int layer, IObject query, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InvokeWithLayer(){
Layer = layer,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<IObject>> InvokeWithoutUpdatesAsync(IObject query, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InvokeWithoutUpdates(){
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<IObject>> InvokeWithMessagesRangeAsync(MessageRangeBase range, IObject query, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InvokeWithMessagesRange(){
Range = range,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<IObject>> InvokeWithTakeoutAsync(long takeoutId, IObject query, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<IObject>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new InvokeWithTakeout(){
TakeoutId = takeoutId,
Query = query,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}