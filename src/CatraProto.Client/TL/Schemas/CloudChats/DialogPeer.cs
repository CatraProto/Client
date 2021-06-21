using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogPeer : DialogPeerBase
	{
		public static int ConstructorId { get; } = -445792507;
		public PeerBase Peer { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
		}
	}
}