using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Phone;
using PhoneCallBase = CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Phone
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Phone(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<DataJSONBase>> GetCallConfigAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DataJSONBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetCallConfig
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PhoneCallBase>> RequestCallAsync(InputUserBase userId, int randomId, byte[] gAHash, PhoneCallProtocolBase protocol, bool video = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhoneCallBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new RequestCall
			{
UserId = userId,
RandomId = randomId,
GAHash = gAHash,
Protocol = protocol,
Video = video,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PhoneCallBase>> AcceptCallAsync(InputPhoneCallBase peer, byte[] gB, PhoneCallProtocolBase protocol, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhoneCallBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new AcceptCall
			{
Peer = peer,
GB = gB,
Protocol = protocol,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PhoneCallBase>> ConfirmCallAsync(InputPhoneCallBase peer, byte[] gA, long keyFingerprint, PhoneCallProtocolBase protocol, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhoneCallBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new ConfirmCall
			{
Peer = peer,
GA = gA,
KeyFingerprint = keyFingerprint,
Protocol = protocol,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReceivedCallAsync(InputPhoneCallBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ReceivedCall
{
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> DiscardCallAsync(InputPhoneCallBase peer, int duration, PhoneCallDiscardReasonBase reason, long connectionId, bool video = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new DiscardCall
			{
Peer = peer,
Duration = duration,
Reason = reason,
ConnectionId = connectionId,
Video = video,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> SetCallRatingAsync(InputPhoneCallBase peer, int rating, string comment, bool userInitiative = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SetCallRating
			{
Peer = peer,
Rating = rating,
Comment = comment,
UserInitiative = userInitiative,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveCallDebugAsync(InputPhoneCallBase peer, DataJSONBase debug, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SaveCallDebug
{
Peer = peer,
Debug = debug,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SendSignalingDataAsync(InputPhoneCallBase peer, byte[] data, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SendSignalingData
{
Peer = peer,
Data = data,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}