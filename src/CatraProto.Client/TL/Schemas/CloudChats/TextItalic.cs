using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextItalic : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        public static int StaticConstructorId
        {
            get => -653089380;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


    #nullable enable
        public TextItalic(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
        {
            Text = text;
        }
    #nullable disable
        internal TextItalic()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Text);
        }

        public override void Deserialize(Reader reader)
        {
            Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
        }

        public override string ToString()
        {
            return "textItalic";
        }
    }
}