using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class ChatFull : ChatFullBase
    {
        public static int ConstructorId { get; } = -438840932;
        public override CloudChats.ChatFullBase FullChat { get; set; }
        public override IList<ChatBase> Chats { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(FullChat);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            FullChat = reader.Read<CloudChats.ChatFullBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}