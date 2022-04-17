using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc;
using Newtonsoft.Json;

namespace CatraProto.Client.Connections.MessageScheduling
{
    static class MessageItemsExtensions
    {
        public static void SetToSend(this IEnumerable<MessageItem> messageItems, bool wakeUpLoop = true)
        {
            foreach (var messageItem in messageItems)
            {
                messageItem.SetToSend(wakeUpLoop: wakeUpLoop);
            }
        }
        
        public static void SetSent(this IEnumerable<MessageItem> messageItems, ExecutionInfo executionInfo, long? upperId = null, int? upperSeqno = null)
        {
            foreach (var messageItem in messageItems)
            {
                messageItem.SetSent(executionInfo, upperId, upperSeqno);
            }
        }
    }
}