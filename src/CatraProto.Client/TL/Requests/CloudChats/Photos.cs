using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Photos;
using PhotoBase = CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Photos
	{
		private MessagesHandler _messagesHandler;

		internal Photos(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<PhotoBase>> UpdateProfilePhoto(InputPhotoBase id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhotoBase>();
			var methodBody = new UpdateProfilePhoto
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

		public async Task<RpcMessage<PhotoBase>> UploadProfilePhoto(InputFileBase? file = null, InputFileBase? video = null, double? videoStartTs = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhotoBase>();
			var methodBody = new UploadProfilePhoto
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

		public async Task<RpcMessage<long>> DeletePhotos(List<InputPhotoBase> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<long>();
			var methodBody = new DeletePhotos
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

		public async Task<RpcMessage<PhotosBase>> GetUserPhotos(InputUserBase userId, int offset, long maxId, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PhotosBase>();
			var methodBody = new GetUserPhotos
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