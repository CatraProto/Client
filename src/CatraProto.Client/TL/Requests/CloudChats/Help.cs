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
    public partial class Help
    {
        private MessagesHandler _messagesHandler;

        internal Help(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<ConfigBase>> GetConfig(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<NearestDcBase>> GetNearestDc(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<AppUpdateBase>> GetAppUpdate(string source, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AppUpdateBase>();
            var methodBody = new GetAppUpdate
            {
                Source = source,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<InviteTextBase>> GetInviteText(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<SupportBase>> GetSupport(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<UpdatesBase>> GetAppChangelog(string prevAppVersion, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new GetAppChangelog
            {
                PrevAppVersion = prevAppVersion,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetBotUpdatesStatus(int pendingUpdatesCount, string message, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetBotUpdatesStatus
            {
                PendingUpdatesCount = pendingUpdatesCount,
                Message = message,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<CdnConfigBase>> GetCdnConfig(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<RecentMeUrlsBase>> GetRecentMeUrls(string referer, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RecentMeUrlsBase>();
            var methodBody = new GetRecentMeUrls
            {
                Referer = referer,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<TermsOfServiceUpdateBase>> GetTermsOfServiceUpdate(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> AcceptTermsOfService(DataJSONBase id, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new AcceptTermsOfService
            {
                Id = id,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<DeepLinkInfoBase>> GetDeepLinkInfo(string path, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<DeepLinkInfoBase>();
            var methodBody = new GetDeepLinkInfo
            {
                Path = path,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<JSONValueBase>> GetAppConfig(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> SaveAppLog(List<InputAppEventBase> events, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SaveAppLog
            {
                Events = events,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PassportConfigBase>> GetPassportConfig(int hash, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PassportConfigBase>();
            var methodBody = new GetPassportConfig
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

        public async Task<RpcMessage<SupportNameBase>> GetSupportName(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<UserInfoBase>> GetUserInfo(InputUserBase userId, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UserInfoBase>();
            var methodBody = new GetUserInfo
            {
                UserId = userId,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UserInfoBase>> EditUserInfo(InputUserBase userId, string message, List<MessageEntityBase> entities, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UserInfoBase>();
            var methodBody = new EditUserInfo
            {
                UserId = userId,
                Message = message,
                Entities = entities,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<PromoDataBase>> GetPromoData(CancellationToken cancellationToken = default)
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

        public async Task<RpcMessage<bool>> HidePromoData(InputPeerBase peer, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new HidePromoData
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

        public async Task<RpcMessage<bool>> DismissSuggestion(string suggestion, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new DismissSuggestion
            {
                Suggestion = suggestion,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<CountriesListBase>> GetCountriesList(string langCode, int hash, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<CountriesListBase>();
            var methodBody = new GetCountriesList
            {
                LangCode = langCode,
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
    }
}