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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 666680316; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }


        #nullable enable
 public InputPeerChannel (long channelId,long accessHash)
{
 ChannelId = channelId;
AccessHash = accessHash;
 
}
#nullable disable
        internal InputPeerChannel() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<long>();
			AccessHash = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "inputPeerChannel";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}