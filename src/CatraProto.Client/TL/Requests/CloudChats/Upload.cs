using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Upload;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Upload
	{
		private MessagesHandler _messagesHandler;

		internal Upload(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<bool>> SaveFilePart(long fileId, int filePart, byte[] bytes, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveFilePart
			{
				FileId = fileId,
				FilePart = filePart,
				Bytes = bytes,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<FileBase>> GetFile(InputFileLocationBase location, int offset, int limit, bool precise = true, bool cdnSupported = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FileBase>();
			var methodBody = new GetFile
			{
				Location = location,
				Offset = offset,
				Limit = limit,
				Precise = precise,
				CdnSupported = cdnSupported,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> SaveBigFilePart(long fileId, int filePart, int fileTotalParts, byte[] bytes, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveBigFilePart
			{
				FileId = fileId,
				FilePart = filePart,
				FileTotalParts = fileTotalParts,
				Bytes = bytes,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<WebFileBase>> GetWebFile(InputWebFileLocationBase location, int offset, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WebFileBase>();
			var methodBody = new GetWebFile
			{
				Location = location,
				Offset = offset,
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

		public async Task<RpcMessage<CdnFileBase>> GetCdnFile(byte[] fileToken, int offset, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CdnFileBase>();
			var methodBody = new GetCdnFile
			{
				FileToken = fileToken,
				Offset = offset,
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

		public async Task<RpcMessage<FileHashBase>> ReuploadCdnFile(byte[] fileToken, byte[] requestToken, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FileHashBase>();
			var methodBody = new ReuploadCdnFile
			{
				FileToken = fileToken,
				RequestToken = requestToken,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<FileHashBase>> GetCdnFileHashes(byte[] fileToken, int offset, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FileHashBase>();
			var methodBody = new GetCdnFileHashes
			{
				FileToken = fileToken,
				Offset = offset,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<FileHashBase>> GetFileHashes(InputFileLocationBase location, int offset, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FileHashBase>();
			var methodBody = new GetFileHashes
			{
				Location = location,
				Offset = offset,
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