using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryBase : IObject
    {
        [JsonProperty("hidden")] public abstract bool Hidden { get; set; }

        [JsonProperty("iso2")] public abstract string Iso2 { get; set; }

        [JsonProperty("default_name")] public abstract string DefaultName { get; set; }

        [JsonProperty("name")] public abstract string Name { get; set; }

        [JsonProperty("country_codes")] public abstract IList<CountryCodeBase> CountryCodes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}