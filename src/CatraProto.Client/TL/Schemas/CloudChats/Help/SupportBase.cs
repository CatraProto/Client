using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class SupportBase : IObject
    {

[JsonPropertyName("phone_number")]
		public abstract string PhoneNumber { get; set; }

[JsonPropertyName("user")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
