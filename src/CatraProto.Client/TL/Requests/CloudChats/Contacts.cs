using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Contacts;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Contacts
	{
		private MessagesHandler _messagesHandler;

		internal Contacts(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<int>> GetContactIDs(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<int>();
			var methodBody = new GetContactIDs
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

		public async Task<RpcMessage<ContactStatusBase>> GetStatuses(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ContactStatusBase>();
			var methodBody = new GetStatuses();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<ContactsBase>> GetContacts(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ContactsBase>();
			var methodBody = new GetContacts
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

		public async Task<RpcMessage<ImportedContactsBase>> ImportContacts(List<InputContactBase> contacts, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ImportedContactsBase>();
			var methodBody = new ImportContacts
			{
				Contacts = contacts,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<UpdatesBase>> DeleteContacts(List<InputUserBase> id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new DeleteContacts
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

		public async Task<RpcMessage<bool>> DeleteByPhones(List<string> phones, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new DeleteByPhones
			{
				Phones = phones,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> Block(InputPeerBase id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new Block
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

		public async Task<RpcMessage<bool>> Unblock(InputPeerBase id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new Unblock
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

		public async Task<RpcMessage<BlockedBase>> GetBlocked(int offset, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<BlockedBase>();
			var methodBody = new GetBlocked
			{
				Offset = offset,
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

		public async Task<RpcMessage<FoundBase>> Search(string q, int limit, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FoundBase>();
			var methodBody = new Search
			{
				Q = q,
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

		public async Task<RpcMessage<ResolvedPeerBase>> ResolveUsername(string username, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ResolvedPeerBase>();
			var methodBody = new ResolveUsername
			{
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

		public async Task<RpcMessage<TopPeersBase>> GetTopPeers(int offset, int limit, int hash, bool correspondents = true, bool botsPm = true, bool botsInline = true, bool phoneCalls = true, bool forwardUsers = true, bool forwardChats = true, bool groups = true, bool channels = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<TopPeersBase>();
			var methodBody = new GetTopPeers
			{
				Offset = offset,
				Limit = limit,
				Hash = hash,
				Correspondents = correspondents,
				BotsPm = botsPm,
				BotsInline = botsInline,
				PhoneCalls = phoneCalls,
				ForwardUsers = forwardUsers,
				ForwardChats = forwardChats,
				Groups = groups,
				Channels = channels,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> ResetTopPeerRating(TopPeerCategoryBase category, InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResetTopPeerRating
			{
				Category = category,
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

		public async Task<RpcMessage<bool>> ResetSaved(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResetSaved();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SavedContactBase>> GetSaved(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SavedContactBase>();
			var methodBody = new GetSaved();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> ToggleTopPeers(bool enabled, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ToggleTopPeers
			{
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

		public async Task<RpcMessage<UpdatesBase>> AddContact(InputUserBase id, string firstName, string lastName, string phone, bool addPhonePrivacyException = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new AddContact
			{
				Id = id,
				FirstName = firstName,
				LastName = lastName,
				Phone = phone,
				AddPhonePrivacyException = addPhonePrivacyException,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<UpdatesBase>> AcceptContact(InputUserBase id, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new AcceptContact
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

		public async Task<RpcMessage<UpdatesBase>> GetLocated(InputGeoPointBase geoPoint, bool background = true, int? selfExpires = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new GetLocated
			{
				GeoPoint = geoPoint,
				Background = background,
				SelfExpires = selfExpires,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<UpdatesBase>> BlockFromReplies(int msgId, bool deleteMessage = true, bool deleteHistory = true, bool reportSpam = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new BlockFromReplies
			{
				MsgId = msgId,
				DeleteMessage = deleteMessage,
				DeleteHistory = deleteHistory,
				ReportSpam = reportSpam,
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