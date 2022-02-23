using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageListOrderedItemText : CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase
    {
        public static int StaticConstructorId
        {
            get => 1577484359;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("num")] public sealed override string Num { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


    #nullable enable
        public PageListOrderedItemText(string num, CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
        {
            Num = num;
            Text = text;
        }
    #nullable disable
        internal PageListOrderedItemText()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Num);
            writer.Write(Text);
        }

        public override void Deserialize(Reader reader)
        {
            Num = reader.Read<string>();
            Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
        }

        public override string ToString()
        {
            return "pageListOrderedItemText";
        }
    }
}