using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannel : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 1666927625; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }


        #nullable enable
 public UpdateChannel (long channelId)
{
 ChannelId = channelId;
 
}
#nullable disable
        internal UpdateChannel() 
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
		    return "updateChannel";
		}
	}
}