using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class TopPeers : CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase
	{


        public static int StaticConstructorId { get => 1891070632; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("categories")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase> Categories { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public TopPeers (IList<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase> categories,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Categories = categories;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal TopPeers() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
				
		public override string ToString()
		{
		    return "contacts.topPeers";
		}
	}
}