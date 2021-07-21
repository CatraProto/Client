using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AffectedMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedMessagesBase
	{


        public static int StaticConstructorId { get => -2066640507; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("pts")]
		public override int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public override int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
	}
}