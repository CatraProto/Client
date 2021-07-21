using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class CdnPublicKeyBase : IObject
    {

[JsonPropertyName("dc_id")]
		public abstract int DcId { get; set; }

[JsonPropertyName("public_key")]
		public abstract string PublicKey { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
