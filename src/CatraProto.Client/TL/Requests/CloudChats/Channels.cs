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
	    
	    		public async Task<RpcMessage<bool>> ReadHistory(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> DeleteMessages(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<int> id, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> DeleteUserHistory(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReportSpam(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, List<int> id, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessages(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase>> GetParticipants(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase filter, int offset, int limit, int hash, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase>> GetParticipant(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetChannels(List<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase> id, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> GetFullChannel(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateChannel(string title, string about, bool broadcast = true, bool megagroup = true, bool forImport = true, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase? geoPoint = null, string address = null, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditAdmin(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase adminRights, string rank, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditTitle(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string title, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> CheckUsername(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string username, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UpdateUsername(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string username, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> JoinChannel(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> LeaveChannel(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> InviteToChannel(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteChannel(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase>> ExportMessageLink(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int id, bool grouped = true, bool thread = true, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleSignatures(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetAdminedPublicChannels(bool byLocation = true, bool checkLimit = true, CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditBanned(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase>> GetAdminLog(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, string q, long maxId, long minId, int limit, CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventsFilterBase? eventsFilter = null, List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>? admins = null, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetStickers(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReadMessageContents(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, List<int> id, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> DeleteHistory(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int maxId, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> TogglePreHistoryHidden(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, bool enabled, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetLeftChannels(int offset, CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetGroupsForDiscussion( CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetDiscussionGroup(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase broadcast, CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase group, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditCreator(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> EditLocation(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, string address, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ToggleSlowMode(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int seconds, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase>> GetInactiveChannels( CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}

	}
}