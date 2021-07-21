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
	public partial class Messages
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Messages(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessagesAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessages()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>> GetDialogsAsync(int offsetDate, int offsetId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int limit, int hash, bool excludePinned = true, int? folderId = null, CancellationToken cancellationToken = default)
		{
			if(offsetPeer is null) throw new ArgumentNullException(nameof(offsetPeer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogs()
			{
				OffsetDate = offsetDate,
				OffsetId = offsetId,
				OffsetPeer = offsetPeer,
				Limit = limit,
				Hash = hash,
				ExcludePinned = excludePinned,
				FolderId = folderId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetHistory()
			{
				Peer = peer,
				OffsetId = offsetId,
				OffsetDate = offsetDate,
				AddOffset = addOffset,
				Limit = limit,
				MaxId = maxId,
				MinId = minId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> SearchAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, int hash, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase fromId = null, int? topMsgId = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(q is null) throw new ArgumentNullException(nameof(q));
if(filter is null) throw new ArgumentNullException(nameof(filter));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.Search()
			{
				Peer = peer,
				Q = q,
				Filter = filter,
				MinDate = minDate,
				MaxDate = maxDate,
				OffsetId = offsetId,
				AddOffset = addOffset,
				Limit = limit,
				MaxId = maxId,
				MinId = minId,
				Hash = hash,
				FromId = fromId,
				TopMsgId = topMsgId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> ReadHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadHistory()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> DeleteHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId, bool justClear = true, bool revoke = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteHistory()
			{
				Peer = peer,
				MaxId = maxId,
				JustClear = justClear,
				Revoke = revoke,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> DeleteMessagesAsync(IList<int> id, bool revoke = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteMessages()
			{
				Id = id,
				Revoke = revoke,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>>> ReceivedMessagesAsync(int maxId, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedMessages()
			{
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
		public async Task<RpcMessage<bool>> SetTypingAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action, int? topMsgId = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(action is null) throw new ArgumentNullException(nameof(action));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetTyping()
			{
				Peer = peer,
				Action = action,
				TopMsgId = topMsgId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message, long randomId, bool noWebpage = true, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase replyMarkup = null, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(message is null) throw new ArgumentNullException(nameof(message));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMessage()
			{
				Peer = peer,
				Message = message,
				RandomId = randomId,
				NoWebpage = noWebpage,
				Silent = silent,
				Background = background,
				ClearDraft = clearDraft,
				ReplyToMsgId = replyToMsgId,
				ReplyMarkup = replyMarkup,
				Entities = entities,
				ScheduleDate = scheduleDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, string message, long randomId, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase replyMarkup = null, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(media is null) throw new ArgumentNullException(nameof(media));
if(message is null) throw new ArgumentNullException(nameof(message));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMedia()
			{
				Peer = peer,
				Media = media,
				Message = message,
				RandomId = randomId,
				Silent = silent,
				Background = background,
				ClearDraft = clearDraft,
				ReplyToMsgId = replyToMsgId,
				ReplyMarkup = replyMarkup,
				Entities = entities,
				ScheduleDate = scheduleDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ForwardMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase fromPeer, IList<int> id, IList<long> randomId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase toPeer, bool silent = true, bool background = true, bool withMyScore = true, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			if(fromPeer is null) throw new ArgumentNullException(nameof(fromPeer));
if(toPeer is null) throw new ArgumentNullException(nameof(toPeer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ForwardMessages()
			{
				FromPeer = fromPeer,
				Id = id,
				RandomId = randomId,
				ToPeer = toPeer,
				Silent = silent,
				Background = background,
				WithMyScore = withMyScore,
				ScheduleDate = scheduleDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReportSpamAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportSpam()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>> GetPeerSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerSettings()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReportAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<int> id, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(reason is null) throw new ArgumentNullException(nameof(reason));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.Report()
			{
				Peer = peer,
				Id = id,
				Reason = reason,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetChatsAsync(IList<int> id, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetChats()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> GetFullChatAsync(int chatId, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFullChat()
			{
				ChatId = chatId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatTitleAsync(int chatId, string title, CancellationToken cancellationToken = default)
		{
			if(title is null) throw new ArgumentNullException(nameof(title));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatTitle()
			{
				ChatId = chatId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatPhotoAsync(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CancellationToken cancellationToken = default)
		{
			if(photo is null) throw new ArgumentNullException(nameof(photo));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatPhoto()
			{
				ChatId = chatId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> AddChatUserAsync(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int fwdLimit, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AddChatUser()
			{
				ChatId = chatId,
				UserId = userId,
				FwdLimit = fwdLimit,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteChatUserAsync(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteChatUser()
			{
				ChatId = chatId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateChatAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, string title, CancellationToken cancellationToken = default)
		{
			if(users is null) throw new ArgumentNullException(nameof(users));
if(title is null) throw new ArgumentNullException(nameof(title));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CreateChat()
			{
				Users = users,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase>> GetDhConfigAsync(int version, int randomLength, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDhConfig()
			{
				Version = version,
				RandomLength = randomLength,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> RequestEncryptionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gA, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));
if(gA is null) throw new ArgumentNullException(nameof(gA));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestEncryption()
			{
				UserId = userId,
				RandomId = randomId,
				GA = gA,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> AcceptEncryptionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] gB, long keyFingerprint, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(gB is null) throw new ArgumentNullException(nameof(gB));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptEncryption()
			{
				Peer = peer,
				GB = gB,
				KeyFingerprint = keyFingerprint,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> DiscardEncryptionAsync(int chatId, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscardEncryption()
			{
				ChatId = chatId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetEncryptedTypingAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, bool typing, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetEncryptedTyping()
			{
				Peer = peer,
				Typing = typing,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReadEncryptedHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, int maxDate, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadEncryptedHistory()
			{
				Peer = peer,
				MaxDate = maxDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, bool silent = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(data is null) throw new ArgumentNullException(nameof(data));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncrypted()
			{
				Peer = peer,
				RandomId = randomId,
				Data = data,
				Silent = silent,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, bool silent = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(data is null) throw new ArgumentNullException(nameof(data));
if(file is null) throw new ArgumentNullException(nameof(file));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedFile()
			{
				Peer = peer,
				RandomId = randomId,
				Data = data,
				File = file,
				Silent = silent,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedServiceAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(data is null) throw new ArgumentNullException(nameof(data));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendEncryptedService()
			{
				Peer = peer,
				RandomId = randomId,
				Data = data,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<long>>> ReceivedQueueAsync(int maxQts, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<IList<long>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReceivedQueue()
			{
				MaxQts = maxQts,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReportEncryptedSpamAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReportEncryptedSpam()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> ReadMessageContentsAsync(IList<int> id, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMessageContents()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase>> GetStickersAsync(string emoticon, int hash, CancellationToken cancellationToken = default)
		{
			if(emoticon is null) throw new ArgumentNullException(nameof(emoticon));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickers()
			{
				Emoticon = emoticon,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>> GetAllStickersAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllStickers()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> GetWebPagePreviewAsync(string message, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities = null, CancellationToken cancellationToken = default)
		{
			if(message is null) throw new ArgumentNullException(nameof(message));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPagePreview()
			{
				Message = message,
				Entities = entities,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>> ExportChatInviteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportChatInvite()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>> CheckChatInviteAsync(string hash, CancellationToken cancellationToken = default)
		{
			if(hash is null) throw new ArgumentNullException(nameof(hash));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.CheckChatInvite()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ImportChatInviteAsync(string hash, CancellationToken cancellationToken = default)
		{
			if(hash is null) throw new ArgumentNullException(nameof(hash));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ImportChatInvite()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> GetStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
			if(stickerset is null) throw new ArgumentNullException(nameof(stickerset));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStickerSet()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase>> InstallStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, bool archived, CancellationToken cancellationToken = default)
		{
			if(stickerset is null) throw new ArgumentNullException(nameof(stickerset));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.InstallStickerSet()
			{
				Stickerset = stickerset,
				Archived = archived,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UninstallStickerSetAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
			if(stickerset is null) throw new ArgumentNullException(nameof(stickerset));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UninstallStickerSet()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> StartBotAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, string startParam, CancellationToken cancellationToken = default)
		{
			if(bot is null) throw new ArgumentNullException(nameof(bot));
if(peer is null) throw new ArgumentNullException(nameof(peer));
if(startParam is null) throw new ArgumentNullException(nameof(startParam));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.StartBot()
			{
				Bot = bot,
				Peer = peer,
				RandomId = randomId,
				StartParam = startParam,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>> GetMessagesViewsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<int> id, bool increment, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessagesViews()
			{
				Peer = peer,
				Id = id,
				Increment = increment,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> EditChatAdminAsync(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, bool isAdmin, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAdmin()
			{
				ChatId = chatId,
				UserId = userId,
				IsAdmin = isAdmin,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> MigrateChatAsync(int chatId, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.MigrateChat()
			{
				ChatId = chatId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> SearchGlobalAsync(string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit, int? folderId = null, CancellationToken cancellationToken = default)
		{
			if(q is null) throw new ArgumentNullException(nameof(q));
if(filter is null) throw new ArgumentNullException(nameof(filter));
if(offsetPeer is null) throw new ArgumentNullException(nameof(offsetPeer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchGlobal()
			{
				Q = q,
				Filter = filter,
				MinDate = minDate,
				MaxDate = maxDate,
				OffsetRate = offsetRate,
				OffsetPeer = offsetPeer,
				OffsetId = offsetId,
				Limit = limit,
				FolderId = folderId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReorderStickerSetsAsync(IList<long> order, bool masks = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderStickerSets()
			{
				Order = order,
				Masks = masks,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>> GetDocumentByHashAsync(byte[] sha256, int size, string mimeType, CancellationToken cancellationToken = default)
		{
			if(sha256 is null) throw new ArgumentNullException(nameof(sha256));
if(mimeType is null) throw new ArgumentNullException(nameof(mimeType));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDocumentByHash()
			{
				Sha256 = sha256,
				Size = size,
				MimeType = mimeType,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase>> GetSavedGifsAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSavedGifs()
			{
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
		public async Task<RpcMessage<bool>> SaveGifAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveGif()
			{
				Id = id,
				Unsave = unsave,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>> GetInlineBotResultsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string query, string offset, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint = null, CancellationToken cancellationToken = default)
		{
			if(bot is null) throw new ArgumentNullException(nameof(bot));
if(peer is null) throw new ArgumentNullException(nameof(peer));
if(query is null) throw new ArgumentNullException(nameof(query));
if(offset is null) throw new ArgumentNullException(nameof(offset));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineBotResults()
			{
				Bot = bot,
				Peer = peer,
				Query = query,
				Offset = offset,
				GeoPoint = geoPoint,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetInlineBotResultsAsync(long queryId, IList<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> results, int cacheTime, bool gallery = true, bool pprivate = true, string nextOffset = null, CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase switchPm = null, CancellationToken cancellationToken = default)
		{
			if(results is null) throw new ArgumentNullException(nameof(results));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineBotResults()
			{
				QueryId = queryId,
				Results = results,
				CacheTime = cacheTime,
				Gallery = gallery,
				Private = pprivate,
				NextOffset = nextOffset,
				SwitchPm = switchPm,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendInlineBotResultAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, long queryId, string id, bool silent = true, bool background = true, bool clearDraft = true, bool hideVia = true, int? replyToMsgId = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendInlineBotResult()
			{
				Peer = peer,
				RandomId = randomId,
				QueryId = queryId,
				Id = id,
				Silent = silent,
				Background = background,
				ClearDraft = clearDraft,
				HideVia = hideVia,
				ReplyToMsgId = replyToMsgId,
				ScheduleDate = scheduleDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>> GetMessageEditDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMessageEditData()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, bool noWebpage = true, string message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase replyMarkup = null, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditMessage()
			{
				Peer = peer,
				Id = id,
				NoWebpage = noWebpage,
				Message = message,
				Media = media,
				ReplyMarkup = replyMarkup,
				Entities = entities,
				ScheduleDate = scheduleDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> EditInlineBotMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, bool noWebpage = true, string message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase replyMarkup = null, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities = null, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditInlineBotMessage()
			{
				Id = id,
				NoWebpage = noWebpage,
				Message = message,
				Media = media,
				ReplyMarkup = replyMarkup,
				Entities = entities,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>> GetBotCallbackAnswerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, bool game = true, byte[] data = null, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetBotCallbackAnswer()
			{
				Peer = peer,
				MsgId = msgId,
				Game = game,
				Data = data,
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
		public async Task<RpcMessage<bool>> SetBotCallbackAnswerAsync(long queryId, int cacheTime, bool alert = true, string message = null, string url = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotCallbackAnswer()
			{
				QueryId = queryId,
				CacheTime = cacheTime,
				Alert = alert,
				Message = message,
				Url = url,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>> GetPeerDialogsAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> peers, CancellationToken cancellationToken = default)
		{
			if(peers is null) throw new ArgumentNullException(nameof(peers));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPeerDialogs()
			{
				Peers = peers,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SaveDraftAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message, bool noWebpage = true, int? replyToMsgId = null, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(message is null) throw new ArgumentNullException(nameof(message));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveDraft()
			{
				Peer = peer,
				Message = message,
				NoWebpage = noWebpage,
				ReplyToMsgId = replyToMsgId,
				Entities = entities,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetAllDraftsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllDrafts()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>> GetFeaturedStickersAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFeaturedStickers()
			{
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
		public async Task<RpcMessage<bool>> ReadFeaturedStickersAsync(IList<long> id, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadFeaturedStickers()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase>> GetRecentStickersAsync(int hash, bool attached = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentStickers()
			{
				Hash = hash,
				Attached = attached,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SaveRecentStickerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave, bool attached = true, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SaveRecentSticker()
			{
				Id = id,
				Unsave = unsave,
				Attached = attached,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ClearRecentStickersAsync(bool attached = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearRecentStickers()
			{
				Attached = attached,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase>> GetArchivedStickersAsync(long offsetId, int limit, bool masks = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetArchivedStickers()
			{
				OffsetId = offsetId,
				Limit = limit,
				Masks = masks,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>> GetMaskStickersAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetMaskStickers()
			{
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
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>>> GetAttachedStickersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase media, CancellationToken cancellationToken = default)
		{
			if(media is null) throw new ArgumentNullException(nameof(media));

			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAttachedStickers()
			{
				Media = media,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetGameScoreAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score, bool editMessage = true, bool force = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetGameScore()
			{
				Peer = peer,
				Id = id,
				UserId = userId,
				Score = score,
				EditMessage = editMessage,
				Force = force,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetInlineGameScoreAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score, bool editMessage = true, bool force = true, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetInlineGameScore()
			{
				Id = id,
				UserId = userId,
				Score = score,
				EditMessage = editMessage,
				Force = force,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> GetGameHighScoresAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetGameHighScores()
			{
				Peer = peer,
				Id = id,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> GetInlineGameHighScoresAsync(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));
if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetInlineGameHighScores()
			{
				Id = id,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetCommonChatsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int maxId, int limit, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetCommonChats()
			{
				UserId = userId,
				MaxId = maxId,
				Limit = limit,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetAllChatsAsync(IList<int> exceptIds, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetAllChats()
			{
				ExceptIds = exceptIds,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>> GetWebPageAsync(string url, int hash, CancellationToken cancellationToken = default)
		{
			if(url is null) throw new ArgumentNullException(nameof(url));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetWebPage()
			{
				Url = url,
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
		public async Task<RpcMessage<bool>> ToggleDialogPinAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer, bool pinned = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleDialogPin()
			{
				Peer = peer,
				Pinned = pinned,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReorderPinnedDialogsAsync(int folderId, IList<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> order, bool force = true, CancellationToken cancellationToken = default)
		{
			if(order is null) throw new ArgumentNullException(nameof(order));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReorderPinnedDialogs()
			{
				FolderId = folderId,
				Order = order,
				Force = force,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>> GetPinnedDialogsAsync(int folderId, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPinnedDialogs()
			{
				FolderId = folderId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetBotShippingResultsAsync(long queryId, string error = null, IList<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> shippingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotShippingResults()
			{
				QueryId = queryId,
				Error = error,
				ShippingOptions = shippingOptions,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SetBotPrecheckoutResultsAsync(long queryId, bool success = true, string error = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SetBotPrecheckoutResults()
			{
				QueryId = queryId,
				Success = success,
				Error = error,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> UploadMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(media is null) throw new ArgumentNullException(nameof(media));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadMedia()
			{
				Peer = peer,
				Media = media,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendScreenshotNotificationAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int replyToMsgId, long randomId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScreenshotNotification()
			{
				Peer = peer,
				ReplyToMsgId = replyToMsgId,
				RandomId = randomId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase>> GetFavedStickersAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetFavedStickers()
			{
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
		public async Task<RpcMessage<bool>> FaveStickerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unfave, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.FaveSticker()
			{
				Id = id,
				Unfave = unfave,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetUnreadMentionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadMentions()
			{
				Peer = peer,
				OffsetId = offsetId,
				AddOffset = addOffset,
				Limit = limit,
				MaxId = maxId,
				MinId = minId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> ReadMentionsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadMentions()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetRecentLocationsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int limit, int hash, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetRecentLocations()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMultiMediaAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> multiMedia, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(multiMedia is null) throw new ArgumentNullException(nameof(multiMedia));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendMultiMedia()
			{
				Peer = peer,
				MultiMedia = multiMedia,
				Silent = silent,
				Background = background,
				ClearDraft = clearDraft,
				ReplyToMsgId = replyToMsgId,
				ScheduleDate = scheduleDate,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>> UploadEncryptedFileAsync(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(file is null) throw new ArgumentNullException(nameof(file));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UploadEncryptedFile()
			{
				Peer = peer,
				File = file,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase>> SearchStickerSetsAsync(string q, int hash, bool excludeFeatured = true, CancellationToken cancellationToken = default)
		{
			if(q is null) throw new ArgumentNullException(nameof(q));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchStickerSets()
			{
				Q = q,
				Hash = hash,
				ExcludeFeatured = excludeFeatured,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>>> GetSplitRangesAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSplitRanges()
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
		public async Task<RpcMessage<bool>> MarkDialogUnreadAsync(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer, bool unread = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.MarkDialogUnread()
			{
				Peer = peer,
				Unread = unread,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>>> GetDialogUnreadMarksAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogUnreadMarks()
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
		public async Task<RpcMessage<bool>> ClearAllDraftsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ClearAllDrafts()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> UpdatePinnedMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, bool silent = true, bool unpin = true, bool pmOneside = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdatePinnedMessage()
			{
				Peer = peer,
				Id = id,
				Silent = silent,
				Unpin = unpin,
				PmOneside = pmOneside,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendVoteAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, IList<byte[]> options, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(options is null) throw new ArgumentNullException(nameof(options));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendVote()
			{
				Peer = peer,
				MsgId = msgId,
				Options = options,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetPollResultsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollResults()
			{
				Peer = peer,
				MsgId = msgId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>> GetOnlinesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOnlines()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StatsURLBase>> GetStatsURLAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string pparams, bool dark = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(pparams is null) throw new ArgumentNullException(nameof(pparams));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StatsURLBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetStatsURL()
			{
				Peer = peer,
				Params = pparams,
				Dark = dark,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> EditChatAboutAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string about, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(about is null) throw new ArgumentNullException(nameof(about));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatAbout()
			{
				Peer = peer,
				About = about,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatDefaultBannedRightsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(bannedRights is null) throw new ArgumentNullException(nameof(bannedRights));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.EditChatDefaultBannedRights()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>> GetEmojiKeywordsAsync(string langCode, CancellationToken cancellationToken = default)
		{
			if(langCode is null) throw new ArgumentNullException(nameof(langCode));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywords()
			{
				LangCode = langCode,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>> GetEmojiKeywordsDifferenceAsync(string langCode, int fromVersion, CancellationToken cancellationToken = default)
		{
			if(langCode is null) throw new ArgumentNullException(nameof(langCode));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywordsDifference()
			{
				LangCode = langCode,
				FromVersion = fromVersion,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>>> GetEmojiKeywordsLanguagesAsync(IList<string> langCodes, CancellationToken cancellationToken = default)
		{
			if(langCodes is null) throw new ArgumentNullException(nameof(langCodes));

			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiKeywordsLanguages()
			{
				LangCodes = langCodes,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase>> GetEmojiURLAsync(string langCode, CancellationToken cancellationToken = default)
		{
			if(langCode is null) throw new ArgumentNullException(nameof(langCode));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetEmojiURL()
			{
				LangCode = langCode,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>> GetSearchCountersAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> filters, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(filters is null) throw new ArgumentNullException(nameof(filters));

			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSearchCounters()
			{
				Peer = peer,
				Filters = filters,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> RequestUrlAuthAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int buttonId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.RequestUrlAuth()
			{
				Peer = peer,
				MsgId = msgId,
				ButtonId = buttonId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> AcceptUrlAuthAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int buttonId, bool writeAllowed = true, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.AcceptUrlAuth()
			{
				Peer = peer,
				MsgId = msgId,
				ButtonId = buttonId,
				WriteAllowed = writeAllowed,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> HidePeerSettingsBarAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.HidePeerSettingsBar()
			{
				Peer = peer,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetScheduledHistoryAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int hash, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledHistory()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetScheduledMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<int> id, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetScheduledMessages()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendScheduledMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<int> id, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.SendScheduledMessages()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteScheduledMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<int> id, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.DeleteScheduledMessages()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>> GetPollVotesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, int limit, byte[] option = null, string offset = null, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollVotes()
			{
				Peer = peer,
				Id = id,
				Limit = limit,
				Option = option,
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
		public async Task<RpcMessage<bool>> ToggleStickerSetsAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> stickersets, bool uninstall = true, bool archive = true, bool unarchive = true, CancellationToken cancellationToken = default)
		{
			if(stickersets is null) throw new ArgumentNullException(nameof(stickersets));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ToggleStickerSets()
			{
				Stickersets = stickersets,
				Uninstall = uninstall,
				Archive = archive,
				Unarchive = unarchive,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>>> GetDialogFiltersAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDialogFilters()
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
		public async Task<RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>>> GetSuggestedDialogFiltersAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<IList<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetSuggestedDialogFilters()
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
		public async Task<RpcMessage<bool>> UpdateDialogFilterAsync(int id, CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase filter = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFilter()
			{
				Id = id,
				Filter = filter,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UpdateDialogFiltersOrderAsync(IList<int> order, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFiltersOrder()
			{
				Order = order,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>> GetOldFeaturedStickersAsync(int offset, int limit, int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetOldFeaturedStickers()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetRepliesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetReplies()
			{
				Peer = peer,
				MsgId = msgId,
				OffsetId = offsetId,
				OffsetDate = offsetDate,
				AddOffset = addOffset,
				Limit = limit,
				MaxId = maxId,
				MinId = minId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>> GetDiscussionMessageAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.GetDiscussionMessage()
			{
				Peer = peer,
				MsgId = msgId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReadDiscussionAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int readMaxId, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.ReadDiscussion()
			{
				Peer = peer,
				MsgId = msgId,
				ReadMaxId = readMaxId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> UnpinAllMessagesAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Messages.UnpinAllMessages()
			{
				Peer = peer,
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