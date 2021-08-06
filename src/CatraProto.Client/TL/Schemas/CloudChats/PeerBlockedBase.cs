using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PeerBlockedBase : IObject
    {

[JsonPropertyName("peer_id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
