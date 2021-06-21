using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using ChatFullBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase;
using MessageViewsBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase;
using StickerSetBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase;
using UpdateDialogFilter = CatraProto.Client.TL.Schemas.CloudChats.Messages.UpdateDialogFilter;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Messages
	{
		private MessagesHandler _messagesHandler;

		internal Messages(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<MessagesBase>> GetMessages(List<InputMessageBase> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetMessages
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

		public async Task<RpcMessage<DialogsBase>> GetDialogs(int offsetDate, int offsetId, InputPeerBase offsetPeer, int limit, int hash, bool excludePinned = true, int? folderId = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DialogsBase>();
			var methodBody = new GetDialogs
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

		public async Task<RpcMessage<MessagesBase>> GetHistory(InputPeerBase peer, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetHistory
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

		public async Task<RpcMessage<MessagesBase>> Search(InputPeerBase peer, string q, MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, int hash, InputPeerBase? fromId = null, int? topMsgId = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new Search
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

		public async Task<RpcMessage<AffectedMessagesBase>> ReadHistory(InputPeerBase peer, int maxId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedMessagesBase>();
			var methodBody = new ReadHistory
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

		public async Task<RpcMessage<AffectedHistoryBase>> DeleteHistory(InputPeerBase peer, int maxId, bool justClear = true, bool revoke = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedHistoryBase>();
			var methodBody = new DeleteHistory
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

		public async Task<RpcMessage<AffectedMessagesBase>> DeleteMessages(List<int> id, bool revoke = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedMessagesBase>();
			var methodBody = new DeleteMessages
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

		public async Task<RpcMessage<ReceivedNotifyMessageBase>> ReceivedMessages(int maxId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ReceivedNotifyMessageBase>();
			var methodBody = new ReceivedMessages
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

		public async Task<RpcMessage<bool>> SetTyping(InputPeerBase peer, SendMessageActionBase action, int? topMsgId = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SetTyping
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

		public async Task<RpcMessage<UpdatesBase>> SendMessage(InputPeerBase peer, string message, long randomId, bool noWebpage = true, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, ReplyMarkupBase? replyMarkup = null, List<MessageEntityBase>? entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendMessage
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

		public async Task<RpcMessage<UpdatesBase>> SendMedia(InputPeerBase peer, InputMediaBase media, string message, long randomId, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, ReplyMarkupBase? replyMarkup = null, List<MessageEntityBase>? entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendMedia
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

		public async Task<RpcMessage<UpdatesBase>> ForwardMessages(InputPeerBase fromPeer, List<int> id, List<long> randomId, InputPeerBase toPeer, bool silent = true, bool background = true, bool withMyScore = true, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new ForwardMessages
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

		public async Task<RpcMessage<bool>> ReportSpam(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ReportSpam
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

		public async Task<RpcMessage<PeerSettingsBase>> GetPeerSettings(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PeerSettingsBase>();
			var methodBody = new GetPeerSettings
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

		public async Task<RpcMessage<bool>> Report(InputPeerBase peer, List<int> id, ReportReasonBase reason, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new Report
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

		public async Task<RpcMessage<ChatsBase>> GetChats(List<int> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			var methodBody = new GetChats
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

		public async Task<RpcMessage<ChatFullBase>> GetFullChat(int chatId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatFullBase>();
			var methodBody = new GetFullChat
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

		public async Task<RpcMessage<UpdatesBase>> EditChatTitle(int chatId, string title, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new EditChatTitle
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

		public async Task<RpcMessage<UpdatesBase>> EditChatPhoto(int chatId, InputChatPhotoBase photo, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new EditChatPhoto
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

		public async Task<RpcMessage<UpdatesBase>> AddChatUser(int chatId, InputUserBase userId, int fwdLimit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new AddChatUser
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

		public async Task<RpcMessage<UpdatesBase>> DeleteChatUser(int chatId, InputUserBase userId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new DeleteChatUser
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

		public async Task<RpcMessage<UpdatesBase>> CreateChat(List<InputUserBase> users, string title, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new CreateChat
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

		public async Task<RpcMessage<DhConfigBase>> GetDhConfig(int version, int randomLength, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DhConfigBase>();
			var methodBody = new GetDhConfig
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

		public async Task<RpcMessage<EncryptedChatBase>> RequestEncryption(InputUserBase userId, int randomId, byte[] gA, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EncryptedChatBase>();
			var methodBody = new RequestEncryption
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

		public async Task<RpcMessage<EncryptedChatBase>> AcceptEncryption(InputEncryptedChatBase peer, byte[] gB, long keyFingerprint, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EncryptedChatBase>();
			var methodBody = new AcceptEncryption
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
			var methodBody = new DiscardEncryption
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

		public async Task<RpcMessage<bool>> SetEncryptedTyping(InputEncryptedChatBase peer, bool typing, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SetEncryptedTyping
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

		public async Task<RpcMessage<bool>> ReadEncryptedHistory(InputEncryptedChatBase peer, int maxDate, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ReadEncryptedHistory
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

		public async Task<RpcMessage<SentEncryptedMessageBase>> SendEncrypted(InputEncryptedChatBase peer, long randomId, byte[] data, bool silent = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentEncryptedMessageBase>();
			var methodBody = new SendEncrypted
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

		public async Task<RpcMessage<SentEncryptedMessageBase>> SendEncryptedFile(InputEncryptedChatBase peer, long randomId, byte[] data, InputEncryptedFileBase file, bool silent = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentEncryptedMessageBase>();
			var methodBody = new SendEncryptedFile
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

		public async Task<RpcMessage<SentEncryptedMessageBase>> SendEncryptedService(InputEncryptedChatBase peer, long randomId, byte[] data, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentEncryptedMessageBase>();
			var methodBody = new SendEncryptedService
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
			var methodBody = new ReceivedQueue
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

		public async Task<RpcMessage<bool>> ReportEncryptedSpam(InputEncryptedChatBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ReportEncryptedSpam
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

		public async Task<RpcMessage<AffectedMessagesBase>> ReadMessageContents(List<int> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedMessagesBase>();
			var methodBody = new ReadMessageContents
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

		public async Task<RpcMessage<StickersBase>> GetStickers(string emoticon, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickersBase>();
			var methodBody = new GetStickers
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

		public async Task<RpcMessage<AllStickersBase>> GetAllStickers(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AllStickersBase>();
			var methodBody = new GetAllStickers
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

		public async Task<RpcMessage<MessageMediaBase>> GetWebPagePreview(string message, List<MessageEntityBase>? entities = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessageMediaBase>();
			var methodBody = new GetWebPagePreview
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

		public async Task<RpcMessage<ExportedChatInviteBase>> ExportChatInvite(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ExportedChatInviteBase>();
			var methodBody = new ExportChatInvite
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

		public async Task<RpcMessage<ChatInviteBase>> CheckChatInvite(string hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatInviteBase>();
			var methodBody = new CheckChatInvite
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

		public async Task<RpcMessage<UpdatesBase>> ImportChatInvite(string hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new ImportChatInvite
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

		public async Task<RpcMessage<StickerSetBase>> GetStickerSet(InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetBase>();
			var methodBody = new GetStickerSet
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

		public async Task<RpcMessage<StickerSetInstallResultBase>> InstallStickerSet(InputStickerSetBase stickerset, bool archived, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetInstallResultBase>();
			var methodBody = new InstallStickerSet
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

		public async Task<RpcMessage<bool>> UninstallStickerSet(InputStickerSetBase stickerset, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new UninstallStickerSet
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

		public async Task<RpcMessage<UpdatesBase>> StartBot(InputUserBase bot, InputPeerBase peer, long randomId, string startParam, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new StartBot
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

		public async Task<RpcMessage<MessageViewsBase>> GetMessagesViews(InputPeerBase peer, List<int> id, bool increment, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessageViewsBase>();
			var methodBody = new GetMessagesViews
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

		public async Task<RpcMessage<bool>> EditChatAdmin(int chatId, InputUserBase userId, bool isAdmin, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new EditChatAdmin
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

		public async Task<RpcMessage<UpdatesBase>> MigrateChat(int chatId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new MigrateChat
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

		public async Task<RpcMessage<MessagesBase>> SearchGlobal(string q, MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, InputPeerBase offsetPeer, int offsetId, int limit, int? folderId = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new SearchGlobal
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
			var methodBody = new ReorderStickerSets
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

		public async Task<RpcMessage<DocumentBase>> GetDocumentByHash(byte[] sha256, int size, string mimeType, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DocumentBase>();
			var methodBody = new GetDocumentByHash
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

		public async Task<RpcMessage<SavedGifsBase>> GetSavedGifs(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SavedGifsBase>();
			var methodBody = new GetSavedGifs
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

		public async Task<RpcMessage<bool>> SaveGif(InputDocumentBase id, bool unsave, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveGif
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

		public async Task<RpcMessage<BotResultsBase>> GetInlineBotResults(InputUserBase bot, InputPeerBase peer, string query, string offset, InputGeoPointBase? geoPoint = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<BotResultsBase>();
			var methodBody = new GetInlineBotResults
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

		public async Task<RpcMessage<bool>> SetInlineBotResults(long queryId, List<InputBotInlineResultBase> results, int cacheTime, bool gallery = true, bool pprivate = true, string nextOffset = null, InlineBotSwitchPMBase? switchPm = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SetInlineBotResults
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

		public async Task<RpcMessage<UpdatesBase>> SendInlineBotResult(InputPeerBase peer, long randomId, long queryId, string id, bool silent = true, bool background = true, bool clearDraft = true, bool hideVia = true, int? replyToMsgId = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendInlineBotResult
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

		public async Task<RpcMessage<MessageEditDataBase>> GetMessageEditData(InputPeerBase peer, int id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessageEditDataBase>();
			var methodBody = new GetMessageEditData
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

		public async Task<RpcMessage<UpdatesBase>> EditMessage(InputPeerBase peer, int id, bool noWebpage = true, string message = null, InputMediaBase? media = null, ReplyMarkupBase? replyMarkup = null, List<MessageEntityBase>? entities = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new EditMessage
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

		public async Task<RpcMessage<bool>> EditInlineBotMessage(InputBotInlineMessageIDBase id, bool noWebpage = true, string message = null, InputMediaBase? media = null, ReplyMarkupBase? replyMarkup = null, List<MessageEntityBase>? entities = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new EditInlineBotMessage
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

		public async Task<RpcMessage<BotCallbackAnswerBase>> GetBotCallbackAnswer(InputPeerBase peer, int msgId, bool game = true, byte[]? data = null, InputCheckPasswordSRPBase? password = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<BotCallbackAnswerBase>();
			var methodBody = new GetBotCallbackAnswer
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
			var methodBody = new SetBotCallbackAnswer
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

		public async Task<RpcMessage<PeerDialogsBase>> GetPeerDialogs(List<InputDialogPeerBase> peers, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PeerDialogsBase>();
			var methodBody = new GetPeerDialogs
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

		public async Task<RpcMessage<bool>> SaveDraft(InputPeerBase peer, string message, bool noWebpage = true, int? replyToMsgId = null, List<MessageEntityBase>? entities = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveDraft
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

		public async Task<RpcMessage<UpdatesBase>> GetAllDrafts(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new GetAllDrafts();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<FeaturedStickersBase>> GetFeaturedStickers(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FeaturedStickersBase>();
			var methodBody = new GetFeaturedStickers
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
			var methodBody = new ReadFeaturedStickers
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

		public async Task<RpcMessage<RecentStickersBase>> GetRecentStickers(int hash, bool attached = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RecentStickersBase>();
			var methodBody = new GetRecentStickers
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

		public async Task<RpcMessage<bool>> SaveRecentSticker(InputDocumentBase id, bool unsave, bool attached = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveRecentSticker
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
			var methodBody = new ClearRecentStickers
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

		public async Task<RpcMessage<ArchivedStickersBase>> GetArchivedStickers(long offsetId, int limit, bool masks = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ArchivedStickersBase>();
			var methodBody = new GetArchivedStickers
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

		public async Task<RpcMessage<AllStickersBase>> GetMaskStickers(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AllStickersBase>();
			var methodBody = new GetMaskStickers
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

		public async Task<RpcMessage<StickerSetCoveredBase>> GetAttachedStickers(InputStickeredMediaBase media, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StickerSetCoveredBase>();
			var methodBody = new GetAttachedStickers
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

		public async Task<RpcMessage<UpdatesBase>> SetGameScore(InputPeerBase peer, int id, InputUserBase userId, int score, bool editMessage = true, bool force = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SetGameScore
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

		public async Task<RpcMessage<bool>> SetInlineGameScore(InputBotInlineMessageIDBase id, InputUserBase userId, int score, bool editMessage = true, bool force = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SetInlineGameScore
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

		public async Task<RpcMessage<HighScoresBase>> GetGameHighScores(InputPeerBase peer, int id, InputUserBase userId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<HighScoresBase>();
			var methodBody = new GetGameHighScores
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

		public async Task<RpcMessage<HighScoresBase>> GetInlineGameHighScores(InputBotInlineMessageIDBase id, InputUserBase userId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<HighScoresBase>();
			var methodBody = new GetInlineGameHighScores
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

		public async Task<RpcMessage<ChatsBase>> GetCommonChats(InputUserBase userId, int maxId, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			var methodBody = new GetCommonChats
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

		public async Task<RpcMessage<ChatsBase>> GetAllChats(List<int> exceptIds, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatsBase>();
			var methodBody = new GetAllChats
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

		public async Task<RpcMessage<WebPageBase>> GetWebPage(string url, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WebPageBase>();
			var methodBody = new GetWebPage
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

		public async Task<RpcMessage<bool>> ToggleDialogPin(InputDialogPeerBase peer, bool pinned = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ToggleDialogPin
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

		public async Task<RpcMessage<bool>> ReorderPinnedDialogs(int folderId, List<InputDialogPeerBase> order, bool force = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ReorderPinnedDialogs
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

		public async Task<RpcMessage<PeerDialogsBase>> GetPinnedDialogs(int folderId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PeerDialogsBase>();
			var methodBody = new GetPinnedDialogs
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

		public async Task<RpcMessage<bool>> SetBotShippingResults(long queryId, string error = null, List<ShippingOptionBase>? shippingOptions = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SetBotShippingResults
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
			var methodBody = new SetBotPrecheckoutResults
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

		public async Task<RpcMessage<MessageMediaBase>> UploadMedia(InputPeerBase peer, InputMediaBase media, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessageMediaBase>();
			var methodBody = new UploadMedia
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

		public async Task<RpcMessage<UpdatesBase>> SendScreenshotNotification(InputPeerBase peer, int replyToMsgId, long randomId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendScreenshotNotification
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

		public async Task<RpcMessage<FavedStickersBase>> GetFavedStickers(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FavedStickersBase>();
			var methodBody = new GetFavedStickers
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

		public async Task<RpcMessage<bool>> FaveSticker(InputDocumentBase id, bool unfave, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new FaveSticker
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

		public async Task<RpcMessage<MessagesBase>> GetUnreadMentions(InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetUnreadMentions
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

		public async Task<RpcMessage<AffectedHistoryBase>> ReadMentions(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedHistoryBase>();
			var methodBody = new ReadMentions
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

		public async Task<RpcMessage<MessagesBase>> GetRecentLocations(InputPeerBase peer, int limit, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetRecentLocations
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

		public async Task<RpcMessage<UpdatesBase>> SendMultiMedia(InputPeerBase peer, List<InputSingleMediaBase> multiMedia, bool silent = true, bool background = true, bool clearDraft = true, int? replyToMsgId = null, int? scheduleDate = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendMultiMedia
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

		public async Task<RpcMessage<EncryptedFileBase>> UploadEncryptedFile(InputEncryptedChatBase peer, InputEncryptedFileBase file, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EncryptedFileBase>();
			var methodBody = new UploadEncryptedFile
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

		public async Task<RpcMessage<FoundStickerSetsBase>> SearchStickerSets(string q, int hash, bool excludeFeatured = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FoundStickerSetsBase>();
			var methodBody = new SearchStickerSets
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

		public async Task<RpcMessage<MessageRangeBase>> GetSplitRanges(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessageRangeBase>();
			var methodBody = new GetSplitRanges();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> MarkDialogUnread(InputDialogPeerBase peer, bool unread = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new MarkDialogUnread
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

		public async Task<RpcMessage<DialogPeerBase>> GetDialogUnreadMarks(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DialogPeerBase>();
			var methodBody = new GetDialogUnreadMarks();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> ClearAllDrafts(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ClearAllDrafts();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<UpdatesBase>> UpdatePinnedMessage(InputPeerBase peer, int id, bool silent = true, bool unpin = true, bool pmOneside = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new UpdatePinnedMessage
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

		public async Task<RpcMessage<UpdatesBase>> SendVote(InputPeerBase peer, int msgId, List<byte[]> options, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendVote
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

		public async Task<RpcMessage<UpdatesBase>> GetPollResults(InputPeerBase peer, int msgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new GetPollResults
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

		public async Task<RpcMessage<ChatOnlinesBase>> GetOnlines(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ChatOnlinesBase>();
			var methodBody = new GetOnlines
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

		public async Task<RpcMessage<StatsURLBase>> GetStatsURL(InputPeerBase peer, string pparams, bool dark = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<StatsURLBase>();
			var methodBody = new GetStatsURL
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

		public async Task<RpcMessage<bool>> EditChatAbout(InputPeerBase peer, string about, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new EditChatAbout
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

		public async Task<RpcMessage<UpdatesBase>> EditChatDefaultBannedRights(InputPeerBase peer, ChatBannedRightsBase bannedRights, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new EditChatDefaultBannedRights
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

		public async Task<RpcMessage<EmojiKeywordsDifferenceBase>> GetEmojiKeywords(string langCode, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EmojiKeywordsDifferenceBase>();
			var methodBody = new GetEmojiKeywords
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

		public async Task<RpcMessage<EmojiKeywordsDifferenceBase>> GetEmojiKeywordsDifference(string langCode, int fromVersion, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EmojiKeywordsDifferenceBase>();
			var methodBody = new GetEmojiKeywordsDifference
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

		public async Task<RpcMessage<EmojiLanguageBase>> GetEmojiKeywordsLanguages(List<string> langCodes, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EmojiLanguageBase>();
			var methodBody = new GetEmojiKeywordsLanguages
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

		public async Task<RpcMessage<EmojiURLBase>> GetEmojiURL(string langCode, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<EmojiURLBase>();
			var methodBody = new GetEmojiURL
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

		public async Task<RpcMessage<SearchCounterBase>> GetSearchCounters(InputPeerBase peer, List<MessagesFilterBase> filters, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SearchCounterBase>();
			var methodBody = new GetSearchCounters
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

		public async Task<RpcMessage<UrlAuthResultBase>> RequestUrlAuth(InputPeerBase peer, int msgId, int buttonId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UrlAuthResultBase>();
			var methodBody = new RequestUrlAuth
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

		public async Task<RpcMessage<UrlAuthResultBase>> AcceptUrlAuth(InputPeerBase peer, int msgId, int buttonId, bool writeAllowed = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UrlAuthResultBase>();
			var methodBody = new AcceptUrlAuth
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

		public async Task<RpcMessage<bool>> HidePeerSettingsBar(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new HidePeerSettingsBar
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

		public async Task<RpcMessage<MessagesBase>> GetScheduledHistory(InputPeerBase peer, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetScheduledHistory
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

		public async Task<RpcMessage<MessagesBase>> GetScheduledMessages(InputPeerBase peer, List<int> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetScheduledMessages
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

		public async Task<RpcMessage<UpdatesBase>> SendScheduledMessages(InputPeerBase peer, List<int> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new SendScheduledMessages
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

		public async Task<RpcMessage<UpdatesBase>> DeleteScheduledMessages(InputPeerBase peer, List<int> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new DeleteScheduledMessages
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

		public async Task<RpcMessage<VotesListBase>> GetPollVotes(InputPeerBase peer, int id, int limit, byte[]? option = null, string offset = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<VotesListBase>();
			var methodBody = new GetPollVotes
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

		public async Task<RpcMessage<bool>> ToggleStickerSets(List<InputStickerSetBase> stickersets, bool uninstall = true, bool archive = true, bool unarchive = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ToggleStickerSets
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

		public async Task<RpcMessage<DialogFilterBase>> GetDialogFilters(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DialogFilterBase>();
			var methodBody = new GetDialogFilters();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<DialogFilterSuggestedBase>> GetSuggestedDialogFilters(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DialogFilterSuggestedBase>();
			var methodBody = new GetSuggestedDialogFilters();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> UpdateDialogFilter(int id, DialogFilterBase? filter = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new UpdateDialogFilter
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
			var methodBody = new UpdateDialogFiltersOrder
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

		public async Task<RpcMessage<FeaturedStickersBase>> GetOldFeaturedStickers(int offset, int limit, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FeaturedStickersBase>();
			var methodBody = new GetOldFeaturedStickers
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

		public async Task<RpcMessage<MessagesBase>> GetReplies(InputPeerBase peer, int msgId, int offsetId, int offsetDate, int addOffset, int limit, int maxId, int minId, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<MessagesBase>();
			var methodBody = new GetReplies
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

		public async Task<RpcMessage<DiscussionMessageBase>> GetDiscussionMessage(InputPeerBase peer, int msgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DiscussionMessageBase>();
			var methodBody = new GetDiscussionMessage
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

		public async Task<RpcMessage<bool>> ReadDiscussion(InputPeerBase peer, int msgId, int readMaxId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ReadDiscussion
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

		public async Task<RpcMessage<AffectedHistoryBase>> UnpinAllMessages(InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AffectedHistoryBase>();
			var methodBody = new UnpinAllMessages
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