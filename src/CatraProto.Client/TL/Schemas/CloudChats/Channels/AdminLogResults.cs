using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class AdminLogResults : CatraProto.Client.TL.Schemas.CloudChats.Channels.AdminLogResultsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -309659827; }
        
[Newtonsoft.Json.JsonProperty("events")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> Events { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public AdminLogResults (IList<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase> events,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Events = events;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal AdminLogResults() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Events);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Events = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "channels.adminLogResults";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}