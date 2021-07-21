using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AffectedHistory : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase
	{


        public static int StaticConstructorId { get => -1269012015; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("pts")]
		public override int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public override int PtsCount { get; set; }

[JsonPropertyName("offset")]
		public override int Offset { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Offset);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Offset = reader.Read<int>();

		}
	}
}