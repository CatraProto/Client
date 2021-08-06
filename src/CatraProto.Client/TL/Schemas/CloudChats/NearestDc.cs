using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class NearestDc : CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase
	{


        public static int StaticConstructorId { get => -1910892683; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("country")]
		public override string Country { get; set; }

[JsonPropertyName("this_dc")]
		public override int ThisDc { get; set; }

[JsonPropertyName("NearestDc_")]
		public override int NearestDc_ { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Country);
			writer.Write(ThisDc);
			writer.Write(NearestDc_);

		}

		public override void Deserialize(Reader reader)
		{
			Country = reader.Read<string>();
			ThisDc = reader.Read<int>();
			NearestDc_ = reader.Read<int>();

		}
	}
}