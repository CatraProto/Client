using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GlobalPrivacySettingsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("archive_and_mute_new_noncontact_peers")]
        public abstract bool? ArchiveAndMuteNewNoncontactPeers { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
