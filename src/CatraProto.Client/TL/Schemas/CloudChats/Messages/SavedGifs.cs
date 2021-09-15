using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SavedGifs : SavedGifsBase
    {
        public static int StaticConstructorId
        {
            get => 772213157;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("hash")] public int Hash { get; set; }

        [JsonProperty("gifs")] public IList<DocumentBase> Gifs { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Hash);
            writer.Write(Gifs);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Gifs = reader.ReadVector<DocumentBase>();
        }

        public override string ToString()
        {
            return "messages.savedGifs";
        }
    }
}