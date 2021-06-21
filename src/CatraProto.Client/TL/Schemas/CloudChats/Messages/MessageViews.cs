using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessageViews : MessageViewsBase
	{
		public static int ConstructorId { get; } = -1228606141;
		public override IList<CloudChats.MessageViewsBase> Views { get; set; }
		public override IList<ChatBase> Chats { get; set; }
		public override IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Views);
			writer.Write(Chats);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Views = reader.ReadVector<CloudChats.MessageViewsBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}