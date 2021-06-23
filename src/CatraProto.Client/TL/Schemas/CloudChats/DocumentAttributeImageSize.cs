using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class DocumentAttributeImageSize : DocumentAttributeBase
    {
        public static int ConstructorId { get; } = 1815593308;
        public int W { get; set; }
        public int H { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(W);
            writer.Write(H);
        }

        public override void Deserialize(Reader reader)
        {
            W = reader.Read<int>();
            H = reader.Read<int>();
        }
    }
}