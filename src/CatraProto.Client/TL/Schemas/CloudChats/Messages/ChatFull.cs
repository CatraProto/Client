using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatFull : ChatFullBase
	{


        public static int ConstructorId { get; } = -438840932;
		public override CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase FullChat { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(FullChat);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			FullChat = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}