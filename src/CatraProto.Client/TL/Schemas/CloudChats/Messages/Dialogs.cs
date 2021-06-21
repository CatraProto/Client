using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Dialogs : DialogsBase
	{
		public static int ConstructorId { get; } = 364538944;
		public IList<DialogBase> Dialogs_ { get; set; }
		public IList<MessageBase> Messages { get; set; }
		public IList<ChatBase> Chats { get; set; }
		public IList<UserBase> Users { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Dialogs_);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);
		}

		public override void Deserialize(Reader reader)
		{
			Dialogs_ = reader.ReadVector<DialogBase>();
			Messages = reader.ReadVector<MessageBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}
	}
}