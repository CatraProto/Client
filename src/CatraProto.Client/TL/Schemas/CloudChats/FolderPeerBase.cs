using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FolderPeerBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public abstract int FolderId { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
