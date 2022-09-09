using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSecureValueBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("type")] public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("data")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("front_side")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase FrontSide { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reverse_side")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase ReverseSide { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("selfie")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase Selfie { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("translation")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase> Translation { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("files")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.InputSecureFileBase> Files { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("plain_data")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}