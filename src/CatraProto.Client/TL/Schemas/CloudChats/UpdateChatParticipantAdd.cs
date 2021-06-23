using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChatParticipantAdd : UpdateBase
	{
		public static int ConstructorId { get; } = -364179876;
		public int ChatId { get; set; }
		public int UserId { get; set; }
		public int InviterId { get; set; }
		public int Date { get; set; }
		public int Version { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(ChatId);
			writer.Write(UserId);
			writer.Write(InviterId);
			writer.Write(Date);
			writer.Write(Version);
		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<int>();
			UserId = reader.Read<int>();
			InviterId = reader.Read<int>();
			Date = reader.Read<int>();
			Version = reader.Read<int>();
		}
	}
}