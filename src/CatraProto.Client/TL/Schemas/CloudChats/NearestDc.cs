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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1910892683; }
        
[Newtonsoft.Json.JsonProperty("country")]
		public sealed override string Country { get; set; }

[Newtonsoft.Json.JsonProperty("this_dc")]
		public sealed override int ThisDc { get; set; }

[Newtonsoft.Json.JsonProperty("nearest_dc")]
		public sealed override int NearestDcField { get; set; }


        #nullable enable
 public NearestDc (string country,int thisDc,int nearestDcField)
{
 Country = country;
ThisDc = thisDc;
NearestDcField = nearestDcField;
 
}
#nullable disable
        internal NearestDc() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}