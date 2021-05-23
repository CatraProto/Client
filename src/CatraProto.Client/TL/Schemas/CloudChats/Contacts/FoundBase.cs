using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class FoundBase : IObject
    {
		public abstract IList<PeerBase> MyResults { get; set; }
		public abstract IList<PeerBase> Results { get; set; }
		public abstract IList<ChatBase> Chats { get; set; }
		public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
