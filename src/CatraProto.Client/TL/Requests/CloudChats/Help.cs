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
	public partial class Help
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Help(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ConfigBase>> GetConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ConfigBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetConfig()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase>> GetNearestDcAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetNearestDc()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase>> GetAppUpdateAsync(string source, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(source is null) throw new ArgumentNullException(nameof(source));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppUpdate()
			{
				Source = source,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase>> GetInviteTextAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.InviteTextBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetInviteText()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase>> GetSupportAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetSupport()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetAppChangelogAsync(string prevAppVersion, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(prevAppVersion is null) throw new ArgumentNullException(nameof(prevAppVersion));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppChangelog()
			{
				PrevAppVersion = prevAppVersion,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetBotUpdatesStatusAsync(int pendingUpdatesCount, string message, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(message is null) throw new ArgumentNullException(nameof(message));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.SetBotUpdatesStatus()
			{
				PendingUpdatesCount = pendingUpdatesCount,
				Message = message,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase>> GetCdnConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.CdnConfigBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCdnConfig()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase>> GetRecentMeUrlsAsync(string referer, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(referer is null) throw new ArgumentNullException(nameof(referer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.RecentMeUrlsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetRecentMeUrls()
			{
				Referer = referer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase>> GetTermsOfServiceUpdateAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetTermsOfServiceUpdate()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> AcceptTermsOfServiceAsync(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase id, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.AcceptTermsOfService()
			{
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase>> GetDeepLinkInfoAsync(string path, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(path is null) throw new ArgumentNullException(nameof(path));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetDeepLinkInfo()
			{
				Path = path,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>> GetAppConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetAppConfig()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SaveAppLogAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase> events, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(events is null) throw new ArgumentNullException(nameof(events));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.SaveAppLog()
			{
				Events = events,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase>> GetPassportConfigAsync(int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPassportConfig()
			{
				Hash = hash,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportNameBase>> GetSupportNameAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.SupportNameBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetSupportName()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>> GetUserInfoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetUserInfo()
			{
				UserId = userId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>> EditUserInfoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string message, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));
if(message is null) throw new ArgumentNullException(nameof(message));
if(entities is null) throw new ArgumentNullException(nameof(entities));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.EditUserInfo()
			{
				UserId = userId,
				Message = message,
				Entities = entities,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataBase>> GetPromoDataAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetPromoData()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> HidePromoDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.HidePromoData()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> DismissSuggestionAsync(string suggestion, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(suggestion is null) throw new ArgumentNullException(nameof(suggestion));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.DismissSuggestion()
			{
				Suggestion = suggestion,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase>> GetCountriesListAsync(string langCode, int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(langCode is null) throw new ArgumentNullException(nameof(langCode));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Help.GetCountriesList()
			{
				LangCode = langCode,
				Hash = hash,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions
				}, rpcResponse);
			return rpcResponse;
		}

	}
}