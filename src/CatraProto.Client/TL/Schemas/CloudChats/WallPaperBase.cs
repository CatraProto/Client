using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WallPaperBase : IObject
    {

[JsonPropertyName("default")]
		public abstract bool Default { get; set; }

[JsonPropertyName("dark")]
		public abstract bool Dark { get; set; }

[JsonPropertyName("settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
