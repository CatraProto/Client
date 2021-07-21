using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageFwdHeaderBase : IObject
    {

[JsonPropertyName("imported")]
		public abstract bool Imported { get; set; }

[JsonPropertyName("from_id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[JsonPropertyName("from_name")]
		public abstract string FromName { get; set; }

[JsonPropertyName("date")]
		public abstract int Date { get; set; }

[JsonPropertyName("channel_post")]
		public abstract int? ChannelPost { get; set; }

[JsonPropertyName("post_author")]
		public abstract string PostAuthor { get; set; }

[JsonPropertyName("saved_from_peer")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase SavedFromPeer { get; set; }

[JsonPropertyName("saved_from_msg_id")]
		public abstract int? SavedFromMsgId { get; set; }

[JsonPropertyName("psa_type")]
		public abstract string PsaType { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
