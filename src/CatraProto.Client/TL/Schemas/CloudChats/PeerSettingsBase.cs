using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PeerSettingsBase : IObject
    {

[JsonPropertyName("report_spam")]
		public abstract bool ReportSpam { get; set; }

[JsonPropertyName("add_contact")]
		public abstract bool AddContact { get; set; }

[JsonPropertyName("block_contact")]
		public abstract bool BlockContact { get; set; }

[JsonPropertyName("share_contact")]
		public abstract bool ShareContact { get; set; }

[JsonPropertyName("need_contacts_exception")]
		public abstract bool NeedContactsException { get; set; }

[JsonPropertyName("report_geo")]
		public abstract bool ReportGeo { get; set; }

[JsonPropertyName("autoarchived")]
		public abstract bool Autoarchived { get; set; }

[JsonPropertyName("invite_members")]
		public abstract bool InviteMembers { get; set; }

[JsonPropertyName("geo_distance")]
		public abstract int? GeoDistance { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
