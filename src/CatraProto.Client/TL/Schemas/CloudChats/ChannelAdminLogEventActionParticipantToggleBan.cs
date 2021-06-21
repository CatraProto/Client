using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = -422036098;
		public ChannelParticipantBase PrevParticipant { get; set; }
		public ChannelParticipantBase NewParticipant { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevParticipant);
			writer.Write(NewParticipant);
		}

		public override void Deserialize(Reader reader)
		{
			PrevParticipant = reader.Read<ChannelParticipantBase>();
			NewParticipant = reader.Read<ChannelParticipantBase>();
		}
	}
}