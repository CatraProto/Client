using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class Chats : ChatsBase
    {
        public static int ConstructorId { get; } = 1694474197;
        public override IList<ChatBase> Chats_ { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Chats_);
        }

        public override void Deserialize(Reader reader)
        {
            Chats_ = reader.ReadVector<ChatBase>();
        }
    }
}