using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ChatsSlice : ChatsBase
    {
        public static int ConstructorId { get; } = -1663561404;
        public int Count { get; set; }
        public override IList<ChatBase> Chats_ { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Count);
            writer.Write(Chats_);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Chats_ = reader.ReadVector<ChatBase>();
        }
    }
}