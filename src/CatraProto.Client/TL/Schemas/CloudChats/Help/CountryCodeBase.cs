using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryCodeBase : IObject
    {

[Newtonsoft.Json.JsonProperty("country_code")]
		public abstract string CountryCodeField { get; set; }

[Newtonsoft.Json.JsonProperty("prefixes")]
		public abstract IList<string> Prefixes { get; set; }

[Newtonsoft.Json.JsonProperty("patterns")]
		public abstract IList<string> Patterns { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
