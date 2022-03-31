using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputContactBase : IObject
    {

[Newtonsoft.Json.JsonProperty("client_id")]
		public abstract long ClientId { get; set; }

[Newtonsoft.Json.JsonProperty("phone")]
		public abstract string Phone { get; set; }

[Newtonsoft.Json.JsonProperty("first_name")]
		public abstract string FirstName { get; set; }

[Newtonsoft.Json.JsonProperty("last_name")]
		public abstract string LastName { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
