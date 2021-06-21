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
	public partial class Photos
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Photos(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>> UpdateProfilePhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.UpdateProfilePhoto()
			{
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>> UploadProfilePhoto(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase? file = null, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase? video = null, double? videoStartTs = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.UploadProfilePhoto()
			{
				File = file,
				Video = video,
				VideoStartTs = videoStartTs,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<long>> DeletePhotos(List<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<long>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.DeletePhotos()
			{
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>> GetUserPhotos(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int offset, long maxId, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Photos.GetUserPhotos()
			{
				UserId = userId,
				Offset = offset,
				MaxId = maxId,
				Limit = limit,
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