using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class TopPeers : TopPeersBase
	{


        public static int ConstructorId { get; } = 1891070632;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase> Categories { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Categories);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Categories = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}