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
	public partial class Phone
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Phone(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>> GetCallConfigAsync( CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.GetCallConfig()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> RequestCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gAHash, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, bool video = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(userId is null) throw new ArgumentNullException(nameof(userId));
if(gAHash is null) throw new ArgumentNullException(nameof(gAHash));
if(protocol is null) throw new ArgumentNullException(nameof(protocol));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.RequestCall()
			{
				UserId = userId,
				RandomId = randomId,
				GAHash = gAHash,
				Protocol = protocol,
				Video = video,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> AcceptCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gB, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(gB is null) throw new ArgumentNullException(nameof(gB));
if(protocol is null) throw new ArgumentNullException(nameof(protocol));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.AcceptCall()
			{
				Peer = peer,
				GB = gB,
				Protocol = protocol,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> ConfirmCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gA, long keyFingerprint, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(gA is null) throw new ArgumentNullException(nameof(gA));
if(protocol is null) throw new ArgumentNullException(nameof(protocol));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ConfirmCall()
			{
				Peer = peer,
				GA = gA,
				KeyFingerprint = keyFingerprint,
				Protocol = protocol,
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
		public async Task<RpcMessage<bool>> ReceivedCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.ReceivedCall()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DiscardCallAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int duration, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase reason, long connectionId, bool video = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(reason is null) throw new ArgumentNullException(nameof(reason));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.DiscardCall()
			{
				Peer = peer,
				Duration = duration,
				Reason = reason,
				ConnectionId = connectionId,
				Video = video,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetCallRatingAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int rating, string comment, bool userInitiative = true, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(comment is null) throw new ArgumentNullException(nameof(comment));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SetCallRating()
			{
				Peer = peer,
				Rating = rating,
				Comment = comment,
				UserInitiative = userInitiative,
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
		public async Task<RpcMessage<bool>> SaveCallDebugAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase debug, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(debug is null) throw new ArgumentNullException(nameof(debug));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SaveCallDebug()
			{
				Peer = peer,
				Debug = debug,
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
		public async Task<RpcMessage<bool>> SendSignalingDataAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] data, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = default, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(data is null) throw new ArgumentNullException(nameof(data));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Phone.SendSignalingData()
			{
				Peer = peer,
				Data = data,
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