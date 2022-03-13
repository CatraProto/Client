using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PostAddress : CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase
	{


        public static int StaticConstructorId { get => 512535275; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("street_line1")]
		public sealed override string StreetLine1 { get; set; }

[Newtonsoft.Json.JsonProperty("street_line2")]
		public sealed override string StreetLine2 { get; set; }

[Newtonsoft.Json.JsonProperty("city")]
		public sealed override string City { get; set; }

[Newtonsoft.Json.JsonProperty("state")]
		public sealed override string State { get; set; }

[Newtonsoft.Json.JsonProperty("country_iso2")]
		public sealed override string CountryIso2 { get; set; }

[Newtonsoft.Json.JsonProperty("post_code")]
		public sealed override string PostCode { get; set; }


        #nullable enable
 public PostAddress (string streetLine1,string streetLine2,string city,string state,string countryIso2,string postCode)
{
 StreetLine1 = streetLine1;
StreetLine2 = streetLine2;
City = city;
State = state;
CountryIso2 = countryIso2;
PostCode = postCode;
 
}
#nullable disable
        internal PostAddress() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
				
		public override string ToString()
		{
		    return "postAddress";
		}
	}
}