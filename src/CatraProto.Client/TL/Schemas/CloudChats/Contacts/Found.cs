using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class Found : FoundBase
	{


        public static int ConstructorId { get; } = -1290580579;
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MyResults);
			writer.Write(Results);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			MyResults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Results = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}