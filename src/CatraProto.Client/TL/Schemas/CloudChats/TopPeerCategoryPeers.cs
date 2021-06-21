using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeerCategoryPeers : TopPeerCategoryPeersBase
	{
		public static int ConstructorId { get; } = -75283823;
		public override TopPeerCategoryBase Category { get; set; }
		public override int Count { get; set; }
		public override IList<TopPeerBase> Peers { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Category);
			writer.Write(Count);
			writer.Write(Peers);
		}

		public override void Deserialize(Reader reader)
		{
			Category = reader.Read<TopPeerCategoryBase>();
			Count = reader.Read<int>();
			Peers = reader.ReadVector<TopPeerBase>();
		}
	}
}