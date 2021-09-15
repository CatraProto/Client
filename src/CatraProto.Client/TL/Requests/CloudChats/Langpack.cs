using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Langpack;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Langpack
    {
        private readonly MessagesQueue _messagesQueue;

        internal Langpack(MessagesQueue messagesQueue)
        {
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<LangPackDifferenceBase>> GetLangPackAsync(string langPack, string langCode,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackDifferenceBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetLangPack
            {
                LangPack = langPack,
                LangCode = langCode
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcVector<LangPackStringBase>>> GetStringsAsync(string langPack, string langCode, IList<string> keys,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcVector<LangPackStringBase>>(
                new RpcVector<LangPackStringBase>()
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetStrings
            {
                LangPack = langPack,
                LangCode = langCode,
                Keys = keys
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<LangPackDifferenceBase>> GetDifferenceAsync(string langPack, string langCode, int fromVersion,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackDifferenceBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetDifference
            {
                LangPack = langPack,
                LangCode = langCode,
                FromVersion = fromVersion
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcVector<LangPackLanguageBase>>> GetLanguagesAsync(string langPack,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcVector<LangPackLanguageBase>>(
                new RpcVector<LangPackLanguageBase>()
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetLanguages
            {
                LangPack = langPack
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<LangPackLanguageBase>> GetLanguageAsync(string langPack, string langCode,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LangPackLanguageBase>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetLanguage
            {
                LangPack = langPack,
                LangCode = langCode
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}