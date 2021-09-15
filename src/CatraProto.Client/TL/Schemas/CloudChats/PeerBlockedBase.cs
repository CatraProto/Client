using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PeerBlockedBase : IObject
    {

[Newtonsoft.Json.JsonProperty("peer_id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public abstract int Date { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
