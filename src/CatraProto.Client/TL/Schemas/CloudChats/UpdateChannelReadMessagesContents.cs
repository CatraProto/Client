using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelReadMessagesContents : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1153291573; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public IList<int> Messages { get; set; }


        #nullable enable
 public UpdateChannelReadMessagesContents (long channelId,IList<int> messages)
{
 ChannelId = channelId;
Messages = messages;
 
}
#nullable disable
        internal UpdateChannelReadMessagesContents() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Messages);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<long>();
			Messages = reader.ReadVector<int>();

		}
		
		public override string ToString()
		{
		    return "updateChannelReadMessagesContents";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}