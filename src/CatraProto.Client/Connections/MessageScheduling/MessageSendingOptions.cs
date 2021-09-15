using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;

namespace CatraProto.Client.Connections.MessageScheduling
{
    public class MessageSendingOptions
    {
        public AwaiterType AwaiterType { get; }
        public long? SendWithMessageId { get; }
        public bool IsEncrypted { get; }
        internal AuthKey? SendWithAuthKey { get; }

        public MessageSendingOptions(bool isEncrypted, long? sendWithMessageId = null, AwaiterType awaiterType = AwaiterType.OnResponse)
        {
            IsEncrypted = isEncrypted;
            SendWithMessageId = sendWithMessageId;
            AwaiterType = awaiterType;
        }

        internal MessageSendingOptions(bool isEncrypted, AuthKey? sendWithAuthKey, long? sendWithMessageId = null,
            AwaiterType awaiterType = AwaiterType.OnResponse) : this(isEncrypted, sendWithMessageId, awaiterType)
        {
            SendWithAuthKey = sendWithAuthKey;
        }
    }
}