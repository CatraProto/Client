using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlChatInvite : RecentMeUrlBase
	{
		public static int ConstructorId { get; } = -347535331;
		public override string Url { get; set; }
		public ChatInviteBase ChatInvite { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(ChatInvite);
		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			ChatInvite = reader.Read<ChatInviteBase>();
		}
	}
}