using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEvent : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventBase
	{


        public static int StaticConstructorId { get => 531458253; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase Action { get; set; }


        #nullable enable
 public ChannelAdminLogEvent (long id,int date,long userId,CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase action)
{
 Id = id;
Date = date;
UserId = userId;
Action = action;
 
}
#nullable disable
        internal ChannelAdminLogEvent() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Date);
			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Date = reader.Read<int>();
			UserId = reader.Read<long>();
			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEvent";
		}
	}
}