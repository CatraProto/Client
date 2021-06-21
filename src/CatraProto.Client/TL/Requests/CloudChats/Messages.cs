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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetMessages(List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase>> GetDialogs(int offsetDate, int offsetId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int limit, int hash, bool excludePinned = true, int? folderId = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetHistory(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> Search(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, int hash, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase? fromId = null, int? topMsgId = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> ReadHistory(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> DeleteHistory(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId, bool justClear = true, bool revoke = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> DeleteMessages(List<int> id, bool revoke = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>> ReceivedMessages(int maxId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ReceivedNotifyMessageBase>();
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
		public async Task<RpcMessage<bool>> SetTyping(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase action, int? topMsgId = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMessage(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message, long randomId, bool noWebpage = true, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, string message, long randomId, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ForwardMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase fromPeer, List<int> id, List<long> randomId, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase toPeer, bool silent = true, bool background = true, bool withMyScore = true, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ReportSpam(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>> GetPeerSettings(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> Report(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetChats(List<int> id, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase>> GetFullChat(int chatId, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatTitle(int chatId, string title, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatPhoto(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputChatPhotoBase photo, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> AddChatUser(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int fwdLimit, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteChatUser(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> CreateChat(List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users, string title, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase>> GetDhConfig(int version, int randomLength, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> RequestEncryption(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gA, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>> AcceptEncryption(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] gB, long keyFingerprint, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> DiscardEncryption(int chatId, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SetEncryptedTyping(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, bool typing, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ReadEncryptedHistory(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, int maxDate, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncrypted(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, bool silent = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedFile(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, bool silent = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>> SendEncryptedService(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, long randomId, byte[] data, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<long>> ReceivedQueue(int maxQts, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<long>();
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
		public async Task<RpcMessage<bool>> ReportEncryptedSpam(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase>> ReadMessageContents(List<int> id, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickersBase>> GetStickers(string emoticon, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>> GetAllStickers(int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> GetWebPagePreview(string message, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>> ExportChatInvite(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>> CheckChatInvite(string hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> ImportChatInvite(string hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase>> GetStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetInstallResultBase>> InstallStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, bool archived, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> UninstallStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> StartBot(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, string startParam, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase>> GetMessagesViews(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, bool increment, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> EditChatAdmin(int chatId, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, bool isAdmin, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> MigrateChat(int chatId, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> SearchGlobal(string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit, int? folderId = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ReorderStickerSets(List<long> order, bool masks = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>> GetDocumentByHash(byte[] sha256, int size, string mimeType, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase>> GetSavedGifs(int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SaveGif(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase>> GetInlineBotResults(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string query, string offset, CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase? geoPoint = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SetInlineBotResults(long queryId, List<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase> results, int cacheTime, bool gallery = true, bool pprivate = true, string nextOffset = null, CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase? switchPm = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendInlineBotResult(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long randomId, long queryId, string id, bool silent = true, bool background = true, bool clearDraft = true, bool hideVia = true, int? replyToMsgId = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase>> GetMessageEditData(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditMessage(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, bool noWebpage = true, string message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase? media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> EditInlineBotMessage(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, bool noWebpage = true, string message = null, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase? media = null, CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase? replyMarkup = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase>> GetBotCallbackAnswer(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, bool game = true, byte[]? data = null, CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase? password = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SetBotCallbackAnswer(long queryId, int cacheTime, bool alert = true, string message = null, string url = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>> GetPeerDialogs(List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> peers, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SaveDraft(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message, bool noWebpage = true, int? replyToMsgId = null, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>? entities = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetAllDrafts( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>> GetFeaturedStickers(int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ReadFeaturedStickers(List<long> id, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.RecentStickersBase>> GetRecentStickers(int hash, bool attached = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SaveRecentSticker(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave, bool attached = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ClearRecentStickers(bool attached = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase>> GetArchivedStickers(long offsetId, int limit, bool masks = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase>> GetMaskStickers(int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>> GetAttachedStickers(CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase media, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetGameScore(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score, bool editMessage = true, bool force = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SetInlineGameScore(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int score, bool editMessage = true, bool force = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> GetGameHighScores(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.HighScoresBase>> GetInlineGameHighScores(CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase id, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetCommonChats(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int maxId, int limit, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase>> GetAllChats(List<int> exceptIds, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WebPageBase>> GetWebPage(string url, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ToggleDialogPin(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer, bool pinned = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ReorderPinnedDialogs(int folderId, List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> order, bool force = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase>> GetPinnedDialogs(int folderId, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SetBotShippingResults(long queryId, string error = null, List<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>? shippingOptions = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SetBotPrecheckoutResults(long queryId, bool success = true, string error = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>> UploadMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendScreenshotNotification(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int replyToMsgId, long randomId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase>> GetFavedStickers(int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> FaveSticker(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unfave, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetUnreadMentions(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> ReadMentions(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetRecentLocations(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int limit, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendMultiMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.InputSingleMediaBase> multiMedia, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>> UploadEncryptedFile(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase file, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase>> SearchStickerSets(string q, int hash, bool excludeFeatured = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>> GetSplitRanges( CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
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
		public async Task<RpcMessage<bool>> MarkDialogUnread(CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase peer, bool unread = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>> GetDialogUnreadMarks( CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>();
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
		public async Task<RpcMessage<bool>> ClearAllDrafts( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> UpdatePinnedMessage(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, bool silent = true, bool unpin = true, bool pmOneside = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendVote(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, List<byte[]> options, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetPollResults(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ChatOnlinesBase>> GetOnlines(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.StatsURLBase>> GetStatsURL(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string pparams, bool dark = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> EditChatAbout(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string about, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> EditChatDefaultBannedRights(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>> GetEmojiKeywords(string langCode, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase>> GetEmojiKeywordsDifference(string langCode, int fromVersion, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>> GetEmojiKeywordsLanguages(List<string> langCodes, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiLanguageBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase>> GetEmojiURL(string langCode, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>> GetSearchCounters(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> filters, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> RequestUrlAuth(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int buttonId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase>> AcceptUrlAuth(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int buttonId, bool writeAllowed = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> HidePeerSettingsBar(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetScheduledHistory(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetScheduledMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SendScheduledMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteScheduledMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase>> GetPollVotes(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, int limit, byte[]? option = null, string offset = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ToggleStickerSets(List<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase> stickersets, bool uninstall = true, bool archive = true, bool unarchive = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>> GetDialogFilters( CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>> GetSuggestedDialogFilters( CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase>();
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
		public async Task<RpcMessage<bool>> UpdateDialogFilter(int id, CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase? filter = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> UpdateDialogFiltersOrder(List<int> order, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase>> GetOldFeaturedStickers(int offset, int limit, int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase>> GetReplies(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase>> GetDiscussionMessage(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ReadDiscussion(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int readMaxId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase>> UnpinAllMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
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