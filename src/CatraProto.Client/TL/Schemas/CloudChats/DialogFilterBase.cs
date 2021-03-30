using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterBase : IObject
    {
		public abstract bool Contacts { get; set; }
		public abstract bool NonContacts { get; set; }
		public abstract bool Groups { get; set; }
		public abstract bool Broadcasts { get; set; }
		public abstract bool Bots { get; set; }
		public abstract bool ExcludeMuted { get; set; }
		public abstract bool ExcludeRead { get; set; }
		public abstract bool ExcludeArchived { get; set; }
		public abstract int Id { get; set; }
		public abstract string Title { get; set; }
		public abstract string Emoticon { get; set; }
		public abstract IList<InputPeerBase> PinnedPeers { get; set; }
		public abstract IList<InputPeerBase> IncludePeers { get; set; }
		public abstract IList<InputPeerBase> ExcludePeers { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
