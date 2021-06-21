using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StickerPack : StickerPackBase
    {
        public static int ConstructorId { get; } = 313694676;
        public override string Emoticon { get; set; }
        public override IList<long> Documents { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Emoticon);
            writer.Write(Documents);
        }

        public override void Deserialize(Reader reader)
        {
            Emoticon = reader.Read<string>();
            Documents = reader.ReadVector<long>();
        }
    }
}