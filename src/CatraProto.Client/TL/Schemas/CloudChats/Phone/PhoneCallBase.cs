using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public abstract class PhoneCallBase : IObject
    {

[Newtonsoft.Json.JsonProperty("phone_call")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCallField { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
