using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerChannel : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1566230754; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }


        #nullable enable
 public PeerChannel (long channelId)
{
 ChannelId = channelId;
 
}
#nullable disable
        internal PeerChannel() 
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
		    return "peerChannel";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}