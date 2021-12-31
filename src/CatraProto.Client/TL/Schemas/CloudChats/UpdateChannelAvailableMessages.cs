using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelAvailableMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1304443240; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("available_min_id")]
		public int AvailableMinId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(AvailableMinId);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<long>();
			AvailableMinId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateChannelAvailableMessages";
		}
	}
}