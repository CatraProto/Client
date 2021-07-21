using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PostAddress : CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase
	{


        public static int StaticConstructorId { get => 512535275; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("street_line1")]
		public override string StreetLine1 { get; set; }

[JsonPropertyName("street_line2")]
		public override string StreetLine2 { get; set; }

[JsonPropertyName("city")]
		public override string City { get; set; }

[JsonPropertyName("state")]
		public override string State { get; set; }

[JsonPropertyName("country_iso2")]
		public override string CountryIso2 { get; set; }

[JsonPropertyName("post_code")]
		public override string PostCode { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(StreetLine1);
			writer.Write(StreetLine2);
			writer.Write(City);
			writer.Write(State);
			writer.Write(CountryIso2);
			writer.Write(PostCode);

		}

		public override void Deserialize(Reader reader)
		{
			StreetLine1 = reader.Read<string>();
			StreetLine2 = reader.Read<string>();
			City = reader.Read<string>();
			State = reader.Read<string>();
			CountryIso2 = reader.Read<string>();
			PostCode = reader.Read<string>();

		}
	}
}