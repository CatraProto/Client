using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Stickers;
using StickerSetBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Stickers
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Stickers(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<StickerSetBase>> CreateStickerSetAsync(InputUserBase userId, string title, string shortName, IList<InputStickerSetItemBase> stickers, bool masks = true, bool animated = true, InputDocumentBase? thumb = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new CreateStickerSet
			{
UserId = userId,
Title = title,
ShortName = shortName,
Stickers = stickers,
Masks = masks,
Animated = animated,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickerSetBase>> RemoveStickerFromSetAsync(InputDocumentBase sticker, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new RemoveStickerFromSet
			{
Sticker = sticker,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickerSetBase>> ChangeStickerPositionAsync(InputDocumentBase sticker, int position, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new ChangeStickerPosition
			{
Sticker = sticker,
Position = position,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickerSetBase>> AddStickerToSetAsync(InputStickerSetBase stickerset, InputStickerSetItemBase sticker, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new AddStickerToSet
			{
Stickerset = stickerset,
Sticker = sticker,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<StickerSetBase>> SetStickerSetThumbAsync(InputStickerSetBase stickerset, InputDocumentBase thumb, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetBase>();
			messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
			var methodBody = new SetStickerSetThumb
			{
Stickerset = stickerset,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}