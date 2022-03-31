using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class Found : CatraProto.Client.TL.Schemas.CloudChats.Contacts.FoundBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1290580579; }
        
[Newtonsoft.Json.JsonProperty("my_results")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public Found (IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> myResults,IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> results,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 MyResults = myResults;
Results = results;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal Found() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "contacts.found";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}