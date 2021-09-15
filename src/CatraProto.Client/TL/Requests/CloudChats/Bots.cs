using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Bots;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Bots
    {
        private readonly MessagesQueue _messagesQueue;

        internal Bots(MessagesQueue messagesQueue)
        {
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<DataJSONBase>> SendCustomRequestAsync(string customMethod, DataJSONBase pparams,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<DataJSONBase>(
            );
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

        public async Task<RpcMessage<bool>> AnswerWebhookJSONQueryAsync(long queryId, DataJSONBase data,
            MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>(
            );
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

        public async Task<RpcMessage<bool>> SetBotCommandsAsync(IList<BotCommandBase> commands, MessageSendingOptions? messageSendingOptions = null,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>(
            );
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SetBotCommands
            {
                Commands = commands
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}