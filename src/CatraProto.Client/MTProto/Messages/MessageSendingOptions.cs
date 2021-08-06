using System;
using CatraProto.Client.Connections.MessageScheduling.Enums;

namespace CatraProto.Client.MTProto.Messages
{
    public class MessageSendingOptions
    {
        public AwaiterType AwaiterType { get; }
        public long? SendWithMessageId { get; }
        public bool IsEncrypted { get; }
        
        public MessageSendingOptions(bool isEncrypted, long? sendWithMessageId = null, AwaiterType awaiterType = AwaiterType.OnResponse)
        {
            IsEncrypted = isEncrypted;
            SendWithMessageId = sendWithMessageId;
            AwaiterType = awaiterType;
        }
    }
}