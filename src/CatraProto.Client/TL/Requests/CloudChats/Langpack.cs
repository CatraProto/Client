using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using CatraProto.Client;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using System.Collections.Generic;
using System.Numerics;


namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Langpack
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Langpack(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>> GetLangPackAsync(string langPack, string langCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLangPack(){
LangPack = langPack,
LangCode = langCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>>> GetStringsAsync(string langPack, string langCode, List<string> keys, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetStrings(){
LangPack = langPack,
LangCode = langCode,
Keys = keys,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>> GetDifferenceAsync(string langPack, string langCode, int fromVersion, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetDifference(){
LangPack = langPack,
LangCode = langCode,
FromVersion = fromVersion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>>> GetLanguagesAsync(string langPack, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>>(
new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>()
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLanguages(){
LangPack = langPack,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>> GetLanguageAsync(string langPack, string langCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Langpack.GetLanguage(){
LangPack = langPack,
LangCode = langCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}