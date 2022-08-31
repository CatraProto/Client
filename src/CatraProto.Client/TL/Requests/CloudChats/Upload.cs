#region

using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Upload;

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Upload
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Upload(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<bool>> SaveFilePartAsync(long fileId, int filePart, byte[] bytes, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveFilePart(){
FileId = fileId,
FilePart = filePart,
Bytes = bytes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<FileBase>> GetFileAsync(InputFileLocationBase location, long offset, int limit, bool precise = false, bool cdnSupported = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<FileBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetFile(){
Location = location,
Offset = offset,
Limit = limit,
Precise = precise,
CdnSupported = cdnSupported,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveBigFilePartAsync(long fileId, int filePart, int fileTotalParts, byte[] bytes, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveBigFilePart(){
FileId = fileId,
FilePart = filePart,
FileTotalParts = fileTotalParts,
Bytes = bytes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

public async Task<RpcResponse<WebFileBase>> GetWebFileAsync(InputWebFileLocationBase location, int offset, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<WebFileBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetWebFile(){
Location = location,
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CdnFileBase>> GetCdnFileAsync(byte[] fileToken, long offset, int limit, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CdnFileBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetCdnFile(){
FileToken = fileToken,
Offset = offset,
Limit = limit,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<FileHashBase>>> ReuploadCdnFileAsync(byte[] fileToken, byte[] requestToken, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<FileHashBase>>(
new RpcVector<FileHashBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReuploadCdnFile(){
FileToken = fileToken,
RequestToken = requestToken,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<FileHashBase>>> GetCdnFileHashesAsync(byte[] fileToken, long offset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<FileHashBase>>(
new RpcVector<FileHashBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetCdnFileHashes(){
FileToken = fileToken,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<FileHashBase>>> GetFileHashesAsync(InputFileLocationBase location, long offset, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<FileHashBase>>(
new RpcVector<FileHashBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetFileHashes(){
Location = location,
Offset = offset,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}