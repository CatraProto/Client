using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantsRecent : ChannelParticipantsFilterBase
	{
		public static int ConstructorId { get; } = -566281095;

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}
		}

		public override void Deserialize(Reader reader)
		{
		}
	}
}