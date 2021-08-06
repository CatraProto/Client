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
	public partial class Help
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Help(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }
	    
	    public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ConfigBase>> GetConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ConfigBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase>> GetNearestDcAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetNearestDc(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase>> GetAppUpdateAsync(string source, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppUpdate(){
Source = source,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase>> GetInviteTextAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetInviteText(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase>> GetSupportAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetSupport(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetAppChangelogAsync(string prevAppVersion, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppChangelog(){
PrevAppVersion = prevAppVersion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SetBotUpdatesStatusAsync(int pendingUpdatesCount, string message, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.SetBotUpdatesStatus(){
PendingUpdatesCount = pendingUpdatesCount,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase>> GetCdnConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCdnConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase>> GetRecentMeUrlsAsync(string referer, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetRecentMeUrls(){
Referer = referer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase>> GetTermsOfServiceUpdateAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetTermsOfServiceUpdate(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> AcceptTermsOfServiceAsync(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase id, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.AcceptTermsOfService(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase>> GetDeepLinkInfoAsync(string path, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetDeepLinkInfo(){
Path = path,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>> GetAppConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> SaveAppLogAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> events, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.SaveAppLog(){
Events = events,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase>> GetPassportConfigAsync(int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPassportConfig(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportNameBase>> GetSupportNameAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportNameBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetSupportName(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>> GetUserInfoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetUserInfo(){
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>> EditUserInfoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string message, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.EditUserInfo(){
UserId = userId,
Message = message,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataBase>> GetPromoDataAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPromoData(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> HidePromoDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.HidePromoData(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<bool>> DismissSuggestionAsync(string suggestion, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.DismissSuggestion(){
Suggestion = suggestion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}
public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase>> GetCountriesListAsync(string langCode, int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase>();
messageSendingOptions ??= new CatraProto.Client.MTProto.Messages.MessageSendingOptions(isEncrypted: true);
var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCountriesList(){
LangCode = langCode,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}