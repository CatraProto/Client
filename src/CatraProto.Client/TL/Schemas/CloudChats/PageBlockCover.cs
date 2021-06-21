using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockCover : PageBlockBase
    {
        public static int ConstructorId { get; } = 972174080;
        public PageBlockBase Cover { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Cover);
        }

        public override void Deserialize(Reader reader)
        {
            Cover = reader.Read<PageBlockBase>();
        }
    }
}