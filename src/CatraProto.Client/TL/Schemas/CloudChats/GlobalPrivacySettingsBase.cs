using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GlobalPrivacySettingsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("archive_and_mute_new_noncontact_peers")]
		public abstract bool? ArchiveAndMuteNewNoncontactPeers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
