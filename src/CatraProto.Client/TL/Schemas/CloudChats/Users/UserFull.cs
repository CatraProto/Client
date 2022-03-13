using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class UserFull : CatraProto.Client.TL.Schemas.CloudChats.Users.UserFullBase
	{


        public static int StaticConstructorId { get => 997004590; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("full_user")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.UserFullBase FullUser { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public UserFull (CatraProto.Client.TL.Schemas.CloudChats.UserFullBase fullUser,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 FullUser = fullUser;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal UserFull() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(FullUser);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			FullUser = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UserFullBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "users.userFull";
		}
	}
}