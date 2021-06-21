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
	    
	    		public async Task<RpcMessage<bool>> RegisterDevice(int tokenType, string token, bool appSandbox, byte[] secret, List<int> otherUids, bool noMuted = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> UnregisterDevice(int tokenType, string token, List<int> otherUids, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> UpdateNotifySettings(CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPeerNotifySettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>> GetNotifySettings(CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase peer, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ResetNotifySettings( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> UpdateProfile(string firstName = null, string lastName = null, string about = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> UpdateStatus(bool offline, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase>> GetWallPapers(int hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ReportPeer(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase reason, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> CheckUsername(string username, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> UpdateUsername(string username, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>> GetPrivacy(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase>> SetPrivacy(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, List<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> rules, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> DeleteAccount(string reason, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>> GetAccountTTL( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SetAccountTTL(CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase ttl, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendChangePhoneCode(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UserBase>> ChangePhone(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> UpdateDeviceLocked(int period, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase>> GetAuthorizations( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ResetAuthorization(long hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordBase>> GetPassword( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase>> GetPasswordSettings(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> UpdatePasswordSettings(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase newSettings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendConfirmPhoneCode(string hash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ConfirmPhone(string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase>> GetTmpPassword(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, int period, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase>> GetWebAuthorizations( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ResetWebAuthorization(long hash, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ResetWebAuthorizations( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>> GetAllSecureValues( CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>> GetSecureValue(List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>> SaveSecureValue(CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase value, long secureSecretId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> DeleteSecureValue(List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase>> GetAuthorizationForm(int botId, string scope, string publicKey, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> AcceptAuthorization(int botId, string scope, string publicKey, List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> valueHashes, CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeBase>> SendVerifyPhoneCode(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> VerifyPhone(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase>> SendVerifyEmailCode(string email, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> VerifyEmail(string email, string code, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.TakeoutBase>> InitTakeoutSession(bool contacts = true, bool messageUsers = true, bool messageChats = true, bool messageMegagroups = true, bool messageChannels = true, bool files = true, int? fileMaxSize = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> FinishTakeoutSession(bool success = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> ConfirmPasswordEmail(string code, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ResendPasswordEmail( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> CancelPasswordEmail( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> GetContactSignUpNotification( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SetContactSignUpNotification(bool silent, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>> GetNotifyExceptions(bool compareSound = true, CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase? peer = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> GetWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> UploadWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SaveWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, bool unsave, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> InstallWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> ResetWallPapers( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase>> GetAutoDownloadSettings( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<bool>> SaveAutoDownloadSettings(CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = true, bool high = true, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>> UploadTheme(CatraProto.Client.TL.Schemas.CloudChats.InputFileBase file, string fileName, string mimeType, CatraProto.Client.TL.Schemas.CloudChats.InputFileBase? thumb = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> CreateTheme(string slug, string title, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? document = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase? settings = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> UpdateTheme(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, string slug = null, string title = null, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase? document = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase? settings = null, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SaveTheme(CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, bool unsave, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> InstallTheme(bool dark = true, string format = null, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase? theme = null, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>> GetTheme(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, long documentId, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase>> GetThemes(string format, int hash, CancellationToken cancellationToken = default)
		{
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
		public async Task<RpcMessage<bool>> SetContentSettings(bool sensitiveEnabled = true, CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase>> GetContentSettings( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>> GetMultiWallPapers(List<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> wallpapers, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase>();
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>> GetGlobalPrivacySettings( CancellationToken cancellationToken = default)
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
		public async Task<RpcMessage<CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase>> SetGlobalPrivacySettings(CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase settings, CancellationToken cancellationToken = default)
		{
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