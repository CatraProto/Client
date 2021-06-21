using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SavedGifs : SavedGifsBase
    {
        public static int ConstructorId { get; } = 772213157;
        public int Hash { get; set; }
        public IList<DocumentBase> Gifs { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Hash);
            writer.Write(Gifs);
        }

        public override void Deserialize(Reader reader)
        {
            Hash = reader.Read<int>();
            Gifs = reader.ReadVector<DocumentBase>();
        }
    }
}