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
	public partial class Channels
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Channels(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<bool>> ReadHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory()
			{
				Channel = channel,
				MaxId = maxId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> DeleteMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, IList<int> id, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages()
			{
				Channel = channel,
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> DeleteUserHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteUserHistory()
			{
				Channel = channel,
				UserId = userId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReportSpamAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, IList<int> id, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam()
			{
				Channel = channel,
				UserId = userId,
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, IList<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages()
			{
				Channel = channel,
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>> GetParticipantsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase filter, int offset, int limit, int hash, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(filter is null) throw new ArgumentNullException(nameof(filter));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipants()
			{
				Channel = channel,
				Filter = filter,
				Offset = offset,
				Limit = limit,
				Hash = hash,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>> GetParticipantAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetParticipant()
			{
				Channel = channel,
				UserId = userId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetChannelsAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase> id, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetChannels()
			{
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> GetFullChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetFullChannel()
			{
				Channel = channel,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateChannelAsync(string title, string about, bool broadcast = true, bool megagroup = true, bool forImport = true, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint = null, string address = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(title is null) throw new ArgumentNullException(nameof(title));
if(about is null) throw new ArgumentNullException(nameof(about));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.CreateChannel()
			{
				Title = title,
				About = about,
				Broadcast = broadcast,
				Megagroup = megagroup,
				ForImport = forImport,
				GeoPoint = geoPoint,
				Address = address,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditAdminAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights, string rank, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(userId is null) throw new ArgumentNullException(nameof(userId));
if(adminRights is null) throw new ArgumentNullException(nameof(adminRights));
if(rank is null) throw new ArgumentNullException(nameof(rank));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditAdmin()
			{
				Channel = channel,
				UserId = userId,
				AdminRights = adminRights,
				Rank = rank,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditTitleAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string title, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(title is null) throw new ArgumentNullException(nameof(title));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditTitle()
			{
				Channel = channel,
				Title = title,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditPhotoAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(photo is null) throw new ArgumentNullException(nameof(photo));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditPhoto()
			{
				Channel = channel,
				Photo = photo,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> CheckUsernameAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string username, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(username is null) throw new ArgumentNullException(nameof(username));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.CheckUsername()
			{
				Channel = channel,
				Username = username,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UpdateUsernameAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string username, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(username is null) throw new ArgumentNullException(nameof(username));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.UpdateUsername()
			{
				Channel = channel,
				Username = username,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> JoinChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.JoinChannel()
			{
				Channel = channel,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> LeaveChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.LeaveChannel()
			{
				Channel = channel,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InviteToChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(users is null) throw new ArgumentNullException(nameof(users));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.InviteToChannel()
			{
				Channel = channel,
				Users = users,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteChannelAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteChannel()
			{
				Channel = channel,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>> ExportMessageLinkAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int id, bool grouped = true, bool thread = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ExportMessageLink()
			{
				Channel = channel,
				Id = id,
				Grouped = grouped,
				Thread = thread,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleSignaturesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSignatures()
			{
				Channel = channel,
				Enabled = enabled,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetAdminedPublicChannelsAsync(bool byLocation = true, bool checkLimit = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminedPublicChannels()
			{
				ByLocation = byLocation,
				CheckLimit = checkLimit,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditBannedAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(userId is null) throw new ArgumentNullException(nameof(userId));
if(bannedRights is null) throw new ArgumentNullException(nameof(bannedRights));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditBanned()
			{
				Channel = channel,
				UserId = userId,
				BannedRights = bannedRights,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>> GetAdminLogAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string q, long maxId, long minId, int limit, CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase eventsFilter = null, IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> admins = null, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(q is null) throw new ArgumentNullException(nameof(q));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetAdminLog()
			{
				Channel = channel,
				Q = q,
				MaxId = maxId,
				MinId = minId,
				Limit = limit,
				EventsFilter = eventsFilter,
				Admins = admins,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetStickersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(stickerset is null) throw new ArgumentNullException(nameof(stickerset));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetStickers()
			{
				Channel = channel,
				Stickerset = stickerset,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReadMessageContentsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, IList<int> id, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents()
			{
				Channel = channel,
				Id = id,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> DeleteHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory()
			{
				Channel = channel,
				MaxId = maxId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> TogglePreHistoryHiddenAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.TogglePreHistoryHidden()
			{
				Channel = channel,
				Enabled = enabled,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetLeftChannelsAsync(int offset, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetLeftChannels()
			{
				Offset = offset,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetGroupsForDiscussionAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetGroupsForDiscussion()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetDiscussionGroupAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase broadcast, CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase group, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(broadcast is null) throw new ArgumentNullException(nameof(broadcast));
if(group is null) throw new ArgumentNullException(nameof(group));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.SetDiscussionGroup()
			{
				Broadcast = broadcast,
				Group = group,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditCreatorAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(userId is null) throw new ArgumentNullException(nameof(userId));
if(password is null) throw new ArgumentNullException(nameof(password));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditCreator()
			{
				Channel = channel,
				UserId = userId,
				Password = password,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> EditLocationAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string address, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));
if(geoPoint is null) throw new ArgumentNullException(nameof(geoPoint));
if(address is null) throw new ArgumentNullException(nameof(address));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.EditLocation()
			{
				Channel = channel,
				GeoPoint = geoPoint,
				Address = address,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleSlowModeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int seconds, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(channel is null) throw new ArgumentNullException(nameof(channel));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.ToggleSlowMode()
			{
				Channel = channel,
				Seconds = seconds,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase>> GetInactiveChannelsAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Channels.GetInactiveChannels()
			{
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}

	}
}