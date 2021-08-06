using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryBase : IObject
    {

[JsonPropertyName("hidden")]
		public abstract bool Hidden { get; set; }

[JsonPropertyName("iso2")]
		public abstract string Iso2 { get; set; }

[JsonPropertyName("default_name")]
		public abstract string DefaultName { get; set; }

[JsonPropertyName("name")]
		public abstract string Name { get; set; }

[JsonPropertyName("country_codes")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase> CountryCodes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
