using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class CodeSettingsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("allow_flashcall")]
        public abstract bool AllowFlashcall { get; set; }

        [Newtonsoft.Json.JsonProperty("current_number")]
        public abstract bool CurrentNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("allow_app_hash")]
        public abstract bool AllowAppHash { get; set; }

        [Newtonsoft.Json.JsonProperty("allow_missed_call")]
        public abstract bool AllowMissedCall { get; set; }

        [Newtonsoft.Json.JsonProperty("logout_tokens")]
        public abstract List<byte[]> LogoutTokens { get; set; }

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