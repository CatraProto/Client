using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class ContentSettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("sensitive_enabled")]
		public abstract bool SensitiveEnabled { get; set; }

[Newtonsoft.Json.JsonProperty("sensitive_can_change")]
		public abstract bool SensitiveCanChange { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
