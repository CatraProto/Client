using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockHeader : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        public static int StaticConstructorId
        {
            get => -1076861716;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


    #nullable enable
        public PageBlockHeader(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
        {
            Text = text;
        }
    #nullable disable
        internal PageBlockHeader()
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
            return "pageBlockHeader";
        }
    }
}