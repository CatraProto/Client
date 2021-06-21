using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventActionBase
	{
		public static int ConstructorId { get; } = -484690728;
		public ChannelParticipantBase Participant { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participant);
		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<ChannelParticipantBase>();
		}
	}
}