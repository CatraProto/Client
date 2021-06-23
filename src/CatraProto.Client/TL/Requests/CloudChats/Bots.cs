using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Bots;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public class Bots
    {
        private MessagesHandler _messagesHandler;

        internal Bots(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<DataJSONBase>> SendCustomRequestAsync(string customMethod, DataJSONBase pparams,
            CancellationToken cancellationToken = default)
        {
            if (customMethod is null)
            {
                throw new ArgumentNullException(nameof(customMethod));
            }

            if (pparams is null)
            {
                throw new ArgumentNullException(nameof(pparams));
            }

            var rpcResponse = new RpcMessage<DataJSONBase>();
            var methodBody = new SendCustomRequest
            {
                CustomMethod = customMethod,
                Params = pparams
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> AnswerWebhookJSONQueryAsync(long queryId, DataJSONBase data,
            CancellationToken cancellationToken = default)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new AnswerWebhookJSONQuery
            {
                QueryId = queryId,
                Data = data
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetBotCommandsAsync(List<BotCommandBase> commands,
            CancellationToken cancellationToken = default)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetBotCommands
            {
                Commands = commands
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