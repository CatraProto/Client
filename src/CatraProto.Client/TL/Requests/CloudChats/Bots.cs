using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.Vectors;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Bots;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Bots
    {
        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal Bots(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<DataJSONBase>> SendCustomRequestAsync(string customMethod, DataJSONBase pparams, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<DataJSONBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SendCustomRequest
            {
                CustomMethod = customMethod,
                Params = pparams
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> AnswerWebhookJSONQueryAsync(long queryId, DataJSONBase data, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new AnswerWebhookJSONQuery
            {
                QueryId = queryId,
                Data = data
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetBotCommandsAsync(BotCommandScopeBase scope, string langCode, IList<BotCommandBase> commands, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SetBotCommands
            {
                Scope = scope,
                LangCode = langCode,
                Commands = commands
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ResetBotCommandsAsync(BotCommandScopeBase scope, string langCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ResetBotCommands
            {
                Scope = scope,
                LangCode = langCode
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<RpcVector<BotCommandBase>>> GetBotCommandsAsync(BotCommandScopeBase scope, string langCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<RpcVector<BotCommandBase>>(new RpcVector<BotCommandBase>());
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new GetBotCommands
            {
                Scope = scope,
                LangCode = langCode
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}