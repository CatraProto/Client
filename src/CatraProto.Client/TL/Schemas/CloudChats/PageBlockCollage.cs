using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockCollage : PageBlockBase
    {
        public static int ConstructorId { get; } = 1705048653;
        public IList<PageBlockBase> Items { get; set; }
        public PageCaptionBase Caption { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Items);
            writer.Write(Caption);
        }

        public override void Deserialize(Reader reader)
        {
            Items = reader.ReadVector<PageBlockBase>();
            Caption = reader.Read<PageCaptionBase>();
        }
    }
}