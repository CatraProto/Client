using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class Found : CatraProto.Client.TL.Schemas.CloudChats.Contacts.FoundBase
	{


        public static int StaticConstructorId { get => -1290580579; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("my_results")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }

[JsonPropertyName("results")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }

[JsonPropertyName("chats")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
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