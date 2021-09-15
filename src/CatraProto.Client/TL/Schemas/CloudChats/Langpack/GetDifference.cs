using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
    public partial class GetDifference : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -845657435;
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

        [JsonProperty("from_version")] public int FromVersion { get; set; }

        public override string ToString()
        {
            return "langpack.getDifference";
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
            writer.Write(FromVersion);
        }

        public void Deserialize(Reader reader)
        {
            LangPack = reader.Read<string>();
            LangCode = reader.Read<string>();
            FromVersion = reader.Read<int>();
        }
    }
}