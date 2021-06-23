using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PageListOrderedItemBlocks : PageListOrderedItemBase
    {
        public static int ConstructorId { get; } = -1730311882;
        public override string Num { get; set; }
        public IList<PageBlockBase> Blocks { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Num);
            writer.Write(Blocks);
        }

        public override void Deserialize(Reader reader)
        {
            Num = reader.Read<string>();
            Blocks = reader.ReadVector<PageBlockBase>();
        }
    }
}