using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.TL.Requests;

namespace CatraProto.Client
{
    public class Api
    {
        public CloudChatsApi CloudChatsApi { get; }
        internal MTProtoApi MtProtoApi { get; }

        internal Api(TelegramClient client, MessagesQueue messagesQueue)
        {
            CloudChatsApi = new CloudChatsApi(client, messagesQueue);
            MtProtoApi = new MTProtoApi(client, messagesQueue);
        }
    }
}