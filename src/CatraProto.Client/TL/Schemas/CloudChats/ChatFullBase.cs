using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatFullBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public abstract string About { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public abstract int? FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
