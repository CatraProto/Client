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
	public partial class MTProtoApi
	{
		
	    private MessagesHandler _messagesHandler;
	    internal MTProtoApi(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>> ReqPqAsync(System.Numerics.BigInteger nonce, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.ReqPq()
			{
				Nonce = nonce,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = false
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>> ReqPqMultiAsync(System.Numerics.BigInteger nonce, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.ResPQBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.ReqPqMulti()
			{
				Nonce = nonce,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = false
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase>> ReqDHParamsAsync(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] p, byte[] q, long publicKeyFingerprint, byte[] encryptedData, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(p is null) throw new ArgumentNullException(nameof(p));
if(q is null) throw new ArgumentNullException(nameof(q));
if(encryptedData is null) throw new ArgumentNullException(nameof(encryptedData));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.ReqDHParams()
			{
				Nonce = nonce,
				ServerNonce = serverNonce,
				P = p,
				Q = q,
				PublicKeyFingerprint = publicKeyFingerprint,
				EncryptedData = encryptedData,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = false
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase>> SetClientDHParamsAsync(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] encryptedData, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			if(encryptedData is null) throw new ArgumentNullException(nameof(encryptedData));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.SetClientDHParams()
			{
				Nonce = nonce,
				ServerNonce = serverNonce,
				EncryptedData = encryptedData,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = false
, MessageSendingOptions = messageSendingOptions ?? new CatraProto.Client.MTProto.Messages.MessageSendingOptions()
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase>> RpcDropAnswerAsync(long reqMsgId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswer()
			{
				ReqMsgId = reqMsgId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase>> GetFutureSaltsAsync(int num, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.FutureSaltsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.GetFutureSalts()
			{
				Num = num,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.PongBase>> PingAsync(long pingId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.PongBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.Ping()
			{
				PingId = pingId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.PongBase>> PingDelayDisconnectAsync(long pingId, int disconnectDelay, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.PongBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.PingDelayDisconnect()
			{
				PingId = pingId,
				DisconnectDelay = disconnectDelay,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase>> DestroySessionAsync(long sessionId, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.DestroySession()
			{
				SessionId = sessionId,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.MTProto.HttpWaitBase>> HttpWaitAsync(int maxDelay, int waitAfter, int maxWait, CatraProto.Client.MTProto.Messages.MessageSendingOptions messageSendingOptions = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.MTProto.HttpWaitBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.MTProto.HttpWait()
			{
				MaxDelay = maxDelay,
				WaitAfter = waitAfter,
				MaxWait = maxWait,
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