using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryCodeBase : IObject
    {

[JsonPropertyName("CountryCode_")]
		public abstract string CountryCode_ { get; set; }

[JsonPropertyName("prefixes")]
		public abstract IList<string> Prefixes { get; set; }

[JsonPropertyName("patterns")]
		public abstract IList<string> Patterns { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
