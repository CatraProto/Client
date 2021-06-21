using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessageViews : MessageViewsBase
	{


        public static int ConstructorId { get; } = -1228606141;
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase> Views { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Views);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Views = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}