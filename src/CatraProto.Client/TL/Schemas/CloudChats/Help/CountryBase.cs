using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class CountryBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("hidden")]
        public abstract bool Hidden { get; set; }

        [Newtonsoft.Json.JsonProperty("iso2")] public abstract string Iso2 { get; set; }

        [Newtonsoft.Json.JsonProperty("default_name")]
        public abstract string DefaultName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("name")]
        public abstract string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("country_codes")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase> CountryCodes { get; set; }

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