using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using AutoDownloadSettingsBase = CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase;
using UpdateNotifySettings = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateNotifySettings;
using UpdateTheme = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Account
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Account(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<bool>> RegisterDeviceAsync(int tokenType, string token, bool appSandbox, byte[] secret, IList<int> otherUids, bool noMuted = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new RegisterDevice
{
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

	    public async Task<RpcMessage<bool>> UnregisterDeviceAsync(int tokenType, string token, IList<int> otherUids, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new UnregisterDevice
{
TokenType = tokenType,
Token = token,
OtherUids = otherUids,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdateNotifySettingsAsync(InputNotifyPeerBase peer, InputPeerNotifySettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new UpdateNotifySettings
{
Peer = peer,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PeerNotifySettingsBase>> GetNotifySettingsAsync(InputNotifyPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PeerNotifySettingsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetNotifySettings
			{
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetNotifySettingsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ResetNotifySettings
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UserBase>> UpdateProfileAsync(string? firstName = null, string? lastName = null, string? about = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UpdateProfile
			{
FirstName = firstName,
LastName = lastName,
About = about,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdateStatusAsync(bool offline, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new UpdateStatus
{
Offline = offline,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<WallPapersBase>> GetWallPapersAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPapersBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetWallPapers
			{
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ReportPeerAsync(InputPeerBase peer, ReportReasonBase reason, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ReportPeer
{
Peer = peer,
Reason = reason,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> CheckUsernameAsync(string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new CheckUsername
{
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UserBase>> UpdateUsernameAsync(string username, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UpdateUsername
			{
Username = username,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PrivacyRulesBase>> GetPrivacyAsync(InputPrivacyKeyBase key, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PrivacyRulesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetPrivacy
			{
Key = key,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PrivacyRulesBase>> SetPrivacyAsync(InputPrivacyKeyBase key, IList<InputPrivacyRuleBase> rules, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PrivacyRulesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SetPrivacy
			{
Key = key,
Rules = rules,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> DeleteAccountAsync(string reason, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new DeleteAccount
{
Reason = reason,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AccountDaysTTLBase>> GetAccountTTLAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AccountDaysTTLBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAccountTTL
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetAccountTTLAsync(AccountDaysTTLBase ttl, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SetAccountTTL
{
Ttl = ttl,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<SentCodeBase>> SendChangePhoneCodeAsync(string phoneNumber, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SendChangePhoneCode
			{
PhoneNumber = phoneNumber,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UserBase>> ChangePhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new ChangePhone
			{
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdateDeviceLockedAsync(int period, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new UpdateDeviceLocked
{
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AuthorizationsBase>> GetAuthorizationsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAuthorizations
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetAuthorizationAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ResetAuthorization
{
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PasswordBase>> GetPasswordAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PasswordBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetPassword
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<PasswordSettingsBase>> GetPasswordSettingsAsync(InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PasswordSettingsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetPasswordSettings
			{
Password = password,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> UpdatePasswordSettingsAsync(InputCheckPasswordSRPBase password, PasswordInputSettingsBase newSettings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new UpdatePasswordSettings
{
Password = password,
NewSettings = newSettings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<SentCodeBase>> SendConfirmPhoneCodeAsync(string hash, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SendConfirmPhoneCode
			{
Hash = hash,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ConfirmPhoneAsync(string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ConfirmPhone
{
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<TmpPasswordBase>> GetTmpPasswordAsync(InputCheckPasswordSRPBase password, int period, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<TmpPasswordBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetTmpPassword
			{
Password = password,
Period = period,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<WebAuthorizationsBase>> GetWebAuthorizationsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WebAuthorizationsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetWebAuthorizations
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetWebAuthorizationAsync(long hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ResetWebAuthorization
{
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetWebAuthorizationsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ResetWebAuthorizations
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<SecureValueBase>>> GetAllSecureValuesAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<SecureValueBase>>();
			rpcResponse.Response = new RpcVector<SecureValueBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAllSecureValues
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<SecureValueBase>>> GetSecureValueAsync(IList<SecureValueTypeBase> types, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<SecureValueBase>>();
			rpcResponse.Response = new RpcVector<SecureValueBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetSecureValue
			{
Types = types,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<SecureValueBase>> SaveSecureValueAsync(InputSecureValueBase value, long secureSecretId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SecureValueBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SaveSecureValue
			{
Value = value,
SecureSecretId = secureSecretId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> DeleteSecureValueAsync(IList<SecureValueTypeBase> types, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new DeleteSecureValue
{
Types = types,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AuthorizationFormBase>> GetAuthorizationFormAsync(int botId, string scope, string publicKey, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationFormBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAuthorizationForm
			{
BotId = botId,
Scope = scope,
PublicKey = publicKey,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> AcceptAuthorizationAsync(int botId, string scope, string publicKey, IList<SecureValueHashBase> valueHashes, SecureCredentialsEncryptedBase credentials, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new AcceptAuthorization
{
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

	    public async Task<RpcMessage<SentCodeBase>> SendVerifyPhoneCodeAsync(string phoneNumber, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SendVerifyPhoneCode
			{
PhoneNumber = phoneNumber,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> VerifyPhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new VerifyPhone
{
PhoneNumber = phoneNumber,
PhoneCodeHash = phoneCodeHash,
PhoneCode = phoneCode,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<SentEmailCodeBase>> SendVerifyEmailCodeAsync(string email, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentEmailCodeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SendVerifyEmailCode
			{
Email = email,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> VerifyEmailAsync(string email, string code, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new VerifyEmail
{
Email = email,
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<TakeoutBase>> InitTakeoutSessionAsync(bool contacts = true, bool messageUsers = true, bool messageChats = true, bool messageMegagroups = true, bool messageChannels = true, bool files = true, int? fileMaxSize = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<TakeoutBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new InitTakeoutSession
			{
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

	    public async Task<RpcMessage<bool>> FinishTakeoutSessionAsync(bool success = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new FinishTakeoutSession
{
Success = success,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ConfirmPasswordEmailAsync(string code, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ConfirmPasswordEmail
{
Code = code,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResendPasswordEmailAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ResendPasswordEmail
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> CancelPasswordEmailAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new CancelPasswordEmail
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> GetContactSignUpNotificationAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new GetContactSignUpNotification
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetContactSignUpNotificationAsync(bool silent, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SetContactSignUpNotification
{
Silent = silent,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> GetNotifyExceptionsAsync(bool compareSound = true, InputNotifyPeerBase? peer = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetNotifyExceptions
			{
CompareSound = compareSound,
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<WallPaperBase>> GetWallPaperAsync(InputWallPaperBase wallpaper, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPaperBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetWallPaper
			{
Wallpaper = wallpaper,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<WallPaperBase>> UploadWallPaperAsync(InputFileBase file, string mimeType, WallPaperSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPaperBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UploadWallPaper
			{
File = file,
MimeType = mimeType,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveWallPaperAsync(InputWallPaperBase wallpaper, bool unsave, WallPaperSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SaveWallPaper
{
Wallpaper = wallpaper,
Unsave = unsave,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> InstallWallPaperAsync(InputWallPaperBase wallpaper, WallPaperSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new InstallWallPaper
{
Wallpaper = wallpaper,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> ResetWallPapersAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new ResetWallPapers
{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<AutoDownloadSettingsBase>> GetAutoDownloadSettingsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AutoDownloadSettingsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetAutoDownloadSettings
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveAutoDownloadSettingsAsync(Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = true, bool high = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SaveAutoDownloadSettings
{
Settings = settings,
Low = low,
High = high,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<DocumentBase>> UploadThemeAsync(InputFileBase file, string fileName, string mimeType, InputFileBase? thumb = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DocumentBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UploadTheme
			{
File = file,
FileName = fileName,
MimeType = mimeType,
Thumb = thumb,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ThemeBase>> CreateThemeAsync(string slug, string title, InputDocumentBase? document = null, InputThemeSettingsBase? settings = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new CreateTheme
			{
Slug = slug,
Title = title,
Document = document,
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ThemeBase>> UpdateThemeAsync(string format, InputThemeBase theme, string? slug = null, string? title = null, InputDocumentBase? document = null, InputThemeSettingsBase? settings = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new UpdateTheme
			{
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

	    public async Task<RpcMessage<bool>> SaveThemeAsync(InputThemeBase theme, bool unsave, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SaveTheme
{
Theme = theme,
Unsave = unsave,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> InstallThemeAsync(bool dark = true, string? format = null, InputThemeBase? theme = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new InstallTheme
{
Dark = dark,
Format = format,
Theme = theme,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ThemeBase>> GetThemeAsync(string format, InputThemeBase theme, long documentId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemeBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetTheme
			{
Format = format,
Theme = theme,
DocumentId = documentId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ThemesBase>> GetThemesAsync(string format, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemesBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetThemes
			{
Format = format,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetContentSettingsAsync(bool sensitiveEnabled = true, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(true);
var methodBody = new SetContentSettings
{
SensitiveEnabled = sensitiveEnabled,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<ContentSettingsBase>> GetContentSettingsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ContentSettingsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetContentSettings
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<RpcVector<WallPaperBase>>> GetMultiWallPapersAsync(IList<InputWallPaperBase> wallpapers, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcVector<WallPaperBase>>();
			rpcResponse.Response = new RpcVector<WallPaperBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetMultiWallPapers
			{
Wallpapers = wallpapers,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<GlobalPrivacySettingsBase>> GetGlobalPrivacySettingsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<GlobalPrivacySettingsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new GetGlobalPrivacySettings
			{
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	    public async Task<RpcMessage<GlobalPrivacySettingsBase>> SetGlobalPrivacySettingsAsync(GlobalPrivacySettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<GlobalPrivacySettingsBase>();
			messageSendingOptions ??= new MessageSendingOptions(true);
			var methodBody = new SetGlobalPrivacySettings
			{
Settings = settings,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource!;
return rpcResponse;
}

	}
}