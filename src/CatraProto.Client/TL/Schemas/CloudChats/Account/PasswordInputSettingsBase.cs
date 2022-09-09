using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class PasswordInputSettingsBase : IObject
    {
        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_algo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase NewAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("new_password_hash")]
        public abstract byte[] NewPasswordHash { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("hint")]
        public abstract string Hint { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public abstract string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_secure_settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase NewSecureSettings { get; set; }

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