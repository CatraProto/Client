using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class PeerDialogs : PeerDialogsBase
	{


        public static int ConstructorId { get; } = 863093588;
		public override IList<DialogBase> Dialogs { get; set; }
		public override IList<MessageBase> Messages { get; set; }
		public override IList<ChatBase> Chats { get; set; }
		public override IList<UserBase> Users { get; set; }
		public override StateBase State { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Dialogs);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);
			writer.Write(State);

		}

		public override void Deserialize(Reader reader)
		{
			Dialogs = reader.ReadVector<DialogBase>();
			Messages = reader.ReadVector<MessageBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
			State = reader.Read<StateBase>();

		}
	}
}