using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Help;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public class Help
    {
        private MessagesHandler _messagesHandler;

        internal Help(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<ConfigBase>> GetConfigAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ConfigBase>();
            var methodBody = new GetConfig();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<NearestDcBase>> GetNearestDcAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<NearestDcBase>();
            var methodBody = new GetNearestDc();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<AppUpdateBase>> GetAppUpdateAsync(string source,
            CancellationToken cancellationToken = default)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var rpcResponse = new RpcMessage<AppUpdateBase>();
            var methodBody = new GetAppUpdate
            {
                Source = source
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<InviteTextBase>> GetInviteTextAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<InviteTextBase>();
            var methodBody = new GetInviteText();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<SupportBase>> GetSupportAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SupportBase>();
            var methodBody = new GetSupport();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> GetAppChangelogAsync(string prevAppVersion,
            CancellationToken cancellationToken = default)
        {
            if (prevAppVersion is null)
            {
                throw new ArgumentNullException(nameof(prevAppVersion));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new GetAppChangelog
            {
                PrevAppVersion = prevAppVersion
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetBotUpdatesStatusAsync(int pendingUpdatesCount, string message,
            CancellationToken cancellationToken = default)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetBotUpdatesStatus
            {
                PendingUpdatesCount = pendingUpdatesCount,
                Message = message
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<CdnConfigBase>> GetCdnConfigAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<CdnConfigBase>();
            var methodBody = new GetCdnConfig();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<RecentMeUrlsBase>> GetRecentMeUrlsAsync(string referer,
            CancellationToken cancellationToken = default)
        {
            if (referer is null)
            {
                throw new ArgumentNullException(nameof(referer));
            }

            var rpcResponse = new RpcMessage<RecentMeUrlsBase>();
            var methodBody = new GetRecentMeUrls
            {
                Referer = referer
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<TermsOfServiceUpdateBase>> GetTermsOfServiceUpdateAsync(
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<TermsOfServiceUpdateBase>();
            var methodBody = new GetTermsOfServiceUpdate();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> AcceptTermsOfServiceAsync(DataJSONBase id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new AcceptTermsOfService
            {
                Id = id
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<DeepLinkInfoBase>> GetDeepLinkInfoAsync(string path,
            CancellationToken cancellationToken = default)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            var rpcResponse = new RpcMessage<DeepLinkInfoBase>();
            var methodBody = new GetDeepLinkInfo
            {
                Path = path
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<JSONValueBase>> GetAppConfigAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<JSONValueBase>();
            var methodBody = new GetAppConfig();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SaveAppLogAsync(List<InputAppEventBase> events,
            CancellationToken cancellationToken = default)
        {
            if (events is null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveAppLog
            {
                Events = events
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PassportConfigBase>> GetPassportConfigAsync(int hash,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PassportConfigBase>();
            var methodBody = new GetPassportConfig
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

        public async Task<RpcMessage<SupportNameBase>> GetSupportNameAsync(
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SupportNameBase>();
            var methodBody = new GetSupportName();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UserInfoBase>> GetUserInfoAsync(InputUserBase userId,
            CancellationToken cancellationToken = default)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var rpcResponse = new RpcMessage<UserInfoBase>();
            var methodBody = new GetUserInfo
            {
                UserId = userId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UserInfoBase>> EditUserInfoAsync(InputUserBase userId, string message,
            List<MessageEntityBase> entities, CancellationToken cancellationToken = default)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            var rpcResponse = new RpcMessage<UserInfoBase>();
            var methodBody = new EditUserInfo
            {
                UserId = userId,
                Message = message,
                Entities = entities
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PromoDataBase>> GetPromoDataAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PromoDataBase>();
            var methodBody = new GetPromoData();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> HidePromoDataAsync(InputPeerBase peer,
            CancellationToken cancellationToken = default)
        {
            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new HidePromoData
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

        public async Task<RpcMessage<bool>> DismissSuggestionAsync(string suggestion,
            CancellationToken cancellationToken = default)
        {
            if (suggestion is null)
            {
                throw new ArgumentNullException(nameof(suggestion));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new DismissSuggestion
            {
                Suggestion = suggestion
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<CountriesListBase>> GetCountriesListAsync(string langCode, int hash,
            CancellationToken cancellationToken = default)
        {
            if (langCode is null)
            {
                throw new ArgumentNullException(nameof(langCode));
            }

            var rpcResponse = new RpcMessage<CountriesListBase>();
            var methodBody = new GetCountriesList
            {
                LangCode = langCode,
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
    }
}