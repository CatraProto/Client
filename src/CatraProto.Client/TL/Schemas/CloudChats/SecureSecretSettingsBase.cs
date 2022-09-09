using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SecureSecretSettingsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("secure_algo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase SecureAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_secret")]
        public abstract byte[] SecureSecret { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_secret_id")]
        public abstract long SecureSecretId { get; set; }

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