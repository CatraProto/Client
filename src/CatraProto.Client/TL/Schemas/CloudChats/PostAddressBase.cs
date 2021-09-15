using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PostAddressBase : IObject
    {

[Newtonsoft.Json.JsonProperty("street_line1")]
		public abstract string StreetLine1 { get; set; }

[Newtonsoft.Json.JsonProperty("street_line2")]
		public abstract string StreetLine2 { get; set; }

[Newtonsoft.Json.JsonProperty("city")]
		public abstract string City { get; set; }

[Newtonsoft.Json.JsonProperty("state")]
		public abstract string State { get; set; }

[Newtonsoft.Json.JsonProperty("country_iso2")]
		public abstract string CountryIso2 { get; set; }

[Newtonsoft.Json.JsonProperty("post_code")]
		public abstract string PostCode { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
