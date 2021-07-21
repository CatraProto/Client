using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace CatraProto.Client.TL.Requests
{
	public partial class CloudChatsApi
	{
		
public CatraProto.Client.TL.Requests.CloudChats.Auth Auth { get; }
public CatraProto.Client.TL.Requests.CloudChats.Account Account { get; }
public CatraProto.Client.TL.Requests.CloudChats.Users Users { get; }
public CatraProto.Client.TL.Requests.CloudChats.Contacts Contacts { get; }
public CatraProto.Client.TL.Requests.CloudChats.Messages Messages { get; }
public CatraProto.Client.TL.Requests.CloudChats.Updates Updates { get; }
public CatraProto.Client.TL.Requests.CloudChats.Photos Photos { get; }
public CatraProto.Client.TL.Requests.CloudChats.Upload Upload { get; }
public CatraProto.Client.TL.Requests.CloudChats.Help Help { get; }
public CatraProto.Client.TL.Requests.CloudChats.Channels Channels { get; }
public CatraProto.Client.TL.Requests.CloudChats.Bots Bots { get; }
public CatraProto.Client.TL.Requests.CloudChats.Payments Payments { get; }
public CatraProto.Client.TL.Requests.CloudChats.Stickers Stickers { get; }
public CatraProto.Client.TL.Requests.CloudChats.Phone Phone { get; }
public CatraProto.Client.TL.Requests.CloudChats.Langpack Langpack { get; }
public CatraProto.Client.TL.Requests.CloudChats.Folders Folders { get; }
public CatraProto.Client.TL.Requests.CloudChats.Stats Stats { get; }
	    private MessagesHandler _messagesHandler;
	    internal CloudChatsApi(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
Auth = new CatraProto.Client.TL.Requests.CloudChats.Auth(messagesHandler);
Account = new CatraProto.Client.TL.Requests.CloudChats.Account(messagesHandler);
Users = new CatraProto.Client.TL.Requests.CloudChats.Users(messagesHandler);
Contacts = new CatraProto.Client.TL.Requests.CloudChats.Contacts(messagesHandler);
Messages = new CatraProto.Client.TL.Requests.CloudChats.Messages(messagesHandler);
Updates = new CatraProto.Client.TL.Requests.CloudChats.Updates(messagesHandler);
Photos = new CatraProto.Client.TL.Requests.CloudChats.Photos(messagesHandler);
Upload = new CatraProto.Client.TL.Requests.CloudChats.Upload(messagesHandler);
Help = new CatraProto.Client.TL.Requests.CloudChats.Help(messagesHandler);
Channels = new CatraProto.Client.TL.Requests.CloudChats.Channels(messagesHandler);
Bots = new CatraProto.Client.TL.Requests.CloudChats.Bots(messagesHandler);
Payments = new CatraProto.Client.TL.Requests.CloudChats.Payments(messagesHandler);
Stickers = new CatraProto.Client.TL.Requests.CloudChats.Stickers(messagesHandler);
Phone = new CatraProto.Client.TL.Requests.CloudChats.Phone(messagesHandler);
Langpack = new CatraProto.Client.TL.Requests.CloudChats.Langpack(messagesHandler);
Folders = new CatraProto.Client.TL.Requests.CloudChats.Folders(messagesHandler);
Stats = new CatraProto.Client.TL.Requests.CloudChats.Stats(messagesHandler);
	    }
	    
	    		public async Task<RpcMessage<IObject>> InvokeAfterMsgAsync(long msgId, IObject query, CancellationToken cancellationToken = default)
		{
			if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsg()
			{
				MsgId = msgId,
				Query = query,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IObject>> InvokeAfterMsgsAsync(IList<long> msgIds, IObject query, CancellationToken cancellationToken = default)
		{
			if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeAfterMsgs()
			{
				MsgIds = msgIds,
				Query = query,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IObject>> InitConnectionAsync(int apiId, string deviceModel, string systemVersion, string appVersion, string systemLangCode, string langPack, string langCode, IObject query, CatraProto.Client.TL.Schemas.CloudChats.InputClientProxyBase proxy = null, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase pparams = null, CancellationToken cancellationToken = default)
		{
			if(deviceModel is null) throw new ArgumentNullException(nameof(deviceModel));
if(systemVersion is null) throw new ArgumentNullException(nameof(systemVersion));
if(appVersion is null) throw new ArgumentNullException(nameof(appVersion));
if(systemLangCode is null) throw new ArgumentNullException(nameof(systemLangCode));
if(langPack is null) throw new ArgumentNullException(nameof(langPack));
if(langCode is null) throw new ArgumentNullException(nameof(langCode));
if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InitConnection()
			{
				ApiId = apiId,
				DeviceModel = deviceModel,
				SystemVersion = systemVersion,
				AppVersion = appVersion,
				SystemLangCode = systemLangCode,
				LangPack = langPack,
				LangCode = langCode,
				Query = query,
				Proxy = proxy,
				Params = pparams,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IObject>> InvokeWithLayerAsync(int layer, IObject query, CancellationToken cancellationToken = default)
		{
			if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithLayer()
			{
				Layer = layer,
				Query = query,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IObject>> InvokeWithoutUpdatesAsync(IObject query, CancellationToken cancellationToken = default)
		{
			if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithoutUpdates()
			{
				Query = query,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IObject>> InvokeWithMessagesRangeAsync(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase range, IObject query, CancellationToken cancellationToken = default)
		{
			if(range is null) throw new ArgumentNullException(nameof(range));
if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithMessagesRange()
			{
				Range = range,
				Query = query,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<IObject>> InvokeWithTakeoutAsync(long takeoutId, IObject query, CancellationToken cancellationToken = default)
		{
			if(query is null) throw new ArgumentNullException(nameof(query));

			var rpcResponse = new RpcMessage<IObject>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.InvokeWithTakeout()
			{
				TakeoutId = takeoutId,
				Query = query,
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