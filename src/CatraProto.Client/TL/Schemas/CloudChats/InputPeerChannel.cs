using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerChannel : InputPeerBase
	{
		public static int ConstructorId { get; } = 548253432;
		public int ChannelId { get; set; }
		public long AccessHash { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(ChannelId);
			writer.Write(AccessHash);
		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			AccessHash = reader.Read<long>();
		}
	}
}