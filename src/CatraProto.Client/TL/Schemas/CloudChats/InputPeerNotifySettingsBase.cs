using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
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

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("sound")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.NotificationSoundBase Sound { get; set; }

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
