using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ContactStatusBase : IObject
    {

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("status")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
