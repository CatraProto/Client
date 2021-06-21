using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using AutoDownloadSettingsBase = CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase;
using UpdateNotifySettings = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateNotifySettings;
using UpdateTheme = CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateTheme;

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
			var methodBody = new RegisterDevice
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
			var methodBody = new UnregisterDevice
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

		public async Task<RpcMessage<bool>> UpdateNotifySettings(InputNotifyPeerBase peer, InputPeerNotifySettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new UpdateNotifySettings
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

		public async Task<RpcMessage<PeerNotifySettingsBase>> GetNotifySettings(InputNotifyPeerBase peer, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PeerNotifySettingsBase>();
			var methodBody = new GetNotifySettings
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

		public async Task<RpcMessage<bool>> ResetNotifySettings(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResetNotifySettings();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<UserBase>> UpdateProfile(string firstName = null, string lastName = null, string about = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserBase>();
			var methodBody = new UpdateProfile
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
			var methodBody = new UpdateStatus
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

		public async Task<RpcMessage<WallPapersBase>> GetWallPapers(int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPapersBase>();
			var methodBody = new GetWallPapers
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

		public async Task<RpcMessage<bool>> ReportPeer(InputPeerBase peer, ReportReasonBase reason, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ReportPeer
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
			var methodBody = new CheckUsername
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

		public async Task<RpcMessage<UserBase>> UpdateUsername(string username, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserBase>();
			var methodBody = new UpdateUsername
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

		public async Task<RpcMessage<PrivacyRulesBase>> GetPrivacy(InputPrivacyKeyBase key, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PrivacyRulesBase>();
			var methodBody = new GetPrivacy
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

		public async Task<RpcMessage<PrivacyRulesBase>> SetPrivacy(InputPrivacyKeyBase key, List<InputPrivacyRuleBase> rules, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PrivacyRulesBase>();
			var methodBody = new SetPrivacy
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
			var methodBody = new DeleteAccount
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

		public async Task<RpcMessage<AccountDaysTTLBase>> GetAccountTTL(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AccountDaysTTLBase>();
			var methodBody = new GetAccountTTL();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> SetAccountTTL(AccountDaysTTLBase ttl, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SetAccountTTL
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

		public async Task<RpcMessage<SentCodeBase>> SendChangePhoneCode(string phoneNumber, CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new SendChangePhoneCode
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

		public async Task<RpcMessage<UserBase>> ChangePhone(string phoneNumber, string phoneCodeHash, string phoneCode, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UserBase>();
			var methodBody = new ChangePhone
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
			var methodBody = new UpdateDeviceLocked
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

		public async Task<RpcMessage<AuthorizationsBase>> GetAuthorizations(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationsBase>();
			var methodBody = new GetAuthorizations();

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
			var methodBody = new ResetAuthorization
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

		public async Task<RpcMessage<PasswordBase>> GetPassword(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PasswordBase>();
			var methodBody = new GetPassword();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<PasswordSettingsBase>> GetPasswordSettings(InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<PasswordSettingsBase>();
			var methodBody = new GetPasswordSettings
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

		public async Task<RpcMessage<bool>> UpdatePasswordSettings(InputCheckPasswordSRPBase password, PasswordInputSettingsBase newSettings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new UpdatePasswordSettings
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

		public async Task<RpcMessage<SentCodeBase>> SendConfirmPhoneCode(string hash, CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new SendConfirmPhoneCode
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
			var methodBody = new ConfirmPhone
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

		public async Task<RpcMessage<TmpPasswordBase>> GetTmpPassword(InputCheckPasswordSRPBase password, int period, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<TmpPasswordBase>();
			var methodBody = new GetTmpPassword
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

		public async Task<RpcMessage<WebAuthorizationsBase>> GetWebAuthorizations(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WebAuthorizationsBase>();
			var methodBody = new GetWebAuthorizations();

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
			var methodBody = new ResetWebAuthorization
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

		public async Task<RpcMessage<bool>> ResetWebAuthorizations(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResetWebAuthorizations();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SecureValueBase>> GetAllSecureValues(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SecureValueBase>();
			var methodBody = new GetAllSecureValues();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<SecureValueBase>> GetSecureValue(List<SecureValueTypeBase> types, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SecureValueBase>();
			var methodBody = new GetSecureValue
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

		public async Task<RpcMessage<SecureValueBase>> SaveSecureValue(InputSecureValueBase value, long secureSecretId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SecureValueBase>();
			var methodBody = new SaveSecureValue
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

		public async Task<RpcMessage<bool>> DeleteSecureValue(List<SecureValueTypeBase> types, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new DeleteSecureValue
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

		public async Task<RpcMessage<AuthorizationFormBase>> GetAuthorizationForm(int botId, string scope, string publicKey, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AuthorizationFormBase>();
			var methodBody = new GetAuthorizationForm
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

		public async Task<RpcMessage<bool>> AcceptAuthorization(int botId, string scope, string publicKey, List<SecureValueHashBase> valueHashes, SecureCredentialsEncryptedBase credentials, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new AcceptAuthorization
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

		public async Task<RpcMessage<SentCodeBase>> SendVerifyPhoneCode(string phoneNumber, CodeSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentCodeBase>();
			var methodBody = new SendVerifyPhoneCode
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
			var methodBody = new VerifyPhone
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

		public async Task<RpcMessage<SentEmailCodeBase>> SendVerifyEmailCode(string email, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<SentEmailCodeBase>();
			var methodBody = new SendVerifyEmailCode
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
			var methodBody = new VerifyEmail
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

		public async Task<RpcMessage<TakeoutBase>> InitTakeoutSession(bool contacts = true, bool messageUsers = true, bool messageChats = true, bool messageMegagroups = true, bool messageChannels = true, bool files = true, int? fileMaxSize = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<TakeoutBase>();
			var methodBody = new InitTakeoutSession
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
			var methodBody = new FinishTakeoutSession
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
			var methodBody = new ConfirmPasswordEmail
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

		public async Task<RpcMessage<bool>> ResendPasswordEmail(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResendPasswordEmail();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> CancelPasswordEmail(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new CancelPasswordEmail();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> GetContactSignUpNotification(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new GetContactSignUpNotification();

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
			var methodBody = new SetContactSignUpNotification
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

		public async Task<RpcMessage<UpdatesBase>> GetNotifyExceptions(bool compareSound = true, InputNotifyPeerBase? peer = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<UpdatesBase>();
			var methodBody = new GetNotifyExceptions
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

		public async Task<RpcMessage<WallPaperBase>> GetWallPaper(InputWallPaperBase wallpaper, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPaperBase>();
			var methodBody = new GetWallPaper
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

		public async Task<RpcMessage<WallPaperBase>> UploadWallPaper(InputFileBase file, string mimeType, WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPaperBase>();
			var methodBody = new UploadWallPaper
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

		public async Task<RpcMessage<bool>> SaveWallPaper(InputWallPaperBase wallpaper, bool unsave, WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveWallPaper
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

		public async Task<RpcMessage<bool>> InstallWallPaper(InputWallPaperBase wallpaper, WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new InstallWallPaper
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

		public async Task<RpcMessage<bool>> ResetWallPapers(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new ResetWallPapers();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<AutoDownloadSettingsBase>> GetAutoDownloadSettings(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<AutoDownloadSettingsBase>();
			var methodBody = new GetAutoDownloadSettings();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<bool>> SaveAutoDownloadSettings(Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = true, bool high = true, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveAutoDownloadSettings
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

		public async Task<RpcMessage<DocumentBase>> UploadTheme(InputFileBase file, string fileName, string mimeType, InputFileBase? thumb = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<DocumentBase>();
			var methodBody = new UploadTheme
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

		public async Task<RpcMessage<ThemeBase>> CreateTheme(string slug, string title, InputDocumentBase? document = null, InputThemeSettingsBase? settings = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemeBase>();
			var methodBody = new CreateTheme
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

		public async Task<RpcMessage<ThemeBase>> UpdateTheme(string format, InputThemeBase theme, string slug = null, string title = null, InputDocumentBase? document = null, InputThemeSettingsBase? settings = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemeBase>();
			var methodBody = new UpdateTheme
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

		public async Task<RpcMessage<bool>> SaveTheme(InputThemeBase theme, bool unsave, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new SaveTheme
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

		public async Task<RpcMessage<bool>> InstallTheme(bool dark = true, string format = null, InputThemeBase? theme = null, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<bool>();
			var methodBody = new InstallTheme
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

		public async Task<RpcMessage<ThemeBase>> GetTheme(string format, InputThemeBase theme, long documentId, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemeBase>();
			var methodBody = new GetTheme
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

		public async Task<RpcMessage<ThemesBase>> GetThemes(string format, int hash, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ThemesBase>();
			var methodBody = new GetThemes
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
			var methodBody = new SetContentSettings
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

		public async Task<RpcMessage<ContentSettingsBase>> GetContentSettings(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<ContentSettingsBase>();
			var methodBody = new GetContentSettings();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<WallPaperBase>> GetMultiWallPapers(List<InputWallPaperBase> wallpapers, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<WallPaperBase>();
			var methodBody = new GetMultiWallPapers
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

		public async Task<RpcMessage<GlobalPrivacySettingsBase>> GetGlobalPrivacySettings(CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<GlobalPrivacySettingsBase>();
			var methodBody = new GetGlobalPrivacySettings();

			await await _messagesHandler.EnqueueMessage(new OutgoingMessage
			{
				Body = methodBody,
				CancellationToken = cancellationToken,
				IsEncrypted = true
			}, rpcResponse);
			return rpcResponse;
		}

		public async Task<RpcMessage<GlobalPrivacySettingsBase>> SetGlobalPrivacySettings(GlobalPrivacySettingsBase settings, CancellationToken cancellationToken = default)
		{
			var rpcResponse = new RpcMessage<GlobalPrivacySettingsBase>();
			var methodBody = new SetGlobalPrivacySettings
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