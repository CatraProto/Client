using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogBase : IObject
    {

[Newtonsoft.Json.JsonProperty("pinned")]
		public abstract bool Pinned { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("top_message")]
		public abstract int TopMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
