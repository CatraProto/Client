using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PopularContactBase : IObject
    {

[JsonPropertyName("client_id")]
		public abstract long ClientId { get; set; }

[JsonPropertyName("importers")]
		public abstract int Importers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
