using System;
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
    public class Account
    {
        private MessagesHandler _messagesHandler;

        internal Account(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<bool>> RegisterDeviceAsync(int tokenType, string token, bool appSandbox,
            byte[] secret, List<int> otherUids, bool noMuted = true, CancellationToken cancellationToken = default)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (secret is null)
            {
                throw new ArgumentNullException(nameof(secret));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new RegisterDevice
            {
                TokenType = tokenType,
                Token = token,
                AppSandbox = appSandbox,
                Secret = secret,
                OtherUids = otherUids,
                NoMuted = noMuted
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> UnregisterDeviceAsync(int tokenType, string token, List<int> otherUids,
            CancellationToken cancellationToken = default)
        {
            if (token is null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new UnregisterDevice
            {
                TokenType = tokenType,
                Token = token,
                OtherUids = otherUids
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> UpdateNotifySettingsAsync(InputNotifyPeerBase peer,
            InputPeerNotifySettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new UpdateNotifySettings
            {
                Peer = peer,
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

        public async Task<RpcMessage<PeerNotifySettingsBase>> GetNotifySettingsAsync(InputNotifyPeerBase peer,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            var rpcResponse = new RpcMessage<PeerNotifySettingsBase>();
            var methodBody = new GetNotifySettings
            {
                Peer = peer
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ResetNotifySettingsAsync(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<UserBase>> UpdateProfileAsync(string firstName = null, string lastName = null,
            string about = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UserBase>();
            var methodBody = new UpdateProfile
            {
                FirstName = firstName,
                LastName = lastName,
                About = about
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> UpdateStatusAsync(bool offline,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new UpdateStatus
            {
                Offline = offline
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<WallPapersBase>> GetWallPapersAsync(int hash,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<WallPapersBase>();
            var methodBody = new GetWallPapers
            {
                Hash = hash
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReportPeerAsync(InputPeerBase peer, ReportReasonBase reason,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            if (reason is null)
            {
                throw new ArgumentNullException(nameof(reason));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ReportPeer
            {
                Peer = peer,
                Reason = reason
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> CheckUsernameAsync(string username,
            CancellationToken cancellationToken = default)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new CheckUsername
            {
                Username = username
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UserBase>> UpdateUsernameAsync(string username,
            CancellationToken cancellationToken = default)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var rpcResponse = new RpcMessage<UserBase>();
            var methodBody = new UpdateUsername
            {
                Username = username
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PrivacyRulesBase>> GetPrivacyAsync(InputPrivacyKeyBase key,
            CancellationToken cancellationToken = default)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var rpcResponse = new RpcMessage<PrivacyRulesBase>();
            var methodBody = new GetPrivacy
            {
                Key = key
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PrivacyRulesBase>> SetPrivacyAsync(InputPrivacyKeyBase key,
            List<InputPrivacyRuleBase> rules, CancellationToken cancellationToken = default)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (rules is null)
            {
                throw new ArgumentNullException(nameof(rules));
            }

            var rpcResponse = new RpcMessage<PrivacyRulesBase>();
            var methodBody = new SetPrivacy
            {
                Key = key,
                Rules = rules
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> DeleteAccountAsync(string reason,
            CancellationToken cancellationToken = default)
        {
            if (reason is null)
            {
                throw new ArgumentNullException(nameof(reason));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new DeleteAccount
            {
                Reason = reason
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<AccountDaysTTLBase>> GetAccountTTLAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> SetAccountTTLAsync(AccountDaysTTLBase ttl,
            CancellationToken cancellationToken = default)
        {
            if (ttl is null)
            {
                throw new ArgumentNullException(nameof(ttl));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetAccountTTL
            {
                Ttl = ttl
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<SentCodeBase>> SendChangePhoneCodeAsync(string phoneNumber,
            CodeSettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (phoneNumber is null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<SentCodeBase>();
            var methodBody = new SendChangePhoneCode
            {
                PhoneNumber = phoneNumber,
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

        public async Task<RpcMessage<UserBase>> ChangePhoneAsync(string phoneNumber, string phoneCodeHash,
            string phoneCode, CancellationToken cancellationToken = default)
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

            var rpcResponse = new RpcMessage<UserBase>();
            var methodBody = new ChangePhone
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

        public async Task<RpcMessage<bool>> UpdateDeviceLockedAsync(int period,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new UpdateDeviceLocked
            {
                Period = period
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationsBase>> GetAuthorizationsAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> ResetAuthorizationAsync(long hash,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ResetAuthorization
            {
                Hash = hash
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PasswordBase>> GetPasswordAsync(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<PasswordSettingsBase>> GetPasswordSettingsAsync(InputCheckPasswordSRPBase password,
            CancellationToken cancellationToken = default)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var rpcResponse = new RpcMessage<PasswordSettingsBase>();
            var methodBody = new GetPasswordSettings
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

        public async Task<RpcMessage<bool>> UpdatePasswordSettingsAsync(InputCheckPasswordSRPBase password,
            PasswordInputSettingsBase newSettings, CancellationToken cancellationToken = default)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (newSettings is null)
            {
                throw new ArgumentNullException(nameof(newSettings));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new UpdatePasswordSettings
            {
                Password = password,
                NewSettings = newSettings
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<SentCodeBase>> SendConfirmPhoneCodeAsync(string hash, CodeSettingsBase settings,
            CancellationToken cancellationToken = default)
        {
            if (hash is null)
            {
                throw new ArgumentNullException(nameof(hash));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<SentCodeBase>();
            var methodBody = new SendConfirmPhoneCode
            {
                Hash = hash,
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

        public async Task<RpcMessage<bool>> ConfirmPhoneAsync(string phoneCodeHash, string phoneCode,
            CancellationToken cancellationToken = default)
        {
            if (phoneCodeHash is null)
            {
                throw new ArgumentNullException(nameof(phoneCodeHash));
            }

            if (phoneCode is null)
            {
                throw new ArgumentNullException(nameof(phoneCode));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ConfirmPhone
            {
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

        public async Task<RpcMessage<TmpPasswordBase>> GetTmpPasswordAsync(InputCheckPasswordSRPBase password,
            int period, CancellationToken cancellationToken = default)
        {
            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var rpcResponse = new RpcMessage<TmpPasswordBase>();
            var methodBody = new GetTmpPassword
            {
                Password = password,
                Period = period
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<WebAuthorizationsBase>> GetWebAuthorizationsAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> ResetWebAuthorizationAsync(long hash,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ResetWebAuthorization
            {
                Hash = hash
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ResetWebAuthorizationsAsync(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<SecureValueBase>> GetAllSecureValuesAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<SecureValueBase>> GetSecureValueAsync(List<SecureValueTypeBase> types,
            CancellationToken cancellationToken = default)
        {
            if (types is null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            var rpcResponse = new RpcMessage<SecureValueBase>();
            var methodBody = new GetSecureValue
            {
                Types = types
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<SecureValueBase>> SaveSecureValueAsync(InputSecureValueBase value,
            long secureSecretId, CancellationToken cancellationToken = default)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var rpcResponse = new RpcMessage<SecureValueBase>();
            var methodBody = new SaveSecureValue
            {
                Value = value,
                SecureSecretId = secureSecretId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> DeleteSecureValueAsync(List<SecureValueTypeBase> types,
            CancellationToken cancellationToken = default)
        {
            if (types is null)
            {
                throw new ArgumentNullException(nameof(types));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new DeleteSecureValue
            {
                Types = types
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationFormBase>> GetAuthorizationFormAsync(int botId, string scope,
            string publicKey, CancellationToken cancellationToken = default)
        {
            if (scope is null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (publicKey is null)
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            var rpcResponse = new RpcMessage<AuthorizationFormBase>();
            var methodBody = new GetAuthorizationForm
            {
                BotId = botId,
                Scope = scope,
                PublicKey = publicKey
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> AcceptAuthorizationAsync(int botId, string scope, string publicKey,
            List<SecureValueHashBase> valueHashes, SecureCredentialsEncryptedBase credentials,
            CancellationToken cancellationToken = default)
        {
            if (scope is null)
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (publicKey is null)
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            if (valueHashes is null)
            {
                throw new ArgumentNullException(nameof(valueHashes));
            }

            if (credentials is null)
            {
                throw new ArgumentNullException(nameof(credentials));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new AcceptAuthorization
            {
                BotId = botId,
                Scope = scope,
                PublicKey = publicKey,
                ValueHashes = valueHashes,
                Credentials = credentials
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<SentCodeBase>> SendVerifyPhoneCodeAsync(string phoneNumber,
            CodeSettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (phoneNumber is null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<SentCodeBase>();
            var methodBody = new SendVerifyPhoneCode
            {
                PhoneNumber = phoneNumber,
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

        public async Task<RpcMessage<bool>> VerifyPhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode,
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

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new VerifyPhone
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

        public async Task<RpcMessage<SentEmailCodeBase>> SendVerifyEmailCodeAsync(string email,
            CancellationToken cancellationToken = default)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            var rpcResponse = new RpcMessage<SentEmailCodeBase>();
            var methodBody = new SendVerifyEmailCode
            {
                Email = email
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> VerifyEmailAsync(string email, string code,
            CancellationToken cancellationToken = default)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new VerifyEmail
            {
                Email = email,
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

        public async Task<RpcMessage<TakeoutBase>> InitTakeoutSessionAsync(bool contacts = true,
            bool messageUsers = true, bool messageChats = true, bool messageMegagroups = true,
            bool messageChannels = true, bool files = true, int? fileMaxSize = null,
            CancellationToken cancellationToken = default)
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
                FileMaxSize = fileMaxSize
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> FinishTakeoutSessionAsync(bool success = true,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new FinishTakeoutSession
            {
                Success = success
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ConfirmPasswordEmailAsync(string code,
            CancellationToken cancellationToken = default)
        {
            if (code is null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ConfirmPasswordEmail
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

        public async Task<RpcMessage<bool>> ResendPasswordEmailAsync(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> CancelPasswordEmailAsync(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> GetContactSignUpNotificationAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> SetContactSignUpNotificationAsync(bool silent,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetContactSignUpNotification
            {
                Silent = silent
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> GetNotifyExceptionsAsync(bool compareSound = true,
            InputNotifyPeerBase peer = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new GetNotifyExceptions
            {
                CompareSound = compareSound,
                Peer = peer
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<WallPaperBase>> GetWallPaperAsync(InputWallPaperBase wallpaper,
            CancellationToken cancellationToken = default)
        {
            if (wallpaper is null)
            {
                throw new ArgumentNullException(nameof(wallpaper));
            }

            var rpcResponse = new RpcMessage<WallPaperBase>();
            var methodBody = new GetWallPaper
            {
                Wallpaper = wallpaper
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<WallPaperBase>> UploadWallPaperAsync(InputFileBase file, string mimeType,
            WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (mimeType is null)
            {
                throw new ArgumentNullException(nameof(mimeType));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<WallPaperBase>();
            var methodBody = new UploadWallPaper
            {
                File = file,
                MimeType = mimeType,
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

        public async Task<RpcMessage<bool>> SaveWallPaperAsync(InputWallPaperBase wallpaper, bool unsave,
            WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (wallpaper is null)
            {
                throw new ArgumentNullException(nameof(wallpaper));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveWallPaper
            {
                Wallpaper = wallpaper,
                Unsave = unsave,
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

        public async Task<RpcMessage<bool>> InstallWallPaperAsync(InputWallPaperBase wallpaper,
            WallPaperSettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (wallpaper is null)
            {
                throw new ArgumentNullException(nameof(wallpaper));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new InstallWallPaper
            {
                Wallpaper = wallpaper,
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

        public async Task<RpcMessage<bool>> ResetWallPapersAsync(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<AutoDownloadSettingsBase>> GetAutoDownloadSettingsAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> SaveAutoDownloadSettingsAsync(
            Schemas.CloudChats.AutoDownloadSettingsBase settings, bool low = true, bool high = true,
            CancellationToken cancellationToken = default)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveAutoDownloadSettings
            {
                Settings = settings,
                Low = low,
                High = high
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<DocumentBase>> UploadThemeAsync(InputFileBase file, string fileName,
            string mimeType, InputFileBase thumb = null, CancellationToken cancellationToken = default)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (mimeType is null)
            {
                throw new ArgumentNullException(nameof(mimeType));
            }

            var rpcResponse = new RpcMessage<DocumentBase>();
            var methodBody = new UploadTheme
            {
                File = file,
                FileName = fileName,
                MimeType = mimeType,
                Thumb = thumb
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ThemeBase>> CreateThemeAsync(string slug, string title,
            InputDocumentBase document = null, InputThemeSettingsBase settings = null,
            CancellationToken cancellationToken = default)
        {
            if (slug is null)
            {
                throw new ArgumentNullException(nameof(slug));
            }

            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var rpcResponse = new RpcMessage<ThemeBase>();
            var methodBody = new CreateTheme
            {
                Slug = slug,
                Title = title,
                Document = document,
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

        public async Task<RpcMessage<ThemeBase>> UpdateThemeAsync(string format, InputThemeBase theme,
            string slug = null, string title = null, InputDocumentBase document = null,
            InputThemeSettingsBase settings = null, CancellationToken cancellationToken = default)
        {
            if (format is null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (theme is null)
            {
                throw new ArgumentNullException(nameof(theme));
            }

            var rpcResponse = new RpcMessage<ThemeBase>();
            var methodBody = new UpdateTheme
            {
                Format = format,
                Theme = theme,
                Slug = slug,
                Title = title,
                Document = document,
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

        public async Task<RpcMessage<bool>> SaveThemeAsync(InputThemeBase theme, bool unsave,
            CancellationToken cancellationToken = default)
        {
            if (theme is null)
            {
                throw new ArgumentNullException(nameof(theme));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveTheme
            {
                Theme = theme,
                Unsave = unsave
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> InstallThemeAsync(bool dark = true, string format = null,
            InputThemeBase theme = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new InstallTheme
            {
                Dark = dark,
                Format = format,
                Theme = theme
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ThemeBase>> GetThemeAsync(string format, InputThemeBase theme, long documentId,
            CancellationToken cancellationToken = default)
        {
            if (format is null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (theme is null)
            {
                throw new ArgumentNullException(nameof(theme));
            }

            var rpcResponse = new RpcMessage<ThemeBase>();
            var methodBody = new GetTheme
            {
                Format = format,
                Theme = theme,
                DocumentId = documentId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ThemesBase>> GetThemesAsync(string format, int hash,
            CancellationToken cancellationToken = default)
        {
            if (format is null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            var rpcResponse = new RpcMessage<ThemesBase>();
            var methodBody = new GetThemes
            {
                Format = format,
                Hash = hash
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetContentSettingsAsync(bool sensitiveEnabled = true,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetContentSettings
            {
                SensitiveEnabled = sensitiveEnabled
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ContentSettingsBase>> GetContentSettingsAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<WallPaperBase>> GetMultiWallPapersAsync(List<InputWallPaperBase> wallpapers,
            CancellationToken cancellationToken = default)
        {
            if (wallpapers is null)
            {
                throw new ArgumentNullException(nameof(wallpapers));
            }

            var rpcResponse = new RpcMessage<WallPaperBase>();
            var methodBody = new GetMultiWallPapers
            {
                Wallpapers = wallpapers
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<GlobalPrivacySettingsBase>> GetGlobalPrivacySettingsAsync(
            CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<GlobalPrivacySettingsBase>> SetGlobalPrivacySettingsAsync(
            GlobalPrivacySettingsBase settings, CancellationToken cancellationToken = default)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var rpcResponse = new RpcMessage<GlobalPrivacySettingsBase>();
            var methodBody = new SetGlobalPrivacySettings
            {
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
    }
}