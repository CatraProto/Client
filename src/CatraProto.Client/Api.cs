using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.TL.Requests;

namespace CatraProto.Client
{
    public class Api
    {
        public CloudChatsApi CloudChatsApi { get; }
        public MTProtoApi MtProtoApi { get; }
        internal Api(MessagesQueue messagesQueue)
        {
            CloudChatsApi = new CloudChatsApi(messagesQueue);
            MtProtoApi = new MTProtoApi(messagesQueue);
        }
    }
}