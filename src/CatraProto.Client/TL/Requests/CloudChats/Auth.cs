using System;
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

		public async Task<RpcMessage<SentCodeBase>> SendCodeAsync(string phoneNumber, int apiId, string apiHash, CodeSettingsBase settings,
			CancellationToken cancellationToken = default)
		{
			if (phoneNumber is null)
			{
				throw new ArgumentNullException(nameof(phoneNumber));
			}

			if (apiHash is null)
			{
				throw new ArgumentNullException(nameof(apiHash));
			}

			if (settings is null)
			{
				throw new ArgumentNullException(nameof(settings));
			}

			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new SendCode
			{
				PhoneNumber = phoneNumber,
				ApiId = apiId,
				ApiHash = apiHash,
				Settings = settings
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> SignUpAsync(string phoneNumber, string phoneCodeHash, string firstName, string lastName,
			CancellationToken cancellationToken = default)
		{
			if (phoneNumber is null)
			{
				throw new ArgumentNullException(nameof(phoneNumber));
			}

			if (phoneCodeHash is null)
			{
				throw new ArgumentNullException(nameof(phoneCodeHash));
			}

			if (firstName is null)
			{
				throw new ArgumentNullException(nameof(firstName));
			}

			if (lastName is null)
			{
				throw new ArgumentNullException(nameof(lastName));
			}

			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new SignUp
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash,
				FirstName = firstName,
				LastName = lastName
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> SignInAsync(string phoneNumber, string phoneCodeHash, string phoneCode,
			CancellationToken cancellationToken = default)
		{
			if (phoneNumber is null)
			{
				throw new ArgumentNullException(nameof(phoneNumber));
			}

			if (phoneCodeHash is null)
			{
				throw new ArgumentNullException(nameof(phoneCodeHash));
			}

			if (phoneCode is null)
			{
				throw new ArgumentNullException(nameof(phoneCode));
			}

			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new SignIn
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash,
				PhoneCode = phoneCode
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> LogOutAsync(CancellationToken cancellationToken = default)
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

		public async Task<RpcMessage<bool>> ResetAuthorizationsAsync(CancellationToken cancellationToken = default)
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

		public async Task<RpcMessage<ExportedAuthorizationBase>> ExportAuthorizationAsync(int dcId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ExportedAuthorizationBase>();
			var methodBody = new ExportAuthorization
			{
				DcId = dcId
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> ImportAuthorizationAsync(int id, byte[] bytes, CancellationToken cancellationToken = default)
		{
			if (bytes is null)
			{
				throw new ArgumentNullException(nameof(bytes));
			}

			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new ImportAuthorization
			{
				Id = id,
				Bytes = bytes
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> BindTempAuthKeyAsync(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage,
			CancellationToken cancellationToken = default)
		{
			if (encryptedMessage is null)
			{
				throw new ArgumentNullException(nameof(encryptedMessage));
			}

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new BindTempAuthKey
			{
				PermAuthKeyId = permAuthKeyId,
				Nonce = nonce,
				ExpiresAt = expiresAt,
				EncryptedMessage = encryptedMessage
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> ImportBotAuthorizationAsync(int flags, int apiId, string apiHash, string botAuthToken,
			CancellationToken cancellationToken = default)
		{
			if (apiHash is null)
			{
				throw new ArgumentNullException(nameof(apiHash));
			}

			if (botAuthToken is null)
			{
				throw new ArgumentNullException(nameof(botAuthToken));
			}

			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new ImportBotAuthorization
			{
				Flags = flags,
				ApiId = apiId,
				ApiHash = apiHash,
				BotAuthToken = botAuthToken
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AuthorizationBase>> CheckPasswordAsync(InputCheckPasswordSRPBase password,
			CancellationToken cancellationToken = default)
		{
			if (password is null)
			{
				throw new ArgumentNullException(nameof(password));
			}

			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new CheckPassword
			{
				Password = password
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<PasswordRecoveryBase>> RequestPasswordRecoveryAsync(CancellationToken cancellationToken = default)
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

		public async Task<RpcMessage<AuthorizationBase>> RecoverPasswordAsync(string code, CancellationToken cancellationToken = default)
		{
			if (code is null)
			{
				throw new ArgumentNullException(nameof(code));
			}

			var rpcResponse = new RpcMessage<AuthorizationBase>();
			var methodBody = new RecoverPassword
			{
				Code = code
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SentCodeBase>> ResendCodeAsync(string phoneNumber, string phoneCodeHash,
			CancellationToken cancellationToken = default)
		{
			if (phoneNumber is null)
			{
				throw new ArgumentNullException(nameof(phoneNumber));
			}

			if (phoneCodeHash is null)
			{
				throw new ArgumentNullException(nameof(phoneCodeHash));
			}

			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new ResendCode
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> CancelCodeAsync(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
			if (phoneNumber is null)
			{
				throw new ArgumentNullException(nameof(phoneNumber));
			}

			if (phoneCodeHash is null)
			{
				throw new ArgumentNullException(nameof(phoneCodeHash));
			}

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CancelCode
			{
				PhoneNumber = phoneNumber,
				PhoneCodeHash = phoneCodeHash
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> DropTempAuthKeysAsync(List<long> exceptAuthKeys, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new DropTempAuthKeys
			{
				ExceptAuthKeys = exceptAuthKeys
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LoginTokenBase>> ExportLoginTokenAsync(int apiId, string apiHash, List<int> exceptIds,
			CancellationToken cancellationToken = default)
		{
			if (apiHash is null)
			{
				throw new ArgumentNullException(nameof(apiHash));
			}

			var rpcResponse = new RpcMessage<LoginTokenBase>();
			var methodBody = new ExportLoginToken
			{
				ApiId = apiId,
				ApiHash = apiHash,
				ExceptIds = exceptIds
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<LoginTokenBase>> ImportLoginTokenAsync(byte[] token, CancellationToken cancellationToken = default)
		{
			if (token is null)
			{
				throw new ArgumentNullException(nameof(token));
			}

			var rpcResponse = new RpcMessage<LoginTokenBase>();
			var methodBody = new ImportLoginToken
			{
				Token = token
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<Schemas.CloudChats.AuthorizationBase>> AcceptLoginTokenAsync(byte[] token,
			CancellationToken cancellationToken = default)
		{
			if (token is null)
			{
				throw new ArgumentNullException(nameof(token));
			}

			var rpcResponse = new RpcMessage<Schemas.CloudChats.AuthorizationBase>();
			var methodBody = new AcceptLoginToken
			{
				Token = token
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