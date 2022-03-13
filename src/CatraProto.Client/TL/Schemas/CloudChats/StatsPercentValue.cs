using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsPercentValue : CatraProto.Client.TL.Schemas.CloudChats.StatsPercentValueBase
	{


        public static int StaticConstructorId { get => -875679776; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("part")]
		public sealed override double Part { get; set; }

[Newtonsoft.Json.JsonProperty("total")]
		public sealed override double Total { get; set; }


        #nullable enable
 public StatsPercentValue (double part,double total)
{
 Part = part;
Total = total;
 
}
#nullable disable
        internal StatsPercentValue() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Part);
			writer.Write(Total);

		}

		public override void Deserialize(Reader reader)
		{
			Part = reader.Read<double>();
			Total = reader.Read<double>();

		}
				
		public override string ToString()
		{
		    return "statsPercentValue";
		}
	}
}