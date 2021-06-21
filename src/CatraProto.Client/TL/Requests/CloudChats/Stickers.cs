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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> CreateStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string title, string shortName, List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> stickers, bool masks = true, bool animated = true, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? thumb = null, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> RemoveStickerFromSet(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> ChangeStickerPosition(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, int position, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> AddStickerToSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase sticker, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> SetStickerSetThumb(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}

	}
}