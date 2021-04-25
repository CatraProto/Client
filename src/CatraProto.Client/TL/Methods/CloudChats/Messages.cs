using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using EncryptedMessage = CatraProto.Client.Connections.Messages.EncryptedMessage;

namespace CatraProto.Client.TL.Methods.CloudChats
{
    public partial class Messages
    {
        private MessagesHandler _messagesHandler;

        internal Messages(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<byte[]> ExecuteMethod<T>(IMethod<T> method, CancellationToken token)
        {
            var toStream = method.ToArray(MergedProvider.DefaultInstance);
            var msg = new EncryptedMessage
            {
                Token = token,
                Message = toStream
            };

            _messagesHandler.QueueEncryptedMessage(msg, out var completion);
            return (await completion).Message;
        }

        public async Task<RpcMessage<UpdatesBase>> SendMessage( /*i parametri*/ CancellationToken token = default)
        {
            var sendMessage = new SendMessage()
            {
                //bla bla i parametri
            };

            var byteArray = await ExecuteMethod(sendMessage, token);

            RpcMessage<UpdatesBase> message;
            if (RpcReadingTools.IsRpcError(byteArray, out RpcError error))
            {
                message = RpcMessage<UpdatesBase>.Create(error, null);
            }
            else
            {
                message = RpcMessage<UpdatesBase>.Create(null, byteArray.ToObject<UpdatesBase>(MergedProvider.DefaultInstance));
            }

            return message;
        }
    }
}