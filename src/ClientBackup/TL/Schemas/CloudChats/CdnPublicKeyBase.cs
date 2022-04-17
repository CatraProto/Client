using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class CdnPublicKeyBase : IObject
    {

[Newtonsoft.Json.JsonProperty("dc_id")]
		public abstract int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("public_key")]
		public abstract string PublicKey { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
