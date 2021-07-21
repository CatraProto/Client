using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WallPaperSettingsBase : IObject
    {

[JsonPropertyName("blur")]
		public abstract bool Blur { get; set; }

[JsonPropertyName("motion")]
		public abstract bool Motion { get; set; }

[JsonPropertyName("background_color")]
		public abstract int? BackgroundColor { get; set; }

[JsonPropertyName("second_background_color")]
		public abstract int? SecondBackgroundColor { get; set; }

[JsonPropertyName("intensity")]
		public abstract int? Intensity { get; set; }

[JsonPropertyName("rotation")]
		public abstract int? Rotation { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
