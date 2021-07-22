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
	public partial class Account
	{
		
	    private MessagesHandler _messagesHandler;
	    internal Account(MessagesHandler messagesHandler)
	    {
	        _messagesHandler = messagesHandler;
	        
	    }
	    
	    		public async Task<RpcMessage<bool>> RegisterDeviceAsync(int tokenType, string token, bool appSandbox, byte[] secret, IList<int> otherUids, bool noMuted = true, CancellationToken cancellationToken = default)
		{
			if(token is null) throw new ArgumentNullException(nameof(token));
if(secret is null) throw new ArgumentNullException(nameof(secret));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.RegisterDevice()
			{
				TokenType = tokenType,
				Token = token,
				AppSandbox = appSandbox,
				Secret = secret,
				OtherUids = otherUids,
				NoMuted = noMuted,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UnregisterDeviceAsync(int tokenType, string token, IList<int> otherUids, CancellationToken cancellationToken = default)
		{
			if(token is null) throw new ArgumentNullException(nameof(token));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UnregisterDevice()
			{
				TokenType = tokenType,
				Token = token,
				OtherUids = otherUids,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UpdateNotifySettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateNotifySettings()
			{
				Peer = peer,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>> GetNotifySettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetNotifySettings()
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
		public async Task<RpcMessage<bool>> ResetNotifySettingsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetNotifySettings()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> UpdateProfileAsync(string firstName = null, string lastName = null, string about = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateProfile()
			{
				FirstName = firstName,
				LastName = lastName,
				About = about,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> UpdateStatusAsync(bool offline, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateStatus()
			{
				Offline = offline,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase>> GetWallPapersAsync(int hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPapers()
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
		public async Task<RpcMessage<bool>> ReportPeerAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, CancellationToken cancellationToken = default)
		{
			if(peer is null) throw new ArgumentNullException(nameof(peer));
if(reason is null) throw new ArgumentNullException(nameof(reason));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ReportPeer()
			{
				Peer = peer,
				Reason = reason,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> CheckUsernameAsync(string username, CancellationToken cancellationToken = default)
		{
			if(username is null) throw new ArgumentNullException(nameof(username));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.CheckUsername()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> UpdateUsernameAsync(string username, CancellationToken cancellationToken = default)
		{
			if(username is null) throw new ArgumentNullException(nameof(username));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateUsername()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>> GetPrivacyAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, CancellationToken cancellationToken = default)
		{
			if(key is null) throw new ArgumentNullException(nameof(key));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPrivacy()
			{
				Key = key,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>> SetPrivacyAsync(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, IList<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> rules, CancellationToken cancellationToken = default)
		{
			if(key is null) throw new ArgumentNullException(nameof(key));
if(rules is null) throw new ArgumentNullException(nameof(rules));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetPrivacy()
			{
				Key = key,
				Rules = rules,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> DeleteAccountAsync(string reason, CancellationToken cancellationToken = default)
		{
			if(reason is null) throw new ArgumentNullException(nameof(reason));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.DeleteAccount()
			{
				Reason = reason,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>> GetAccountTTLAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAccountTTL()
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
		public async Task<RpcMessage<bool>> SetAccountTTLAsync(CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase ttl, CancellationToken cancellationToken = default)
		{
			if(ttl is null) throw new ArgumentNullException(nameof(ttl));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetAccountTTL()
			{
				Ttl = ttl,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendChangePhoneCodeAsync(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendChangePhoneCode()
			{
				PhoneNumber = phoneNumber,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> ChangePhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));
if(phoneCode is null) throw new ArgumentNullException(nameof(phoneCode));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ChangePhone()
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
		public async Task<RpcMessage<bool>> UpdateDeviceLockedAsync(int period, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateDeviceLocked()
			{
				Period = period,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase>> GetAuthorizationsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizations()
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
		public async Task<RpcMessage<bool>> ResetAuthorizationAsync(long hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetAuthorization()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase>> GetPasswordAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPassword()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase>> GetPasswordSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
			if(password is null) throw new ArgumentNullException(nameof(password));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetPasswordSettings()
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
		public async Task<RpcMessage<bool>> UpdatePasswordSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase newSettings, CancellationToken cancellationToken = default)
		{
			if(password is null) throw new ArgumentNullException(nameof(password));
if(newSettings is null) throw new ArgumentNullException(nameof(newSettings));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdatePasswordSettings()
			{
				Password = password,
				NewSettings = newSettings,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendConfirmPhoneCodeAsync(string hash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(hash is null) throw new ArgumentNullException(nameof(hash));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendConfirmPhoneCode()
			{
				Hash = hash,
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
		public async Task<RpcMessage<bool>> ConfirmPhoneAsync(string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
			if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));
if(phoneCode is null) throw new ArgumentNullException(nameof(phoneCode));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPhone()
			{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase>> GetTmpPasswordAsync(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, int period, CancellationToken cancellationToken = default)
		{
			if(password is null) throw new ArgumentNullException(nameof(password));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTmpPassword()
			{
				Password = password,
				Period = period,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase>> GetWebAuthorizationsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWebAuthorizations()
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
		public async Task<RpcMessage<bool>> ResetWebAuthorizationAsync(long hash, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWebAuthorization()
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
		public async Task<RpcMessage<bool>> ResetWebAuthorizationsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWebAuthorizations()
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
		public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>> GetAllSecureValuesAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>();
			rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAllSecureValues()
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
		public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>> GetSecureValueAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types, CancellationToken cancellationToken = default)
		{
			if(types is null) throw new ArgumentNullException(nameof(types));

			var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>>();
			rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetSecureValue()
			{
				Types = types,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>> SaveSecureValueAsync(CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase value, long secureSecretId, CancellationToken cancellationToken = default)
		{
			if(value is null) throw new ArgumentNullException(nameof(value));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveSecureValue()
			{
				Value = value,
				SecureSecretId = secureSecretId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> DeleteSecureValueAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types, CancellationToken cancellationToken = default)
		{
			if(types is null) throw new ArgumentNullException(nameof(types));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.DeleteSecureValue()
			{
				Types = types,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase>> GetAuthorizationFormAsync(int botId, string scope, string publicKey, CancellationToken cancellationToken = default)
		{
			if(scope is null) throw new ArgumentNullException(nameof(scope));
if(publicKey is null) throw new ArgumentNullException(nameof(publicKey));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAuthorizationForm()
			{
				BotId = botId,
				Scope = scope,
				PublicKey = publicKey,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> AcceptAuthorizationAsync(int botId, string scope, string publicKey, IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> valueHashes, CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials, CancellationToken cancellationToken = default)
		{
			if(scope is null) throw new ArgumentNullException(nameof(scope));
if(publicKey is null) throw new ArgumentNullException(nameof(publicKey));
if(valueHashes is null) throw new ArgumentNullException(nameof(valueHashes));
if(credentials is null) throw new ArgumentNullException(nameof(credentials));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.AcceptAuthorization()
			{
				BotId = botId,
				Scope = scope,
				PublicKey = publicKey,
				ValueHashes = valueHashes,
				Credentials = credentials,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendVerifyPhoneCodeAsync(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyPhoneCode()
			{
				PhoneNumber = phoneNumber,
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
		public async Task<RpcMessage<bool>> VerifyPhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
			if(phoneNumber is null) throw new ArgumentNullException(nameof(phoneNumber));
if(phoneCodeHash is null) throw new ArgumentNullException(nameof(phoneCodeHash));
if(phoneCode is null) throw new ArgumentNullException(nameof(phoneCode));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyPhone()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase>> SendVerifyEmailCodeAsync(string email, CancellationToken cancellationToken = default)
		{
			if(email is null) throw new ArgumentNullException(nameof(email));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SendVerifyEmailCode()
			{
				Email = email,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> VerifyEmailAsync(string email, string code, CancellationToken cancellationToken = default)
		{
			if(email is null) throw new ArgumentNullException(nameof(email));
if(code is null) throw new ArgumentNullException(nameof(code));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.VerifyEmail()
			{
				Email = email,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase>> InitTakeoutSessionAsync(bool contacts = true, bool messageUsers = true, bool messageChats = true, bool messageMegagroups = true, bool messageChannels = true, bool files = true, int? fileMaxSize = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.InitTakeoutSession()
			{
				Contacts = contacts,
				MessageUsers = messageUsers,
				MessageChats = messageChats,
				MessageMegagroups = messageMegagroups,
				MessageChannels = messageChannels,
				Files = files,
				FileMaxSize = fileMaxSize,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> FinishTakeoutSessionAsync(bool success = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.FinishTakeoutSession()
			{
				Success = success,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> ConfirmPasswordEmailAsync(string code, CancellationToken cancellationToken = default)
		{
			if(code is null) throw new ArgumentNullException(nameof(code));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ConfirmPasswordEmail()
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
		public async Task<RpcMessage<bool>> ResendPasswordEmailAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResendPasswordEmail()
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
		public async Task<RpcMessage<bool>> CancelPasswordEmailAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.CancelPasswordEmail()
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
		public async Task<RpcMessage<bool>> GetContactSignUpNotificationAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetContactSignUpNotification()
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
		public async Task<RpcMessage<bool>> SetContactSignUpNotificationAsync(bool silent, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetContactSignUpNotification()
			{
				Silent = silent,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetNotifyExceptionsAsync(bool compareSound = true, CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetNotifyExceptions()
			{
				CompareSound = compareSound,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> GetWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CancellationToken cancellationToken = default)
		{
			if(wallpaper is null) throw new ArgumentNullException(nameof(wallpaper));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetWallPaper()
			{
				Wallpaper = wallpaper,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> UploadWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(file is null) throw new ArgumentNullException(nameof(file));
if(mimeType is null) throw new ArgumentNullException(nameof(mimeType));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadWallPaper()
			{
				File = file,
				MimeType = mimeType,
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
		public async Task<RpcMessage<bool>> SaveWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, bool unsave, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(wallpaper is null) throw new ArgumentNullException(nameof(wallpaper));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveWallPaper()
			{
				Wallpaper = wallpaper,
				Unsave = unsave,
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
		public async Task<RpcMessage<bool>> InstallWallPaperAsync(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(wallpaper is null) throw new ArgumentNullException(nameof(wallpaper));
if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallWallPaper()
			{
				Wallpaper = wallpaper,
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
		public async Task<RpcMessage<bool>> ResetWallPapersAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.ResetWallPapers()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase>> GetAutoDownloadSettingsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetAutoDownloadSettings()
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
		public async Task<RpcMessage<bool>> SaveAutoDownloadSettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = true, bool high = true, CancellationToken cancellationToken = default)
		{
			if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveAutoDownloadSettings()
			{
				Settings = settings,
				Low = low,
				High = high,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>> UploadThemeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string fileName, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase thumb = null, CancellationToken cancellationToken = default)
		{
			if(file is null) throw new ArgumentNullException(nameof(file));
if(fileName is null) throw new ArgumentNullException(nameof(fileName));
if(mimeType is null) throw new ArgumentNullException(nameof(mimeType));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UploadTheme()
			{
				File = file,
				FileName = fileName,
				MimeType = mimeType,
				Thumb = thumb,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> CreateThemeAsync(string slug, string title, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase document = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase settings = null, CancellationToken cancellationToken = default)
		{
			if(slug is null) throw new ArgumentNullException(nameof(slug));
if(title is null) throw new ArgumentNullException(nameof(title));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.CreateTheme()
			{
				Slug = slug,
				Title = title,
				Document = document,
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> UpdateThemeAsync(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, string slug = null, string title = null, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase document = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase settings = null, CancellationToken cancellationToken = default)
		{
			if(format is null) throw new ArgumentNullException(nameof(format));
if(theme is null) throw new ArgumentNullException(nameof(theme));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme()
			{
				Format = format,
				Theme = theme,
				Slug = slug,
				Title = title,
				Document = document,
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
		public async Task<RpcMessage<bool>> SaveThemeAsync(CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, bool unsave, CancellationToken cancellationToken = default)
		{
			if(theme is null) throw new ArgumentNullException(nameof(theme));

			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SaveTheme()
			{
				Theme = theme,
				Unsave = unsave,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<bool>> InstallThemeAsync(bool dark = true, string format = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme = null, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.InstallTheme()
			{
				Dark = dark,
				Format = format,
				Theme = theme,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> GetThemeAsync(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, long documentId, CancellationToken cancellationToken = default)
		{
			if(format is null) throw new ArgumentNullException(nameof(format));
if(theme is null) throw new ArgumentNullException(nameof(theme));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetTheme()
			{
				Format = format,
				Theme = theme,
				DocumentId = documentId,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase>> GetThemesAsync(string format, int hash, CancellationToken cancellationToken = default)
		{
			if(format is null) throw new ArgumentNullException(nameof(format));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetThemes()
			{
				Format = format,
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
		public async Task<RpcMessage<bool>> SetContentSettingsAsync(bool sensitiveEnabled = true, CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetContentSettings()
			{
				SensitiveEnabled = sensitiveEnabled,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase>> GetContentSettingsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetContentSettings()
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
		public async Task<RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>>> GetMultiWallPapersAsync(IList<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> wallpapers, CancellationToken cancellationToken = default)
		{
			if(wallpapers is null) throw new ArgumentNullException(nameof(wallpapers));

			var rpcResponse = new RpcMessage<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>>();
			rpcResponse.Response = new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetMultiWallPapers()
			{
				Wallpapers = wallpapers,
			};

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
				{
					Body = methodBody,
					CancellationToken = cancellationToken,
					IsEncrypted = true
				}, rpcResponse);
			return rpcResponse;
		}
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>> GetGlobalPrivacySettingsAsync( CancellationToken cancellationToken = default)
		{
			
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.GetGlobalPrivacySettings()
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>> SetGlobalPrivacySettingsAsync(CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase settings, CancellationToken cancellationToken = default)
		{
			if(settings is null) throw new ArgumentNullException(nameof(settings));

			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>();
			var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Account.SetGlobalPrivacySettings()
			{
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

	}
}