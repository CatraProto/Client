using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class CountriesList : CountriesListBase
    {
        public static int StaticConstructorId
        {
            get => -2016381538;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("countries")] public IList<CountryBase> Countries { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Countries);
            writer.Write(Hash);
        }

        public override void Deserialize(Reader reader)
        {
            Countries = reader.ReadVector<CountryBase>();
            Hash = reader.Read<int>();
        }

        public override string ToString()
        {
            return "help.countriesList";
        }
    }
}