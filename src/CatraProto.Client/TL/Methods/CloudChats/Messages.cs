using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL.Interfaces;

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
            await _messagesHandler.SendRpc(method);
            throw new NotImplementedException();
            //return (await completion).Message;
        }

        public async Task<RpcMessage<UpdatesBase>> SendMessage( /*i parametri*/ CancellationToken token = default)
        {
            var sendMessage = new SendMessage();

            var byteArray = await ExecuteMethod(sendMessage, token);

            RpcMessage<UpdatesBase> message = null;
            if (RpcReadingTools.IsRpcError(byteArray, out var error))
            {
                //message = RpcMessage<UpdatesBase>.Create(error, null);
            }
            else
            {
                //message = RpcMessage<UpdatesBase>.Create(null, byteArray.ToObject<UpdatesBase>(MergedProvider.Singleton));
            }

            return message;
        }
    }
}