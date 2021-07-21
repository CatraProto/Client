using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class ContentSettingsBase : IObject
    {

[JsonPropertyName("sensitive_enabled")]
		public abstract bool SensitiveEnabled { get; set; }

[JsonPropertyName("sensitive_can_change")]
		public abstract bool SensitiveCanChange { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
