using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PostAddressBase : IObject
    {

[JsonPropertyName("street_line1")]
		public abstract string StreetLine1 { get; set; }

[JsonPropertyName("street_line2")]
		public abstract string StreetLine2 { get; set; }

[JsonPropertyName("city")]
		public abstract string City { get; set; }

[JsonPropertyName("state")]
		public abstract string State { get; set; }

[JsonPropertyName("country_iso2")]
		public abstract string CountryIso2 { get; set; }

[JsonPropertyName("post_code")]
		public abstract string PostCode { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
