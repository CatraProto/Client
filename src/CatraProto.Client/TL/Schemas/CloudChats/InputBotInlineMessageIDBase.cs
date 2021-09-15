using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputBotInlineMessageIDBase : IObject
    {

[Newtonsoft.Json.JsonProperty("dc_id")]
		public abstract int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public abstract long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public abstract long AccessHash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
