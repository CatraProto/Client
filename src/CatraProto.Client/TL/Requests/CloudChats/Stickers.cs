#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Stickers;
using StickerSetBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase;

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Stickers
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Stickers(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    internal async Task<RpcResponse<StickerSetBase>> InternalCreateStickerSetAsync(InputUserBase userId, string title, string shortName, List<InputStickerSetItemBase> stickers, bool masks = false, bool animated = false, bool videos = false, InputDocumentBase? thumb = null, string? software = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<StickerSetBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CreateStickerSet(){
UserId = userId,
Title = title,
ShortName = shortName,
Stickers = stickers,
Masks = masks,
Animated = animated,
Videos = videos,
Thumb = thumb,
Software = software,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<StickerSetBase>> RemoveStickerFromSetAsync(InputDocumentBase sticker, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<StickerSetBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new RemoveStickerFromSet(){
Sticker = sticker,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<StickerSetBase>> ChangeStickerPositionAsync(InputDocumentBase sticker, int position, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<StickerSetBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ChangeStickerPosition(){
Sticker = sticker,
Position = position,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<StickerSetBase>> AddStickerToSetAsync(InputStickerSetBase stickerset, InputStickerSetItemBase sticker, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<StickerSetBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AddStickerToSet(){
Stickerset = stickerset,
Sticker = sticker,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<StickerSetBase>> SetStickerSetThumbAsync(InputStickerSetBase stickerset, InputDocumentBase thumb, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<StickerSetBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetStickerSetThumb(){
Stickerset = stickerset,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CheckShortNameAsync(string shortName, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CheckShortName(){
ShortName = shortName,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SuggestedShortNameBase>> SuggestShortNameAsync(string title, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SuggestedShortNameBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SuggestShortName(){
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<StickerSetBase>> CreateStickerSetAsync(long userId, string title, string shortName, List<InputStickerSetItemBase> stickers, bool masks = false, bool animated = false, bool videos = false, InputDocumentBase? thumb = null, string? software = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<StickerSetBase>.FromError(new PeerNotFoundError(userId, PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<StickerSetBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CreateStickerSet(){
UserId = userIdResolved,
Title = title,
ShortName = shortName,
Stickers = stickers,
Masks = masks,
Animated = animated,
Videos = videos,
Thumb = thumb,
Software = software,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}