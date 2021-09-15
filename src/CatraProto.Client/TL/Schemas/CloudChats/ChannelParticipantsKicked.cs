using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantsKicked : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
	{


        public static int StaticConstructorId { get => -1548400251; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("q")]
		public string Q { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Q);

		}

		public override void Deserialize(Reader reader)
		{
			Q = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "channelParticipantsKicked";
		}
	}
}