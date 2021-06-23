using System;
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
    public class Users
    {
        private MessagesHandler _messagesHandler;

        internal Users(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<UserBase>> GetUsersAsync(List<InputUserBase> id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<UserBase>();
            var methodBody = new GetUsers
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

        public async Task<RpcMessage<UserFullBase>> GetFullUserAsync(InputUserBase id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<UserFullBase>();
            var methodBody = new GetFullUser
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

        public async Task<RpcMessage<bool>> SetSecureValueErrorsAsync(InputUserBase id,
            List<SecureValueErrorBase> errors, CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (errors is null)
            {
                throw new ArgumentNullException(nameof(errors));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetSecureValueErrors
            {
                Id = id,
                Errors = errors
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