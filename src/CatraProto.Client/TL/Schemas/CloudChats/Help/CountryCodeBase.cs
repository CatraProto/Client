using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryCodeBase : IObject
    {
        [JsonProperty("country_code")] public abstract string CountryCodeField { get; set; }

        [JsonProperty("prefixes")] public abstract IList<string> Prefixes { get; set; }

        [JsonProperty("patterns")] public abstract IList<string> Patterns { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}