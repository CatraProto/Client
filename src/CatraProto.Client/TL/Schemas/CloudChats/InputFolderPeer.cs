using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFolderPeer : InputFolderPeerBase
	{
		public static int ConstructorId { get; } = -70073706;
		public override InputPeerBase Peer { get; set; }
		public override int FolderId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(FolderId);
		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			FolderId = reader.Read<int>();
		}
	}
}