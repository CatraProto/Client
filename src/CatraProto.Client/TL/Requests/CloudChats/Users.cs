using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Users;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Users
    {
        private MessagesHandler _messagesHandler;

        internal Users(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<UserBase>> GetUsers(List<InputUserBase> id, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UserBase>();
            var methodBody = new GetUsers
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

        public async Task<RpcMessage<UserFullBase>> GetFullUser(InputUserBase id, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UserFullBase>();
            var methodBody = new GetFullUser
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

        public async Task<RpcMessage<bool>> SetSecureValueErrors(InputUserBase id, List<SecureValueErrorBase> errors, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetSecureValueErrors
            {
                Id = id,
                Errors = errors,
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