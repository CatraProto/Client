using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class TopPeers : TopPeersBase
	{


        public static int StaticConstructorId { get => 1891070632; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("categories")]
		public IList<TopPeerCategoryPeersBase> Categories { get; set; }

[JsonPropertyName("chats")]
		public IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public IList<UserBase> Users { get; set; }

        
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
			Categories = reader.ReadVector<TopPeerCategoryPeersBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
		}

		public override string ToString()
		{
			return "contacts.topPeers";
		}
	}
}