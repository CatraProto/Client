using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetWallPapers : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1430579357;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(WallPapersBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "account.getWallPapers";
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

            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
        }
    }
}