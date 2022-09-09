using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryCodeBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("country_code")]
        public abstract string CountryCodeField { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("prefixes")]
        public abstract List<string> Prefixes { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("patterns")]
        public abstract List<string> Patterns { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}