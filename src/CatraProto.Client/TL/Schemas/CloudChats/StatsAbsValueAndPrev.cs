using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StatsAbsValueAndPrev : CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase
	{


        public static int StaticConstructorId { get => -884757282; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("current")]
		public override double Current { get; set; }

[Newtonsoft.Json.JsonProperty("previous")]
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
				
		public override string ToString()
		{
		    return "statsAbsValueAndPrev";
		}
	}
}