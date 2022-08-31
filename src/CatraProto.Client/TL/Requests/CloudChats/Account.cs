#region

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Interfaces;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using AutoDownloadSettingsBase = CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase;
using UpdateNotifySettings = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateNotifySettings;
using UpdateTheme = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme;

#endregion

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Account
	{
		
	    private readonly IMessagesQueue _messagesQueue;
        private readonly TelegramClient _client;
	    
	    internal Account(TelegramClient client, IMessagesQueue messagesQueue)
	    {
	        _client = client;
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcResponse<bool>> RegisterDeviceAsync(int tokenType, string token, bool appSandbox, byte[] secret, List<long> otherUids, bool noMuted = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new RegisterDevice(){
TokenType = tokenType,
Token = token,
AppSandbox = appSandbox,
Secret = secret,
OtherUids = otherUids,
NoMuted = noMuted,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UnregisterDeviceAsync(int tokenType, string token, List<long> otherUids, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UnregisterDevice(){
TokenType = tokenType,
Token = token,
OtherUids = otherUids,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdateNotifySettingsAsync(InputNotifyPeerBase peer, InputPeerNotifySettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateNotifySettings(){
Peer = peer,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PeerNotifySettingsBase>> GetNotifySettingsAsync(InputNotifyPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PeerNotifySettingsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetNotifySettings(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetNotifySettingsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetNotifySettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UserBase>> UpdateProfileAsync(string? firstName = null, string? lastName = null, string? about = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UserBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateProfile(){
FirstName = firstName,
LastName = lastName,
About = about,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdateStatusAsync(bool offline, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateStatus(){
Offline = offline,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<WallPapersBase>> GetWallPapersAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<WallPapersBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetWallPapers(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReportPeerAsync(InputPeerBase peer, ReportReasonBase reason, string message, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReportPeer(){
Peer = peer,
Reason = reason,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CheckUsernameAsync(string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CheckUsername(){
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UserBase>> UpdateUsernameAsync(string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UserBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateUsername(){
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PrivacyRulesBase>> GetPrivacyAsync(InputPrivacyKeyBase key, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PrivacyRulesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetPrivacy(){
Key = key,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PrivacyRulesBase>> SetPrivacyAsync(InputPrivacyKeyBase key, List<InputPrivacyRuleBase> rules, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PrivacyRulesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetPrivacy(){
Key = key,
Rules = rules,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeleteAccountAsync(string reason, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteAccount(){
Reason = reason,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AccountDaysTTLBase>> GetAccountTTLAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AccountDaysTTLBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAccountTTL(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetAccountTTLAsync(AccountDaysTTLBase ttl, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetAccountTTL(){
Ttl = ttl,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SentCodeBase>> SendChangePhoneCodeAsync(string phoneNumber, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SentCodeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SendChangePhoneCode(){
PhoneNumber = phoneNumber,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UserBase>> ChangePhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UserBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ChangePhone(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdateDeviceLockedAsync(int period, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateDeviceLocked(){
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AuthorizationsBase>> GetAuthorizationsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AuthorizationsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetAuthorizationAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetAuthorization(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PasswordBase>> GetPasswordAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PasswordBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetPassword(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<PasswordSettingsBase>> GetPasswordSettingsAsync(InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<PasswordSettingsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetPasswordSettings(){
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> UpdatePasswordSettingsAsync(InputCheckPasswordSRPBase password, PasswordInputSettingsBase newSettings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdatePasswordSettings(){
Password = password,
NewSettings = newSettings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SentCodeBase>> SendConfirmPhoneCodeAsync(string hash, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SentCodeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SendConfirmPhoneCode(){
Hash = hash,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ConfirmPhoneAsync(string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ConfirmPhone(){
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<TmpPasswordBase>> GetTmpPasswordAsync(InputCheckPasswordSRPBase password, int period, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<TmpPasswordBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetTmpPassword(){
Password = password,
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<WebAuthorizationsBase>> GetWebAuthorizationsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<WebAuthorizationsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetWebAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetWebAuthorizationAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetWebAuthorization(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetWebAuthorizationsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetWebAuthorizations(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<SecureValueBase>>> GetAllSecureValuesAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<SecureValueBase>>(
new RpcVector<SecureValueBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAllSecureValues(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<SecureValueBase>>> GetSecureValueAsync(List<SecureValueTypeBase> types, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<SecureValueBase>>(
new RpcVector<SecureValueBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSecureValue(){
Types = types,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SecureValueBase>> SaveSecureValueAsync(InputSecureValueBase value, long secureSecretId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SecureValueBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveSecureValue(){
Value = value,
SecureSecretId = secureSecretId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeleteSecureValueAsync(List<SecureValueTypeBase> types, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeleteSecureValue(){
Types = types,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AuthorizationFormBase>> GetAuthorizationFormAsync(long botId, string scope, string publicKey, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AuthorizationFormBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAuthorizationForm(){
BotId = botId,
Scope = scope,
PublicKey = publicKey,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> AcceptAuthorizationAsync(long botId, string scope, string publicKey, List<SecureValueHashBase> valueHashes, SecureCredentialsEncryptedBase credentials, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new AcceptAuthorization(){
BotId = botId,
Scope = scope,
PublicKey = publicKey,
ValueHashes = valueHashes,
Credentials = credentials,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SentCodeBase>> SendVerifyPhoneCodeAsync(string phoneNumber, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SentCodeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SendVerifyPhoneCode(){
PhoneNumber = phoneNumber,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> VerifyPhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new VerifyPhone(){
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SentEmailCodeBase>> SendVerifyEmailCodeAsync(string email, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SentEmailCodeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SendVerifyEmailCode(){
Email = email,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> VerifyEmailAsync(string email, string code, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new VerifyEmail(){
Email = email,
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<TakeoutBase>> InitTakeoutSessionAsync(bool contacts = false, bool messageUsers = false, bool messageChats = false, bool messageMegagroups = false, bool messageChannels = false, bool files = false, long? fileMaxSize = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<TakeoutBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new InitTakeoutSession(){
Contacts = contacts,
MessageUsers = messageUsers,
MessageChats = messageChats,
MessageMegagroups = messageMegagroups,
MessageChannels = messageChannels,
Files = files,
FileMaxSize = fileMaxSize,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> FinishTakeoutSessionAsync(bool success = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new FinishTakeoutSession(){
Success = success,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ConfirmPasswordEmailAsync(string code, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ConfirmPasswordEmail(){
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResendPasswordEmailAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResendPasswordEmail(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> CancelPasswordEmailAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CancelPasswordEmail(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> GetContactSignUpNotificationAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetContactSignUpNotification(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetContactSignUpNotificationAsync(bool silent, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetContactSignUpNotification(){
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<UpdatesBase>> GetNotifyExceptionsAsync(bool compareSound = false, InputNotifyPeerBase? peer = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<UpdatesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetNotifyExceptions(){
CompareSound = compareSound,
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<WallPaperBase>> GetWallPaperAsync(InputWallPaperBase wallpaper, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<WallPaperBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetWallPaper(){
Wallpaper = wallpaper,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<WallPaperBase>> UploadWallPaperAsync(InputFileBase file, string mimeType, WallPaperSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<WallPaperBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UploadWallPaper(){
File = file,
MimeType = mimeType,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveWallPaperAsync(InputWallPaperBase wallpaper, bool unsave, WallPaperSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveWallPaper(){
Wallpaper = wallpaper,
Unsave = unsave,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> InstallWallPaperAsync(InputWallPaperBase wallpaper, WallPaperSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new InstallWallPaper(){
Wallpaper = wallpaper,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ResetWallPapersAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetWallPapers(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<AutoDownloadSettingsBase>> GetAutoDownloadSettingsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<AutoDownloadSettingsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetAutoDownloadSettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveAutoDownloadSettingsAsync(Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = false, bool high = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveAutoDownloadSettings(){
Settings = settings,
Low = low,
High = high,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<DocumentBase>> UploadThemeAsync(InputFileBase file, string fileName, string mimeType, InputFileBase? thumb = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<DocumentBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UploadTheme(){
File = file,
FileName = fileName,
MimeType = mimeType,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ThemeBase>> CreateThemeAsync(string slug, string title, InputDocumentBase? document = null, List<InputThemeSettingsBase>? settings = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ThemeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new CreateTheme(){
Slug = slug,
Title = title,
Document = document,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ThemeBase>> UpdateThemeAsync(string format, InputThemeBase theme, string? slug = null, string? title = null, InputDocumentBase? document = null, List<InputThemeSettingsBase>? settings = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ThemeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UpdateTheme(){
Format = format,
Theme = theme,
Slug = slug,
Title = title,
Document = document,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SaveThemeAsync(InputThemeBase theme, bool unsave, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveTheme(){
Theme = theme,
Unsave = unsave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> InstallThemeAsync(bool dark = false, InputThemeBase? theme = null, string? format = null, BaseThemeBase? baseTheme = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new InstallTheme(){
Dark = dark,
Theme = theme,
Format = format,
BaseTheme = baseTheme,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ThemeBase>> GetThemeAsync(string format, InputThemeBase theme, long documentId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ThemeBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetTheme(){
Format = format,
Theme = theme,
DocumentId = documentId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ThemesBase>> GetThemesAsync(string format, long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ThemesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetThemes(){
Format = format,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetContentSettingsAsync(bool sensitiveEnabled = false, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetContentSettings(){
SensitiveEnabled = sensitiveEnabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ContentSettingsBase>> GetContentSettingsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ContentSettingsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetContentSettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<RpcVector<WallPaperBase>>> GetMultiWallPapersAsync(List<InputWallPaperBase> wallpapers, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<RpcVector<WallPaperBase>>(
new RpcVector<WallPaperBase>()
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetMultiWallPapers(){
Wallpapers = wallpapers,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<GlobalPrivacySettingsBase>> GetGlobalPrivacySettingsAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<GlobalPrivacySettingsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetGlobalPrivacySettings(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<GlobalPrivacySettingsBase>> SetGlobalPrivacySettingsAsync(GlobalPrivacySettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<GlobalPrivacySettingsBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetGlobalPrivacySettings(){
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
internal async Task<RpcResponse<bool>> InternalReportProfilePhotoAsync(InputPeerBase peer, InputPhotoBase photoId, ReportReasonBase reason, string message, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReportProfilePhoto(){
Peer = peer,
PhotoId = photoId,
Reason = reason,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ResetPasswordResultBase>> ResetPasswordAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ResetPasswordResultBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ResetPassword(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> DeclinePasswordResetAsync( MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new DeclinePasswordReset(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<ThemesBase>> GetChatThemesAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<ThemesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetChatThemes(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> SetAuthorizationTTLAsync(int authorizationTtlDays, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SetAuthorizationTTL(){
AuthorizationTtlDays = authorizationTtlDays,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ChangeAuthorizationSettingsAsync(long hash, bool? encryptedRequestsDisabled = null, bool? callRequestsDisabled = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ChangeAuthorizationSettings(){
Hash = hash,
EncryptedRequestsDisabled = encryptedRequestsDisabled,
CallRequestsDisabled = callRequestsDisabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SavedRingtonesBase>> GetSavedRingtonesAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SavedRingtonesBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new GetSavedRingtones(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<SavedRingtoneBase>> SaveRingtoneAsync(InputDocumentBase id, bool unsave, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<SavedRingtoneBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new SaveRingtone(){
Id = id,
Unsave = unsave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<DocumentBase>> UploadRingtoneAsync(InputFileBase file, string fileName, string mimeType, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcResponse<DocumentBase>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new UploadRingtone(){
File = file,
FileName = fileName,
MimeType = mimeType,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReportPeerAsync(PeerId peer, ReportReasonBase reason, string message, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReportPeer(){
Peer = peerResolved,
Reason = reason,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}
public async Task<RpcResponse<bool>> ReportProfilePhotoAsync(PeerId peer, InputPhotoBase photoId, ReportReasonBase reason, string message, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var peerToResolve = _client.DatabaseManager.PeerDatabase.ResolvePeer(peer);
if(peerToResolve is null) {
return RpcResponse<bool>.FromError(new PeerNotFoundError(peer.Id, peer.Type));
}
var peerResolved = peerToResolve;
var rpcResponse = new RpcResponse<bool>(
);
messageSendingOptions ??= new MessageSendingOptions();
messageSendingOptions.IsEncrypted = true;
var methodBody = new ReportProfilePhoto(){
Peer = peerResolved,
PhotoId = photoId,
Reason = reason,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}