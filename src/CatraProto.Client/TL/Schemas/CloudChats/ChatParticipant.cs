using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatParticipant : ChatParticipantBase
	{
		public static int ConstructorId { get; } = -925415106;
		public override int UserId { get; set; }
		public int InviterId { get; set; }
		public int Date { get; set; }

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
			writer.Write(InviterId);
			writer.Write(Date);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			InviterId = reader.Read<int>();
			Date = reader.Read<int>();
		}
	}
}