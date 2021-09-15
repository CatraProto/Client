using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadChannelDiscussionOutbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 1178116716; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("top_msg_id")]
		public int TopMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("read_max_id")]
		public int ReadMaxId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(TopMsgId);
			writer.Write(ReadMaxId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			TopMsgId = reader.Read<int>();
			ReadMaxId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateReadChannelDiscussionOutbox";
		}
	}
}