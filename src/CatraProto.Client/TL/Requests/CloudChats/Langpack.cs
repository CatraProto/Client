using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Langpack;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Langpack
    {
        private MessagesHandler _messagesHandler;

        internal Langpack(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<LangPackDifferenceBase>> GetLangPack(string langPack, string langCode, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackDifferenceBase>();
            var methodBody = new GetLangPack
            {
                LangPack = langPack,
                LangCode = langCode,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<LangPackStringBase>> GetStrings(string langPack, string langCode, List<string> keys, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackStringBase>();
            var methodBody = new GetStrings
            {
                LangPack = langPack,
                LangCode = langCode,
                Keys = keys,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<LangPackDifferenceBase>> GetDifference(string langPack, string langCode, int fromVersion, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackDifferenceBase>();
            var methodBody = new GetDifference
            {
                LangPack = langPack,
                LangCode = langCode,
                FromVersion = fromVersion,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<LangPackLanguageBase>> GetLanguages(string langPack, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackLanguageBase>();
            var methodBody = new GetLanguages
            {
                LangPack = langPack,
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<LangPackLanguageBase>> GetLanguage(string langPack, string langCode, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackLanguageBase>();
            var methodBody = new GetLanguage
            {
                LangPack = langPack,
                LangCode = langCode,
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