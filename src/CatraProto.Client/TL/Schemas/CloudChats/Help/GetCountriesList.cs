using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class GetCountriesList : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1935116200;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public int Hash { get; set; }


    #nullable enable
        public GetCountriesList(string langCode, int hash)
        {
            LangCode = langCode;
            Hash = hash;
        }
    #nullable disable

        internal GetCountriesList()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(LangCode);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            LangCode = reader.Read<string>();
            Hash = reader.Read<int>();
        }

        public override string ToString()
        {
            return "help.getCountriesList";
        }
    }
}