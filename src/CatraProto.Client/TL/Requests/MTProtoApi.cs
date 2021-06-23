using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.TL.Requests
{
	public partial class MTProtoApi
	{
		private MessagesHandler _messagesHandler;

		internal MTProtoApi(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<ResPQBase>> ReqPqAsync(BigInteger nonce, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ResPQBase>();
			var methodBody = new ReqPq
			{
				Nonce = nonce
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = false
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<ServerDHParamsBase>> ReqDHParamsAsync(BigInteger nonce, BigInteger serverNonce, byte[] p, byte[] q,
			long publicKeyFingerprint, byte[] encryptedData, CancellationToken cancellationToken = default)
		{
			if (p is null)
			{
				throw new ArgumentNullException(nameof(p));
			}

			if (q is null)
			{
				throw new ArgumentNullException(nameof(q));
			}

			if (encryptedData is null)
			{
				throw new ArgumentNullException(nameof(encryptedData));
			}

			var rpcResponse = new RpcMessage<ServerDHParamsBase>();
			var methodBody = new ReqDHParams
			{
				Nonce = nonce,
				ServerNonce = serverNonce,
				P = p,
				Q = q,
				PublicKeyFingerprint = publicKeyFingerprint,
				EncryptedData = encryptedData
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = false
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SetClientDHParamsAnswerBase>> SetClientDHParamsAsync(BigInteger nonce, BigInteger serverNonce,
			byte[] encryptedData, CancellationToken cancellationToken = default)
		{
			if (encryptedData is null)
			{
				throw new ArgumentNullException(nameof(encryptedData));
			}

			var rpcResponse = new RpcMessage<SetClientDHParamsAnswerBase>();
			var methodBody = new SetClientDHParams
			{
				Nonce = nonce,
				ServerNonce = serverNonce,
				EncryptedData = encryptedData
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = false
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<RpcDropAnswerBase>> RpcDropAnswerAsync(long reqMsgId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<RpcDropAnswerBase>();
			var methodBody = new RpcDropAnswer
			{
				ReqMsgId = reqMsgId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<FutureSaltsBase>> GetFutureSaltsAsync(int num, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<FutureSaltsBase>();
			var methodBody = new GetFutureSalts
			{
				Num = num
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<PongBase>> PingAsync(long pingId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PongBase>();
			var methodBody = new Ping
			{
				PingId = pingId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<PongBase>> PingDelayDisconnectAsync(long pingId, int disconnectDelay,
			CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PongBase>();
			var methodBody = new PingDelayDisconnect
			{
				PingId = pingId,
				DisconnectDelay = disconnectDelay
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<DestroySessionResBase>> DestroySessionAsync(long sessionId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DestroySessionResBase>();
			var methodBody = new DestroySession
			{
				SessionId = sessionId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<HttpWaitBase>> HttpWaitAsync(int maxDelay, int waitAfter, int maxWait,
			CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<HttpWaitBase>();
			var methodBody = new HttpWait
			{
				MaxDelay = maxDelay,
				WaitAfter = waitAfter,
				MaxWait = maxWait
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