using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaPoll : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        public static int StaticConstructorId { get => 1272375192; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("poll")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }


        #nullable enable
 public MessageMediaPoll (CatraProto.Client.TL.Schemas.CloudChats.PollBase poll,CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase results)
{
 Poll = poll;
Results = results;
 
}
#nullable disable
        internal MessageMediaPoll() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Poll);
			writer.Write(Results);

		}

		public override void Deserialize(Reader reader)
		{
			Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
			Results = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();

		}
				
		public override string ToString()
		{
		    return "messageMediaPoll";
		}
	}
}