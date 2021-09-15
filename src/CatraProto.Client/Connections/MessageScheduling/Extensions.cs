using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.Items;

namespace CatraProto.Client.Connections.MessageScheduling
{
    static class MessageItemsExtensions
    {
        public static void SetToSend(this IEnumerable<MessageItem> messageItems)
        {
            foreach (var messageItem in messageItems)
            {
                messageItem.SetToSend();
            }
        }
    }
}