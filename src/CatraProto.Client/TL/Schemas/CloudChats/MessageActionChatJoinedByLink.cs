using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatJoinedByLink : MessageActionBase
	{
		public static int ConstructorId { get; } = -123931160;
		public int InviterId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(InviterId);
		}

		public override void Deserialize(Reader reader)
		{
			InviterId = reader.Read<int>();
		}
	}
}