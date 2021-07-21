using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputContactBase : IObject
    {

[JsonPropertyName("client_id")]
		public abstract long ClientId { get; set; }

[JsonPropertyName("phone")]
		public abstract string Phone { get; set; }

[JsonPropertyName("first_name")]
		public abstract string FirstName { get; set; }

[JsonPropertyName("last_name")]
		public abstract string LastName { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
