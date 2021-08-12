using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Users;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Users
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Users(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<RpcVector<UserBase>>> GetUsersAsync(IList<InputUserBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<UserBase>>();
			rpcResponse.Response = new RpcVector<UserBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetUsers
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UserFullBase>> GetFullUserAsync(InputUserBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserFullBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetFullUser
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetSecureValueErrorsAsync(InputUserBase id, IList<SecureValueErrorBase> errors, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SetSecureValueErrors
{
Id = id,
Errors = errors,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}