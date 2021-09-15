using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
    public partial class GetLanguages : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1120311183;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(LangPackLanguageBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("lang_pack")] public string LangPack { get; set; }

        public override string ToString()
        {
            return "langpack.getLanguages";
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
        }

        public void Deserialize(Reader reader)
        {
            LangPack = reader.Read<string>();
        }
    }
}