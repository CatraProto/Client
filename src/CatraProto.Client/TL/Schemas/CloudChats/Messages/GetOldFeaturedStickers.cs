using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetOldFeaturedStickers : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1608974939;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(FeaturedStickersBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("offset")] public int Offset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "messages.getOldFeaturedStickers";
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

            writer.Write(Offset);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}