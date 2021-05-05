using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class TopPeers : TopPeersBase
    {
        public static int ConstructorId { get; } = 1891070632;
        public IList<TopPeerCategoryPeersBase> Categories { get; set; }
        public IList<ChatBase> Chats { get; set; }
        public IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Categories);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Categories = reader.ReadVector<TopPeerCategoryPeersBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}