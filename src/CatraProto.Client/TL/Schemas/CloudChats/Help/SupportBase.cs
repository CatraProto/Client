using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class SupportBase : IObject
    {

[Newtonsoft.Json.JsonProperty("phone_number")]
		public abstract string PhoneNumber { get; set; }

[Newtonsoft.Json.JsonProperty("user")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
