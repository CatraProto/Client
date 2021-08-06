using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputPeerNotifySettingsBase : IObject
    {

[JsonPropertyName("show_previews")]
		public abstract bool? ShowPreviews { get; set; }

[JsonPropertyName("silent")]
		public abstract bool? Silent { get; set; }

[JsonPropertyName("mute_until")]
		public abstract int? MuteUntil { get; set; }

[JsonPropertyName("sound")]
		public abstract string Sound { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
