using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SponsoredMessageBase : IObject
    {

[Newtonsoft.Json.JsonProperty("random_id")]
		public abstract byte[] RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("from_id")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[Newtonsoft.Json.JsonProperty("channel_post")]
		public abstract int? ChannelPost { get; set; }

[Newtonsoft.Json.JsonProperty("start_param")]
		public abstract string StartParam { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public abstract string Message { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
