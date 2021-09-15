using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerChannel : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
	{


        public static int StaticConstructorId { get => 548253432; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
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
				
		public override string ToString()
		{
		    return "inputPeerChannel";
		}
	}
}