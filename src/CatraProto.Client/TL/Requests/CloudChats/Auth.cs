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
	public partial class Auth
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Auth(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> InternalSendCodeAsync(string phoneNumber, int apiId, string apiHash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.SendCode(){
PhoneNumber = phoneNumber,
ApiId = apiId,
ApiHash = apiHash,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> InternalSignUpAsync(string phoneNumber, string phoneCodeHash, string firstName, string lastName, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.SignUp(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
FirstName = firstName,
LastName = lastName,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> InternalSignInAsync(string phoneNumber, string phoneCodeHash, string phoneCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.SignIn(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoggedOutBase>> InternalLogOutAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoggedOutBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.LogOut(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetAuthorizationsAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResetAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase>> ExportAuthorizationAsync(int dcId, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportAuthorization(){
DcId = dcId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> ImportAuthorizationAsync(long id, byte[] bytes, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportAuthorization(){
Id = id,
Bytes = bytes,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> BindTempAuthKeyAsync(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.BindTempAuthKey(){
PermAuthKeyId = permAuthKeyId,
Nonce = nonce,
ExpiresAt = expiresAt,
EncryptedMessage = encryptedMessage,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> InternalImportBotAuthorizationAsync(int flags, int apiId, string apiHash, string botAuthToken, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportBotAuthorization(){
Flags = flags,
ApiId = apiId,
ApiHash = apiHash,
BotAuthToken = botAuthToken,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> InternalCheckPasswordAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckPassword(){
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase>> RequestPasswordRecoveryAsync( CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.RequestPasswordRecovery(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> RecoverPasswordAsync(string code, CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase? newSettings = null, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.RecoverPassword(){
Code = code,
NewSettings = newSettings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> InternalResendCodeAsync(string phoneNumber, string phoneCodeHash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResendCode(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CancelCodeAsync(string phoneNumber, string phoneCodeHash, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.CancelCode(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DropTempAuthKeysAsync(List<long> exceptAuthKeys, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.DropTempAuthKeys(){
ExceptAuthKeys = exceptAuthKeys,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>> ExportLoginTokenAsync(int apiId, string apiHash, List<long> exceptIds, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportLoginToken(){
ApiId = apiId,
ApiHash = apiHash,
ExceptIds = exceptIds,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>> ImportLoginTokenAsync(byte[] token, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportLoginToken(){
Token = token,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>> AcceptLoginTokenAsync(byte[] token, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.AcceptLoginToken(){
Token = token,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CheckRecoveryPasswordAsync(string code, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckRecoveryPassword(){
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}