using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ImportedContactBase : IObject
    {

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("client_id")]
		public abstract long ClientId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
