using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaPoll : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        public static int StaticConstructorId { get => 1272375192; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("poll")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

[JsonPropertyName("results")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase Results { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Poll);
			writer.Write(Results);

		}

		public override void Deserialize(Reader reader)
		{
			Poll = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
			Results = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase>();

		}
	}
}