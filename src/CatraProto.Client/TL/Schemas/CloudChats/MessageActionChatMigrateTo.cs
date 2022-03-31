using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatMigrateTo : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -519864430; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }


        #nullable enable
 public MessageActionChatMigrateTo (long channelId)
{
 ChannelId = channelId;
 
}
#nullable disable
        internal MessageActionChatMigrateTo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChannelId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messageActionChatMigrateTo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}