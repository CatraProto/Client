using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PrivacyValueDisallowChatParticipants : PrivacyRuleBase
    {
        public static int ConstructorId { get; } = -1397881200;
        public IList<int> Chats { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Chats);
        }

        public override void Deserialize(Reader reader)
        {
            Chats = reader.ReadVector<int>();
        }
    }
}