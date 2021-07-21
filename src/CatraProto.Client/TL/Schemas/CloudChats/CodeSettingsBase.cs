using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class CodeSettingsBase : IObject
    {

[JsonPropertyName("allow_flashcall")]
		public abstract bool AllowFlashcall { get; set; }

[JsonPropertyName("current_number")]
		public abstract bool CurrentNumber { get; set; }

[JsonPropertyName("allow_app_hash")]
		public abstract bool AllowAppHash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
