using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordSettingsBase : IObject
    {
        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public abstract string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("secure_settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase SecureSettings { get; set; }

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