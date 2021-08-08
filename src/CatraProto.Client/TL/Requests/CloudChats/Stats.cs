using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.TL.Schemas.CloudChats.Stats;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Stats
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Stats(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<BroadcastStatsBase>> GetBroadcastStatsAsync(InputChannelBase channel, bool dark = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<BroadcastStatsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetBroadcastStats(){
Channel = channel,
Dark = dark,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StatsGraphBase>> LoadAsyncGraphAsync(string token, long? x = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<StatsGraphBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new LoadAsyncGraph(){
Token = token,
X = x,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MegagroupStatsBase>> GetMegagroupStatsAsync(InputChannelBase channel, bool dark = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MegagroupStatsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMegagroupStats(){
Channel = channel,
Dark = dark,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessagesBase>> GetMessagePublicForwardsAsync(InputChannelBase channel, int msgId, int offsetRate, InputPeerBase offsetPeer, int offsetId, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessagesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMessagePublicForwards(){
Channel = channel,
MsgId = msgId,
OffsetRate = offsetRate,
OffsetPeer = offsetPeer,
OffsetId = offsetId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<MessageStatsBase>> GetMessageStatsAsync(InputChannelBase channel, int msgId, bool dark = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<MessageStatsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetMessageStats(){
Channel = channel,
MsgId = msgId,
Dark = dark,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}