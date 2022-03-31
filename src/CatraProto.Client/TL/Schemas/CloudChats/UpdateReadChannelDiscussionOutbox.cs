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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1767677564; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("top_msg_id")]
		public int TopMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("read_max_id")]
		public int ReadMaxId { get; set; }


        #nullable enable
 public UpdateReadChannelDiscussionOutbox (long channelId,int topMsgId,int readMaxId)
{
 ChannelId = channelId;
TopMsgId = topMsgId;
ReadMaxId = readMaxId;
 
}
#nullable disable
        internal UpdateReadChannelDiscussionOutbox() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(TopMsgId);
			writer.Write(ReadMaxId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<long>();
			TopMsgId = reader.Read<int>();
			ReadMaxId = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateReadChannelDiscussionOutbox";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}