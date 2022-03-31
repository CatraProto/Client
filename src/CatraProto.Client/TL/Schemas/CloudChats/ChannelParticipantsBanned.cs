using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantsBanned : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 338142689; }
        
[Newtonsoft.Json.JsonProperty("q")]
		public string Q { get; set; }


        #nullable enable
 public ChannelParticipantsBanned (string q)
{
 Q = q;
 
}
#nullable disable
        internal ChannelParticipantsBanned() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Q);

		}

		public override void Deserialize(Reader reader)
		{
			Q = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "channelParticipantsBanned";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}