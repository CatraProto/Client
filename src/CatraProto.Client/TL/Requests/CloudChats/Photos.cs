using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Photos;
using PhotoBase = CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Photos
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Photos(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<PhotoBase>> UpdateProfilePhotoAsync(InputPhotoBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhotoBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UpdateProfilePhoto
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PhotoBase>> UploadProfilePhotoAsync(InputFileBase? file = null, InputFileBase? video = null, double? videoStartTs = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhotoBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UploadProfilePhoto
			{
File = file,
Video = video,
VideoStartTs = videoStartTs,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<long>>> DeletePhotosAsync(IList<InputPhotoBase> id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<long>>();
			rpcResponse.Response = new RpcVector<long>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new DeletePhotos
			{
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PhotosBase>> GetUserPhotosAsync(InputUserBase userId, int offset, long maxId, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhotosBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetUserPhotos
			{
UserId = userId,
Offset = offset,
MaxId = maxId,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}