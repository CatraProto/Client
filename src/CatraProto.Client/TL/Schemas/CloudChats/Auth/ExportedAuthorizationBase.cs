using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class ExportedAuthorizationBase : IObject
    {

[JsonPropertyName("id")]
		public abstract int Id { get; set; }

[JsonPropertyName("bytes")]
		public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
