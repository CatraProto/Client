using System;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
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

        public async Task<RpcMessage<UpdatesBase>> SendMessage( /*i parametri*/ CancellationToken token = default)
        {
            /*var message = new RpcMessage<UpdateBase>();
            await _messagesHandler.EnqueueMessage(new OutgoingMessage()
            {
                IsEncrypted = true,
                Body = new SendMessage(),
                CancellationToken = token
            }, message).Unwrap();
            return message;*/
            throw new NotImplementedException();
        }
    }
}