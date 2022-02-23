using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class KeyboardButtonRequestPhone : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        public static int StaticConstructorId
        {
            get => -1318425559;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


    #nullable enable
        public KeyboardButtonRequestPhone(string text)
        {
            Text = text;
        }
    #nullable disable
        internal KeyboardButtonRequestPhone()
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
            Text = reader.Read<string>();
        }

        public override string ToString()
        {
            return "keyboardButtonRequestPhone";
        }
    }
}