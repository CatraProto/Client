using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaPoll : MessageMediaBase
	{
		public static int ConstructorId { get; } = 1272375192;
		public PollBase Poll { get; set; }
		public PollResultsBase Results { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Poll);
			writer.Write(Results);
		}

		public override void Deserialize(Reader reader)
		{
			Poll = reader.Read<PollBase>();
			Results = reader.Read<PollResultsBase>();
		}
	}
}