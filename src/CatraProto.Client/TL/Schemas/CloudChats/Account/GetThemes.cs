using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetThemes : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 676939512;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ThemesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("format")] public string Format { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "account.getThemes";
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

            writer.Write(Format);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Format = reader.Read<string>();
            Hash = reader.Read<int>();
        }
    }
}