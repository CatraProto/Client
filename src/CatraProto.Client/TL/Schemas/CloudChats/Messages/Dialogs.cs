using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Dialogs : DialogsBase
	{


        public static int ConstructorId { get; } = 364538944;
		public IList<DialogBase> PDialogs { get; set; }
		public IList<MessageBase> Messages { get; set; }
		public IList<ChatBase> Chats { get; set; }
		public IList<UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PDialogs);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PDialogs = reader.ReadVector<DialogBase>();
			Messages = reader.ReadVector<MessageBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}