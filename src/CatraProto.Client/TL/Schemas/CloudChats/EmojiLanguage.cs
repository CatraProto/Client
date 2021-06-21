using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiLanguage : EmojiLanguageBase
    {
        public static int ConstructorId { get; } = -1275374751;
        public override string LangCode { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(LangCode);
        }

        public override void Deserialize(Reader reader)
        {
            LangCode = reader.Read<string>();
        }
    }
}