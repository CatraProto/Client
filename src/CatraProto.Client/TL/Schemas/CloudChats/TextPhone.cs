using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextPhone : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        public static int StaticConstructorId
        {
            get => 483104362;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("phone")]
        public string Phone { get; set; }


    #nullable enable
        public TextPhone(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, string phone)
        {
            Text = text;
            Phone = phone;
        }
    #nullable disable
        internal TextPhone()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Text);
            writer.Write(Phone);
        }

        public override void Deserialize(Reader reader)
        {
            Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            Phone = reader.Read<string>();
        }

        public override string ToString()
        {
            return "textPhone";
        }
    }
}