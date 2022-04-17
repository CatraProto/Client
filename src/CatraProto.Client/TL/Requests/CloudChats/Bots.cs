using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;


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

        public async Task<RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>> SendCustomRequestAsync(string customMethod, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase pparams, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.SendCustomRequest()
            {
                CustomMethod = customMethod,
                Params = pparams,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> AnswerWebhookJSONQueryAsync(long queryId, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.AnswerWebhookJSONQuery()
            {
                QueryId = queryId,
                Data = data,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> SetBotCommandsAsync(CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope, string langCode, List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> commands, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.SetBotCommands()
            {
                Scope = scope,
                LangCode = langCode,
                Commands = commands,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<bool>> ResetBotCommandsAsync(CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope, string langCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<bool>(
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.ResetBotCommands()
            {
                Scope = scope,
                LangCode = langCode,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
        public async Task<RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>>> GetBotCommandsAsync(CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase scope, string langCode, CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {

            var rpcResponse = new RpcResponse<CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>>(
            new CatraProto.Client.MTProto.Rpc.Vectors.RpcVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>()
            );
            messageSendingOptions ??= new CatraProto.Client.Connections.MessageScheduling.MessageSendingOptions(isEncrypted: true);
            var methodBody = new CatraProto.Client.TL.Schemas.CloudChats.Bots.GetBotCommands()
            {
                Scope = scope,
                LangCode = langCode,
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

    }
}