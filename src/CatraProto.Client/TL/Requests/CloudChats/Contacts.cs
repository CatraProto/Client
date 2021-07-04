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
	public partial class Contacts
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Contacts(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<int>> GetContactIDsAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<int>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetContactIDs()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ContactStatusBase>> GetStatusesAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ContactStatusBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetStatuses()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsBase>> GetContactsAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ContactsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetContacts()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase>> ImportContactsAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputContactBase> contacts, CancellationToken cancellationToken = default)
		{
			if(contacts is null) throw new ArgumentNullException(nameof(contacts));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportedContactsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ImportContacts()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DeleteContactsAsync(List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.DeleteContacts()
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
		public async Task<RpcMessage<bool>> DeleteByPhonesAsync(List<string> phones, CancellationToken cancellationToken = default)
		{
			if(phones is null) throw new ArgumentNullException(nameof(phones));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.DeleteByPhones()
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
		public async Task<RpcMessage<bool>> BlockAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Block()
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
		public async Task<RpcMessage<bool>> UnblockAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Unblock()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase>> GetBlockedAsync(int offset, int limit, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetBlocked()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.FoundBase>> SearchAsync(string q, int limit, CancellationToken cancellationToken = default)
		{
			if(q is null) throw new ArgumentNullException(nameof(q));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.FoundBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.Search()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolvedPeerBase>> ResolveUsernameAsync(string username, CancellationToken cancellationToken = default)
		{
			if(username is null) throw new ArgumentNullException(nameof(username));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolvedPeerBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResolveUsername()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase>> GetTopPeersAsync(int offset, int limit, int hash, bool correspondents = true, bool botsPm = true, bool botsInline = true, bool phoneCalls = true, bool forwardUsers = true, bool forwardChats = true, bool groups = true, bool channels = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetTopPeers()
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
		public async Task<RpcMessage<bool>> ResetTopPeerRatingAsync(CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase category, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(category is null) throw new ArgumentNullException(nameof(category));
if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResetTopPeerRating()
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
		public async Task<RpcMessage<bool>> ResetSavedAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ResetSaved()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SavedContactBase>> GetSavedAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SavedContactBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetSaved()
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
		public async Task<RpcMessage<bool>> ToggleTopPeersAsync(bool enabled, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.ToggleTopPeers()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> AddContactAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, string firstName, string lastName, string phone, bool addPhonePrivacyException = true, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));
if(firstName is null) throw new ArgumentNullException(nameof(firstName));
if(lastName is null) throw new ArgumentNullException(nameof(lastName));
if(phone is null) throw new ArgumentNullException(nameof(phone));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.AddContact()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> AcceptContactAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, CancellationToken cancellationToken = default)
		{
			if(id is null) throw new ArgumentNullException(nameof(id));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.AcceptContact()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetLocatedAsync(CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint, bool background = true, int? selfExpires = null, CancellationToken cancellationToken = default)
		{
			if(geoPoint is null) throw new ArgumentNullException(nameof(geoPoint));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.GetLocated()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> BlockFromRepliesAsync(int msgId, bool deleteMessage = true, bool deleteHistory = true, bool reportSpam = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockFromReplies()
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