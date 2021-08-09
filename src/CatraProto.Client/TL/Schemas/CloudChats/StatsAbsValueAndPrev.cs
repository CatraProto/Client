using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsAbsValueAndPrev : CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase
	{


        public static int StaticConstructorId { get => -884757282; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("current")]
		public override double Current { get; set; }

[JsonPropertyName("previous")]
		public override double Previous { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Current);
			writer.Write(Previous);

		}

		public override void Deserialize(Reader reader)
		{
			Current = reader.Read<double>();
			Previous = reader.Read<double>();

		}
	}
}