using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class TopPeer : TopPeerBase
	{
		public static int ConstructorId { get; } = -305282981;
		public override PeerBase Peer { get; set; }
		public override double Rating { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Peer);
			writer.Write(Rating);
		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<PeerBase>();
			Rating = reader.Read<double>();
		}
	}
}