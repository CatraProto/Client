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


        public static int StaticConstructorId { get => 995769920; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public override int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("action")]
		public override CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase Action { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Date);
			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Date = reader.Read<int>();
			UserId = reader.Read<int>();
			Action = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEvent";
		}
	}
}