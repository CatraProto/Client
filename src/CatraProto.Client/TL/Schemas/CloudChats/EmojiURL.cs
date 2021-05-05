using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiURL : EmojiURLBase
    {
        public static int ConstructorId { get; } = -1519029347;
        public override string Url { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Url);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
        }
    }
}