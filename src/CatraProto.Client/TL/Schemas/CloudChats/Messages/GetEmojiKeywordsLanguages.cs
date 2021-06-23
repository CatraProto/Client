using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetEmojiKeywordsLanguages : IMethod
    {
        public static int ConstructorId { get; } = 1318675378;

        public System.Type Type { get; init; } = typeof(EmojiLanguageBase);
        public bool IsVector { get; init; } = false;
        public IList<string> LangCodes { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(LangCodes);
        }

        public void Deserialize(Reader reader)
        {
            LangCodes = reader.ReadVector<string>();
        }
    }
}