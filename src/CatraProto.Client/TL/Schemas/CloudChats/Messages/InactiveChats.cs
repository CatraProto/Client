using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class InactiveChats : CatraProto.Client.TL.Schemas.CloudChats.Messages.InactiveChatsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1456996667; }
        
[Newtonsoft.Json.JsonProperty("dates")]
		public sealed override IList<int> Dates { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public InactiveChats (IList<int> dates,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Dates = dates;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal InactiveChats() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Dates);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Dates = reader.ReadVector<int>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "messages.inactiveChats";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}