using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;

namespace CatraProto.Client.Connections.MessageScheduling
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