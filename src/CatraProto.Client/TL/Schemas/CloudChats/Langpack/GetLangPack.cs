using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
    public partial class GetLangPack : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -219008246;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(LangPackDifferenceBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("lang_pack")] public string LangPack { get; set; }

        [JsonProperty("lang_code")] public string LangCode { get; set; }

        public override string ToString()
        {
            return "langpack.getLangPack";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(LangPack);
            writer.Write(LangCode);
        }

        public void Deserialize(Reader reader)
        {
            LangPack = reader.Read<string>();
            LangCode = reader.Read<string>();
        }
    }
}