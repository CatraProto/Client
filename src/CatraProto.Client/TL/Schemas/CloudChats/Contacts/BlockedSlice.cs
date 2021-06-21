using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class BlockedSlice : BlockedBase
    {
        public static int ConstructorId { get; } = -513392236;
        public int Count { get; set; }
        public override IList<PeerBlockedBase> Blocked_ { get; set; }
        public override IList<ChatBase> Chats { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Count);
            writer.Write(Blocked_);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Blocked_ = reader.ReadVector<PeerBlockedBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}