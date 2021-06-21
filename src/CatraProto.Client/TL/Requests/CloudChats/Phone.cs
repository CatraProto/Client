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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>> GetCallConfig( CancellationToken cancellationToken = default)
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> RequestCall(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, int randomId, byte[] gAHash, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, bool video = true, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> AcceptCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gB, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase>> ConfirmCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gA, long keyFingerprint, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ReceivedCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> DiscardCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int duration, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase reason, long connectionId, bool video = true, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> SetCallRating(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int rating, string comment, bool userInitiative = true, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SaveCallDebug(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase debug, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> SendSignalingData(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] data, CancellationToken cancellationToken = default)
		{
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
				}, rpcResponse);
			return rpcResponse;
		}

	}
}