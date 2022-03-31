using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantsSearch : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 106343499; }
        
[Newtonsoft.Json.JsonProperty("q")]
		public string Q { get; set; }


        #nullable enable
 public ChannelParticipantsSearch (string q)
{
 Q = q;
 
}
#nullable disable
        internal ChannelParticipantsSearch() 
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
		    return "channelParticipantsSearch";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}