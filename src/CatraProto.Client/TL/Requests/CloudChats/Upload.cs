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
	public partial class Upload
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Upload(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<bool>> SaveFilePartAsync(long fileId, int filePart, byte[] bytes, CancellationToken cancellationToken = default)
		{
			if(bytes is null) throw new ArgumentNullException(nameof(bytes));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveFilePart()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>> GetFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, int limit, bool precise = true, bool cdnSupported = true, CancellationToken cancellationToken = default)
		{
			if(location is null) throw new ArgumentNullException(nameof(location));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFile()
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
		public async Task<RpcMessage<bool>> SaveBigFilePartAsync(long fileId, int filePart, int fileTotalParts, byte[] bytes, CancellationToken cancellationToken = default)
		{
			if(bytes is null) throw new ArgumentNullException(nameof(bytes));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveBigFilePart()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase>> GetWebFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase location, int offset, int limit, CancellationToken cancellationToken = default)
		{
			if(location is null) throw new ArgumentNullException(nameof(location));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetWebFile()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase>> GetCdnFileAsync(byte[] fileToken, int offset, int limit, CancellationToken cancellationToken = default)
		{
			if(fileToken is null) throw new ArgumentNullException(nameof(fileToken));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFile()
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
		public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> ReuploadCdnFileAsync(byte[] fileToken, byte[] requestToken, CancellationToken cancellationToken = default)
		{
			if(fileToken is null) throw new ArgumentNullException(nameof(fileToken));
if(requestToken is null) throw new ArgumentNullException(nameof(requestToken));

			var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>();
			rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.ReuploadCdnFile()
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
		public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> GetCdnFileHashesAsync(byte[] fileToken, int offset, CancellationToken cancellationToken = default)
		{
			if(fileToken is null) throw new ArgumentNullException(nameof(fileToken));

			var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>();
			rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFileHashes()
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
		public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> GetFileHashesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, CancellationToken cancellationToken = default)
		{
			if(location is null) throw new ArgumentNullException(nameof(location));

			var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>();
			rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFileHashes()
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