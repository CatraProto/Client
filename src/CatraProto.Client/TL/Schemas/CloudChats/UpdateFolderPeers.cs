using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateFolderPeers : UpdateBase
	{
		public static int ConstructorId { get; } = 422972864;
		public IList<FolderPeerBase> FolderPeers { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FolderPeers);
			writer.Write(Pts);
			writer.Write(PtsCount);
		}

		public override void Deserialize(Reader reader)
		{
			FolderPeers = reader.ReadVector<FolderPeerBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
		}
	}
}