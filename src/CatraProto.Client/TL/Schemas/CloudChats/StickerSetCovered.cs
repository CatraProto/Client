using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class StickerSetCovered : StickerSetCoveredBase
    {
        public static int ConstructorId { get; } = 1678812626;
        public override StickerSetBase Set { get; set; }
        public DocumentBase Cover { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Set);
            writer.Write(Cover);
        }

        public override void Deserialize(Reader reader)
        {
            Set = reader.Read<StickerSetBase>();
            Cover = reader.Read<DocumentBase>();
        }
    }
}