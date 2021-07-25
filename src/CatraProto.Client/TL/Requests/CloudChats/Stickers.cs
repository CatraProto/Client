using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Stickers
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Stickers(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> CreateStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string title, string shortName, IList<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> stickers, bool masks = true, bool animated = true, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));
if(title is null) throw new ArgumentNullException(nameof(title));
if(shortName is null) throw new ArgumentNullException(nameof(shortName));
if(stickers is null) throw new ArgumentNullException(nameof(stickers));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.CreateStickerSet()
			{
				UserId = userId,
				Title = title,
				ShortName = shortName,
				Stickers = stickers,
				Masks = masks,
				Animated = animated,
				Thumb = thumb,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> RemoveStickerFromSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(sticker is null) throw new ArgumentNullException(nameof(sticker));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.RemoveStickerFromSet()
			{
				Sticker = sticker,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> ChangeStickerPositionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, int position, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(sticker is null) throw new ArgumentNullException(nameof(sticker));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.ChangeStickerPosition()
			{
				Sticker = sticker,
				Position = position,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> AddStickerToSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase sticker, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(stickerset is null) throw new ArgumentNullException(nameof(stickerset));
if(sticker is null) throw new ArgumentNullException(nameof(sticker));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.AddStickerToSet()
			{
				Stickerset = stickerset,
				Sticker = sticker,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> SetStickerSetThumbAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(stickerset is null) throw new ArgumentNullException(nameof(stickerset));
if(thumb is null) throw new ArgumentNullException(nameof(thumb));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Stickers.SetStickerSetThumb()
			{
				Stickerset = stickerset,
				Thumb = thumb,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}

	}
}