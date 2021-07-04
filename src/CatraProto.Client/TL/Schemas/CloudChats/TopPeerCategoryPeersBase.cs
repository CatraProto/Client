using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class TopPeerCategoryPeersBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }
		public abstract int Count { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
