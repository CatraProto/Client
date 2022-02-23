using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
    public partial class GetLangPack : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -219008246;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.LangPackDifferenceBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


    #nullable enable
        public GetLangPack(string langPack, string langCode)
        {
            LangPack = langPack;
            LangCode = langCode;
        }
    #nullable disable

        internal GetLangPack()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(LangPack);
            writer.Write(LangCode);
        }

        public void Deserialize(Reader reader)
        {
            LangPack = reader.Read<string>();
            LangCode = reader.Read<string>();
        }

        public override string ToString()
        {
            return "langpack.getLangPack";
        }
    }
}