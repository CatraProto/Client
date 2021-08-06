using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Upload
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Upload(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcMessage<bool>> SaveFilePartAsync(long fileId, int filePart, byte[] bytes, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveFilePart(){
FileId = fileId,
FilePart = filePart,
Bytes = bytes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>> GetFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, int limit, bool precise = true, bool cdnSupported = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFile(){
Location = location,
Offset = offset,
Limit = limit,
Precise = precise,
CdnSupported = cdnSupported,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SaveBigFilePartAsync(long fileId, int filePart, int fileTotalParts, byte[] bytes, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.SaveBigFilePart(){
FileId = fileId,
FilePart = filePart,
FileTotalParts = fileTotalParts,
Bytes = bytes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase>> GetWebFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase location, int offset, int limit, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetWebFile(){
Location = location,
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase>> GetCdnFileAsync(byte[] fileToken, int offset, int limit, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFile(){
FileToken = fileToken,
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> ReuploadCdnFileAsync(byte[] fileToken, byte[] requestToken, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>();
rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.ReuploadCdnFile(){
FileToken = fileToken,
RequestToken = requestToken,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> GetCdnFileHashesAsync(byte[] fileToken, int offset, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>();
rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetCdnFileHashes(){
FileToken = fileToken,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>> GetFileHashesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase location, int offset, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>>();
rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.FileHashBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Upload.GetFileHashes(){
Location = location,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}