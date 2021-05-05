using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PeerSettingsBase : IObject
    {
		public abstract bool ReportSpam { get; set; }
		public abstract bool AddContact { get; set; }
		public abstract bool BlockContact { get; set; }
		public abstract bool ShareContact { get; set; }
		public abstract bool NeedContactsException { get; set; }
		public abstract bool ReportGeo { get; set; }
		public abstract bool Autoarchived { get; set; }
		public abstract bool InviteMembers { get; set; }
		public abstract int? GeoDistance { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
