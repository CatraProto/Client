using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebPageAttributeBase : IObject
    {

[Newtonsoft.Json.JsonProperty("documents")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
