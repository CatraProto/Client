using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsPercentValue : CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase
	{


        public static int StaticConstructorId { get => -875679776; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("part")]
		public override double Part { get; set; }

[JsonPropertyName("total")]
		public override double Total { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Part);
			writer.Write(Total);

		}

		public override void Deserialize(Reader reader)
		{
			Part = reader.Read<double>();
			Total = reader.Read<double>();

		}
	}
}