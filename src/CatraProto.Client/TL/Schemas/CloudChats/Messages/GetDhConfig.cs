using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDhConfig : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 651135312;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(DhConfigBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("version")] public int Version { get; set; }

        [JsonProperty("random_length")] public int RandomLength { get; set; }

        public override string ToString()
        {
            return "messages.getDhConfig";
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

            writer.Write(Version);
            writer.Write(RandomLength);
        }

        public void Deserialize(Reader reader)
        {
            Version = reader.Read<int>();
            RandomLength = reader.Read<int>();
        }
    }
}