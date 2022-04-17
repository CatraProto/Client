using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using CatraProto.Client;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using System.Collections.Generic;
using System.Numerics;


namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Stickers
	{
		
	    private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Stickers(TelegramClient client, MessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> CreateStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string title, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> stickers, bool masks = true, bool animated = true, bool videos = true, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? thumb = null, string? software = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CreateStickerSet(){
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
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> RemoveStickerFromSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.RemoveStickerFromSet(){
Sticker = sticker,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> ChangeStickerPositionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, int position, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.ChangeStickerPosition(){
Sticker = sticker,
Position = position,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> AddStickerToSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase sticker, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.AddStickerToSet(){
Stickerset = stickerset,
Sticker = sticker,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> SetStickerSetThumbAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SetStickerSetThumb(){
Stickerset = stickerset,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CheckShortNameAsync(string shortName, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CheckShortName(){
ShortName = shortName,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestedShortNameBase>> SuggestShortNameAsync(string title, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestedShortNameBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SuggestShortName(){
Title = title,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> CreateStickerSetAsync(long userId, string title, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> stickers, bool masks = true, bool animated = true, bool videos = true, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? thumb = null, string? software = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var userIdToResolve = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
if(userIdToResolve is null) {
return RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>.FromError(new PeerNotFoundError(userId, CatraProto.Client.MTProto.PeerType.User));
}
var userIdResolved = userIdToResolve;
var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CreateStickerSet(){
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