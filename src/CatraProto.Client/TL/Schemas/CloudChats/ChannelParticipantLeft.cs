using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantLeft : ChannelParticipantBase
	{
		public static int ConstructorId { get; } = -1010402965;
		public override int UserId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(UserId);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
		}
	}
}