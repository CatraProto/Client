using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputPeerNotifySettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("show_previews")]
		public abstract bool? ShowPreviews { get; set; }

[Newtonsoft.Json.JsonProperty("silent")]
		public abstract bool? Silent { get; set; }

[Newtonsoft.Json.JsonProperty("mute_until")]
		public abstract int? MuteUntil { get; set; }

[Newtonsoft.Json.JsonProperty("sound")]
		public abstract string Sound { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
