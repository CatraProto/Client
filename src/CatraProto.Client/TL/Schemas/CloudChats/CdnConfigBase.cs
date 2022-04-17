using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class CdnConfigBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("public_keys")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.CdnPublicKeyBase> PublicKeys { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
