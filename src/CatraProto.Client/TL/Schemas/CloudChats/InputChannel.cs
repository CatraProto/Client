using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChannel : CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase
	{


        public static int StaticConstructorId { get => -1343524562; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("access_hash")]
		public long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			AccessHash = reader.Read<long>();

		}
	}
}