using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class SentCodeBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("type")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public abstract string PhoneCodeHash { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("next_type")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase NextType { get; set; }

        [Newtonsoft.Json.JsonProperty("timeout")]
        public abstract int? Timeout { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
