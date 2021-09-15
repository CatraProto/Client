using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PopularContactBase : IObject
    {

[Newtonsoft.Json.JsonProperty("client_id")]
		public abstract long ClientId { get; set; }

[Newtonsoft.Json.JsonProperty("importers")]
		public abstract int Importers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
