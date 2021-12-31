using CatraProto.TL;
using System.Collections.Generic;
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
		public abstract IList<byte[]> LogoutTokens { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
