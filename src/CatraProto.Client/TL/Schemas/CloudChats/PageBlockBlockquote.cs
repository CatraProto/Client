using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockBlockquote : PageBlockBase
    {
        public static int ConstructorId { get; } = 641563686;
        public RichTextBase Text { get; set; }
        public RichTextBase Caption { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Text);
            writer.Write(Caption);
        }

        public override void Deserialize(Reader reader)
        {
            Text = reader.Read<RichTextBase>();
            Caption = reader.Read<RichTextBase>();
        }
    }
}