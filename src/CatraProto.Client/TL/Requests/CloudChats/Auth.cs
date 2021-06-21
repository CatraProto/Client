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
	    
	    		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendCode(string phoneNumber, int apiId, string apiHash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> SignUp(string phoneNumber, string phoneCodeHash, string firstName, string lastName, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> SignIn(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> LogOut( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ResetAuthorizations( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase>> ExportAuthorization(int dcId, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> ImportAuthorization(int id, byte[] bytes, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> BindTempAuthKey(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> ImportBotAuthorization(int flags, int apiId, string apiHash, string botAuthToken, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> CheckPassword(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase>> RequestPasswordRecovery( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>> RecoverPassword(string code, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> ResendCode(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> CancelCode(string phoneNumber, string phoneCodeHash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> DropTempAuthKeys(List<long> exceptAuthKeys, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>> ExportLoginToken(int apiId, string apiHash, List<int> exceptIds, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase>> ImportLoginToken(byte[] token, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>> AcceptLoginToken(byte[] token, CancellationToken cancellationToken = default)
		{
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