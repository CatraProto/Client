using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class TopPeerCategoryPeersBase : IObject
    {

[Newtonsoft.Json.JsonProperty("category")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

[Newtonsoft.Json.JsonProperty("peers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
