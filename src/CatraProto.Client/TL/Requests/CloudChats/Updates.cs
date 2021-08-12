using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Updates
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Updates(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<StateBase>> GetStateAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StateBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetState
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<DifferenceBase>> GetDifferenceAsync(int pts, int date, int qts, int? ptsTotalLimit = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DifferenceBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetDifference
			{
Pts = pts,
Date = date,
Qts = qts,
PtsTotalLimit = ptsTotalLimit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ChannelDifferenceBase>> GetChannelDifferenceAsync(InputChannelBase channel, ChannelMessagesFilterBase filter, int pts, int limit, bool force = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChannelDifferenceBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetChannelDifference
			{
Channel = channel,
Filter = filter,
Pts = pts,
Limit = limit,
Force = force,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}