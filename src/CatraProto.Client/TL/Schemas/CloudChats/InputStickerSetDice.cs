using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputStickerSetDice : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {
        public static int StaticConstructorId
        {
            get => -427863538;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }


    #nullable enable
        public InputStickerSetDice(string emoticon)
        {
            Emoticon = emoticon;
        }
    #nullable disable
        internal InputStickerSetDice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Emoticon);
        }

        public override void Deserialize(Reader reader)
        {
            Emoticon = reader.Read<string>();
        }

        public override string ToString()
        {
            return "inputStickerSetDice";
        }
    }
}