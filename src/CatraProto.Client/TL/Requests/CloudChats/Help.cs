using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Help;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Help
	{
		
	    private readonly MessagesQueue _messagesQueue;
	    internal Help(MessagesQueue messagesQueue)
	    {
	        _messagesQueue = messagesQueue;
	        
	    }

	    public async Task<RpcMessage<ConfigBase>> GetConfigAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<ConfigBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<NearestDcBase>> GetNearestDcAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<NearestDcBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetNearestDc(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<AppUpdateBase>> GetAppUpdateAsync(string source, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<AppUpdateBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAppUpdate(){
Source = source,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<InviteTextBase>> GetInviteTextAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<InviteTextBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetInviteText(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<SupportBase>> GetSupportAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<SupportBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetSupport(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UpdatesBase>> GetAppChangelogAsync(string prevAppVersion, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UpdatesBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAppChangelog(){
PrevAppVersion = prevAppVersion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SetBotUpdatesStatusAsync(int pendingUpdatesCount, string message, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SetBotUpdatesStatus(){
PendingUpdatesCount = pendingUpdatesCount,
Message = message,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<CdnConfigBase>> GetCdnConfigAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CdnConfigBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetCdnConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<RecentMeUrlsBase>> GetRecentMeUrlsAsync(string referer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<RecentMeUrlsBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetRecentMeUrls(){
Referer = referer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<TermsOfServiceUpdateBase>> GetTermsOfServiceUpdateAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<TermsOfServiceUpdateBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetTermsOfServiceUpdate(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> AcceptTermsOfServiceAsync(DataJSONBase id, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new AcceptTermsOfService(){
Id = id,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<DeepLinkInfoBase>> GetDeepLinkInfoAsync(string path, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<DeepLinkInfoBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetDeepLinkInfo(){
Path = path,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<JSONValueBase>> GetAppConfigAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<JSONValueBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetAppConfig(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> SaveAppLogAsync(IList<InputAppEventBase> events, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new SaveAppLog(){
Events = events,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<PassportConfigBase>> GetPassportConfigAsync(int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<PassportConfigBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPassportConfig(){
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<SupportNameBase>> GetSupportNameAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<SupportNameBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetSupportName(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UserInfoBase>> GetUserInfoAsync(InputUserBase userId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UserInfoBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetUserInfo(){
UserId = userId,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<UserInfoBase>> EditUserInfoAsync(InputUserBase userId, string message, IList<MessageEntityBase> entities, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<UserInfoBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new EditUserInfo(){
UserId = userId,
Message = message,
Entities = entities,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<PromoDataBase>> GetPromoDataAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<PromoDataBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetPromoData(){
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> HidePromoDataAsync(InputPeerBase peer, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new HidePromoData(){
Peer = peer,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<bool>> DismissSuggestionAsync(string suggestion, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<bool>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new DismissSuggestion(){
Suggestion = suggestion,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	    public async Task<RpcMessage<CountriesListBase>> GetCountriesListAsync(string langCode, int hash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
		{

var rpcResponse = new RpcMessage<CountriesListBase>();
messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
var methodBody = new GetCountriesList(){
LangCode = langCode,
Hash = hash,
};

_messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
await taskCompletionSource;
return rpcResponse;
}

	}
}