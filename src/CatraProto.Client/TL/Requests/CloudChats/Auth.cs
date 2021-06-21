using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using AuthorizationBase = CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
	public partial class Auth
	{
		private MessagesHandler _messagesHandler;

		internal Auth(MessagesHandler messagesHandler)
		{
			_messagesHandler = messagesHandler;
		}

		public async Task<RpcMessage<SentCodeBase>> SendCode(string phoneNumber, int apiId, string apiHash, CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new SendCode
			{
				PhoneNumber = phoneNumber,
				ApiId = apiId,
				ApiHash = apiHash,
				Settings = settings,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> SignUp(string phoneNumber, string phoneCodeHash, string firstName, string lastName, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new SignUp
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash,
				FirstName = firstName,
				LastName = lastName,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> SignIn(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new SignIn
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash,
				PhoneCode = phoneCode,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> LogOut(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new LogOut();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> ResetAuthorizations(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResetAuthorizations();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<ExportedAuthorizationBase>> ExportAuthorization(int dcId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ExportedAuthorizationBase>();
			var methodBody = new ExportAuthorization
			{
				DcId = dcId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> ImportAuthorization(int id, byte[] bytes, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new ImportAuthorization
			{
				Id = id,
				Bytes = bytes,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> BindTempAuthKey(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new BindTempAuthKey
			{
				PermAuthKeyId = permAuthKeyId,
				Nonce = nonce,
				ExpiresAt = expiresAt,
				EncryptedMessage = encryptedMessage,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> ImportBotAuthorization(int flags, int apiId, string apiHash, string botAuthToken, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new ImportBotAuthorization
			{
				Flags = flags,
				ApiId = apiId,
				ApiHash = apiHash,
				BotAuthToken = botAuthToken,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> CheckPassword(InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new CheckPassword
			{
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

		public async Task<RpcMessage<PasswordRecoveryBase>> RequestPasswordRecovery(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PasswordRecoveryBase>();
			var methodBody = new RequestPasswordRecovery();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> RecoverPassword(string code, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new RecoverPassword
			{
				Code = code,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SentCodeBase>> ResendCode(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new ResendCode
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> CancelCode(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CancelCode
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> DropTempAuthKeys(List<long> exceptAuthKeys, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new DropTempAuthKeys
			{
				ExceptAuthKeys = exceptAuthKeys,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LoginTokenBase>> ExportLoginToken(int apiId, string apiHash, List<int> exceptIds, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<LoginTokenBase>();
			var methodBody = new ExportLoginToken
			{
				ApiId = apiId,
				ApiHash = apiHash,
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

		public async Task<RpcMessage<LoginTokenBase>> ImportLoginToken(byte[] token, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<LoginTokenBase>();
			var methodBody = new ImportLoginToken
			{
				Token = token,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<Schemas.CloudChats.AuthorizationBase>> AcceptLoginToken(byte[] token, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<Schemas.CloudChats.AuthorizationBase>();
			var methodBody = new AcceptLoginToken
			{
				Token = token,
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