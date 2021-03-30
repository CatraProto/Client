using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FolderPeer : FolderPeerBase
	{


        public static int ConstructorId { get; } = -373643672;
		public override PeerBase Peer { get; set; }
		public override int FolderId { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(FolderId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			FolderId = reader.Read<int>();

		}
	}
}