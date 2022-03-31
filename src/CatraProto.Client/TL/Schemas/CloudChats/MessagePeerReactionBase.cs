using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessagePeerReactionBase : IObject
    {

[Newtonsoft.Json.JsonProperty("big")]
		public abstract bool Big { get; set; }

[Newtonsoft.Json.JsonProperty("unread")]
		public abstract bool Unread { get; set; }

[Newtonsoft.Json.JsonProperty("peer_id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("reaction")]
		public abstract string Reaction { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
