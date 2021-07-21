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
	public partial class Auth
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Auth(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendCodeAsync(string phoneNumber, int apiId, string apiHash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(apiHash is null) throw new ArgumentNullException(nameof(apiHash));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.SendCode()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> SignUpAsync(string phoneNumber, string phoneCodeHash, string firstName, string lastName, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));
if(firstName is null) throw new ArgumentNullException(nameof(firstName));
if(lastName is null) throw new ArgumentNullException(nameof(lastName));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.SignUp()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> SignInAsync(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));
if(phoneCode is null) throw new ArgumentNullException(nameof(phoneCode));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.SignIn()
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
		public async Task<RpcMessage<bool>> LogOutAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.LogOut()
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
		public async Task<RpcMessage<bool>> ResetAuthorizationsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResetAuthorizations()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase>> ExportAuthorizationAsync(int dcId, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportAuthorization()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> ImportAuthorizationAsync(int id, byte[] bytes, CancellationToken cancellationToken = default)
		{
			if(bytes is null) throw new ArgumentNullException(nameof(bytes));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportAuthorization()
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
		public async Task<RpcMessage<bool>> BindTempAuthKeyAsync(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage, CancellationToken cancellationToken = default)
		{
			if(encryptedMessage is null) throw new ArgumentNullException(nameof(encryptedMessage));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.BindTempAuthKey()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> ImportBotAuthorizationAsync(int flags, int apiId, string apiHash, string botAuthToken, CancellationToken cancellationToken = default)
		{
			if(apiHash is null) throw new ArgumentNullException(nameof(apiHash));
if(botAuthToken is null) throw new ArgumentNullException(nameof(botAuthToken));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportBotAuthorization()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> CheckPasswordAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
			if(password is null) throw new ArgumentNullException(nameof(password));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.CheckPassword()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase>> RequestPasswordRecoveryAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.RequestPasswordRecovery()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> RecoverPasswordAsync(string code, CancellationToken cancellationToken = default)
		{
			if(code is null) throw new ArgumentNullException(nameof(code));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.RecoverPassword()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> ResendCodeAsync(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ResendCode()
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
		public async Task<RpcMessage<bool>> CancelCodeAsync(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.CancelCode()
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
		public async Task<RpcMessage<bool>> DropTempAuthKeysAsync(IList<long> exceptAuthKeys, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.DropTempAuthKeys()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>> ExportLoginTokenAsync(int apiId, string apiHash, IList<int> exceptIds, CancellationToken cancellationToken = default)
		{
			if(apiHash is null) throw new ArgumentNullException(nameof(apiHash));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportLoginToken()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>> ImportLoginTokenAsync(byte[] token, CancellationToken cancellationToken = default)
		{
			if(token is null) throw new ArgumentNullException(nameof(token));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.ImportLoginToken()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>> AcceptLoginTokenAsync(byte[] token, CancellationToken cancellationToken = default)
		{
			if(token is null) throw new ArgumentNullException(nameof(token));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Auth.AcceptLoginToken()
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