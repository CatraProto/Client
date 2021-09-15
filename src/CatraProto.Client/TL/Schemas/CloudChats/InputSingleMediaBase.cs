using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSingleMediaBase : IObject
    {

[Newtonsoft.Json.JsonProperty("media")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public abstract long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public abstract string Message { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
