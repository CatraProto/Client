using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantsContacts : ChannelParticipantsFilterBase
	{
		public static int ConstructorId { get; } = -1150621555;
		public string Q { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Q);
		}

		public override void Deserialize(Reader reader)
		{
			Q = reader.Read<string>();
		}
	}
}