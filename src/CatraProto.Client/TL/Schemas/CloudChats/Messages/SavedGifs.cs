using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SavedGifs : CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase
    {
        public static int StaticConstructorId
        {
            get => -2069878259;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("gifs")] public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Gifs { get; set; }


    #nullable enable
        public SavedGifs(long hash, IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> gifs)
        {
            Hash = hash;
            Gifs = gifs;
        }
    #nullable disable
        internal SavedGifs()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Hash);
            writer.Write(Gifs);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<long>();
            Gifs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
        }

        public override string ToString()
        {
            return "messages.savedGifs";
        }
    }
}