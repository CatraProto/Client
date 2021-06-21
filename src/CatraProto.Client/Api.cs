using CatraProto.Client.Connections;
using CatraProto.Client.TL.Requests;
using CatraProto.Client.TL.Requests.CloudChats;

namespace CatraProto.Client
{
    public class Api
    {
        public CloudChatsApi CloudChatsApi { get; }
        public MTProtoApi MtProtoApi { get; }

        internal Api(MessagesHandler messagesHandler)
        {
            CloudChatsApi = new CloudChatsApi(messagesHandler);
            MtProtoApi = new MTProtoApi(messagesHandler);
        }
    }
}