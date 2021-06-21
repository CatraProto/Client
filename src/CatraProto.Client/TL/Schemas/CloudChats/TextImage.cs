using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextImage : RichTextBase
    {
        public static int ConstructorId { get; } = 136105807;
        public long DocumentId { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(DocumentId);
            writer.Write(W);
            writer.Write(H);
        }

        public override void Deserialize(Reader reader)
        {
            DocumentId = reader.Read<long>();
            W = reader.Read<int>();
            H = reader.Read<int>();
        }
    }
}