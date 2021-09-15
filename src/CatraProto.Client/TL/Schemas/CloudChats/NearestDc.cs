using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class NearestDc : CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase
	{


        public static int StaticConstructorId { get => -1910892683; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("country")]
		public override string Country { get; set; }

[Newtonsoft.Json.JsonProperty("this_dc")]
		public override int ThisDc { get; set; }

[Newtonsoft.Json.JsonProperty("nearest_dc")]
		public override int NearestDcField { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Country);
			writer.Write(ThisDc);
			writer.Write(NearestDcField);

		}

		public override void Deserialize(Reader reader)
		{
			Country = reader.Read<string>();
			ThisDc = reader.Read<int>();
			NearestDcField = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "nearestDc";
		}
	}
}