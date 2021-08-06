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
	public partial class Account
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Account(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcMessage<bool>> RegisterDeviceAsync(int tokenType, string token, bool appSandbox, byte[] secret, IList<int> otherUids, bool noMuted = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.RegisterDevice(){
TokenType = tokenType,
Token = token,
AppSandbox = appSandbox,
Secret = secret,
OtherUids = otherUids,
NoMuted = noMuted,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> UnregisterDeviceAsync(int tokenType, string token, IList<int> otherUids, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UnregisterDevice(){
TokenType = tokenType,
Token = token,
OtherUids = otherUids,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> UpdateNotifySettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateNotifySettings(){
Peer = peer,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>> GetNotifySettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetNotifySettings(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ResetNotifySettingsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetNotifySettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> UpdateProfileAsync(string? firstName = null, string? lastName = null, string? about = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateProfile(){
FirstName = firstName,
LastName = lastName,
About = about,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> UpdateStatusAsync(bool offline, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateStatus(){
Offline = offline,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase>> GetWallPapersAsync(int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPapers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ReportPeerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ReportPeer(){
Peer = peer,
Reason = reason,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> CheckUsernameAsync(string username, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.CheckUsername(){
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> UpdateUsernameAsync(string username, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateUsername(){
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>> GetPrivacyAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPrivacy(){
Key = key,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>> SetPrivacyAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, IList<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> rules, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetPrivacy(){
Key = key,
Rules = rules,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> DeleteAccountAsync(string reason, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.DeleteAccount(){
Reason = reason,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>> GetAccountTTLAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAccountTTL(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SetAccountTTLAsync(CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase ttl, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetAccountTTL(){
Ttl = ttl,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendChangePhoneCodeAsync(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendChangePhoneCode(){
PhoneNumber = phoneNumber,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> ChangePhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ChangePhone(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> UpdateDeviceLockedAsync(int period, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateDeviceLocked(){
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase>> GetAuthorizationsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ResetAuthorizationAsync(long hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetAuthorization(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase>> GetPasswordAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPassword(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase>> GetPasswordSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPasswordSettings(){
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> UpdatePasswordSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase newSettings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdatePasswordSettings(){
Password = password,
NewSettings = newSettings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendConfirmPhoneCodeAsync(string hash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendConfirmPhoneCode(){
Hash = hash,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ConfirmPhoneAsync(string phoneCodeHash, string phoneCode, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPhone(){
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase>> GetTmpPasswordAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, int period, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTmpPassword(){
Password = password,
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase>> GetWebAuthorizationsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWebAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ResetWebAuthorizationAsync(long hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWebAuthorization(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ResetWebAuthorizationsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWebAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>> GetAllSecureValuesAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>();
rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAllSecureValues(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>> GetSecureValueAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>();
rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetSecureValue(){
Types = types,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>> SaveSecureValueAsync(CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase value, long secureSecretId, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveSecureValue(){
Value = value,
SecureSecretId = secureSecretId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> DeleteSecureValueAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.DeleteSecureValue(){
Types = types,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase>> GetAuthorizationFormAsync(int botId, string scope, string publicKey, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizationForm(){
BotId = botId,
Scope = scope,
PublicKey = publicKey,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> AcceptAuthorizationAsync(int botId, string scope, string publicKey, IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> valueHashes, CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.AcceptAuthorization(){
BotId = botId,
Scope = scope,
PublicKey = publicKey,
ValueHashes = valueHashes,
Credentials = credentials,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendVerifyPhoneCodeAsync(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyPhoneCode(){
PhoneNumber = phoneNumber,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> VerifyPhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyPhone(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase>> SendVerifyEmailCodeAsync(string email, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyEmailCode(){
Email = email,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> VerifyEmailAsync(string email, string code, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyEmail(){
Email = email,
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase>> InitTakeoutSessionAsync(bool contacts = true, bool messageUsers = true, bool messageChats = true, bool messageMegagroups = true, bool messageChannels = true, bool files = true, int? fileMaxSize = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.InitTakeoutSession(){
Contacts = contacts,
MessageUsers = messageUsers,
MessageChats = messageChats,
MessageMegagroups = messageMegagroups,
MessageChannels = messageChannels,
Files = files,
FileMaxSize = fileMaxSize,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> FinishTakeoutSessionAsync(bool success = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.FinishTakeoutSession(){
Success = success,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ConfirmPasswordEmailAsync(string code, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPasswordEmail(){
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ResendPasswordEmailAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResendPasswordEmail(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> CancelPasswordEmailAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.CancelPasswordEmail(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> GetContactSignUpNotificationAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetContactSignUpNotification(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SetContactSignUpNotificationAsync(bool silent, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetContactSignUpNotification(){
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetNotifyExceptionsAsync(bool compareSound = true, CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase? peer = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetNotifyExceptions(){
CompareSound = compareSound,
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> GetWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPaper(){
Wallpaper = wallpaper,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> UploadWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadWallPaper(){
File = file,
MimeType = mimeType,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SaveWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, bool unsave, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveWallPaper(){
Wallpaper = wallpaper,
Unsave = unsave,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> InstallWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallWallPaper(){
Wallpaper = wallpaper,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> ResetWallPapersAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWallPapers(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase>> GetAutoDownloadSettingsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAutoDownloadSettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SaveAutoDownloadSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = true, bool high = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveAutoDownloadSettings(){
Settings = settings,
Low = low,
High = high,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>> UploadThemeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string fileName, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase? thumb = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadTheme(){
File = file,
FileName = fileName,
MimeType = mimeType,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> CreateThemeAsync(string slug, string title, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? document = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase? settings = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.CreateTheme(){
Slug = slug,
Title = title,
Document = document,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> UpdateThemeAsync(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, string? slug = null, string? title = null, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? document = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase? settings = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme(){
Format = format,
Theme = theme,
Slug = slug,
Title = title,
Document = document,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SaveThemeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, bool unsave, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveTheme(){
Theme = theme,
Unsave = unsave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> InstallThemeAsync(bool dark = true, string? format = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase? theme = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallTheme(){
Dark = dark,
Format = format,
Theme = theme,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> GetThemeAsync(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, long documentId, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTheme(){
Format = format,
Theme = theme,
DocumentId = documentId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase>> GetThemesAsync(string format, int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetThemes(){
Format = format,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SetContentSettingsAsync(bool sensitiveEnabled = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetContentSettings(){
SensitiveEnabled = sensitiveEnabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase>> GetContentSettingsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetContentSettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>>> GetMultiWallPapersAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> wallpapers, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>>();
rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetMultiWallPapers(){
Wallpapers = wallpapers,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>> GetGlobalPrivacySettingsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetGlobalPrivacySettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>> SetGlobalPrivacySettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase settings, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetGlobalPrivacySettings(){
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}