using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GlobalPrivacySettingsBase : IObject
    {

[JsonPropertyName("archive_and_mute_new_noncontact_peers")]
		public abstract bool? ArchiveAndMuteNewNoncontactPeers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
