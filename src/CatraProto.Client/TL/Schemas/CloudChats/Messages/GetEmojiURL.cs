using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetEmojiURL : IMethod
    {
        public static int ConstructorId { get; } = -709817306;

        public System.Type Type { get; init; } = typeof(EmojiURLBase);
        public bool IsVector { get; init; } = false;
        public string LangCode { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(LangCode);
        }

        public void Deserialize(Reader reader)
        {
            LangCode = reader.Read<string>();
        }
    }
}