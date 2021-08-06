using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class TopPeerCategoryPeersBase : IObject
    {

[JsonPropertyName("category")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

[JsonPropertyName("count")]
		public abstract int Count { get; set; }

[JsonPropertyName("peers")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
