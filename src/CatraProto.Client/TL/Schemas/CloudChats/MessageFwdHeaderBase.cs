using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MessageFwdHeaderBase : IObject
    {
		public abstract bool Imported { get; set; }
		public abstract PeerBase FromId { get; set; }
		public abstract string FromName { get; set; }
		public abstract int Date { get; set; }
		public abstract int? ChannelPost { get; set; }
		public abstract string PostAuthor { get; set; }
		public abstract PeerBase SavedFromPeer { get; set; }
		public abstract int? SavedFromMsgId { get; set; }
		public abstract string PsaType { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
