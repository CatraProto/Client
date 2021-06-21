using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiKeyword : EmojiKeywordBase
    {
        public static int ConstructorId { get; } = -709641735;
        public override string Keyword { get; set; }
        public override IList<string> Emoticons { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Keyword);
            writer.Write(Emoticons);
        }

        public override void Deserialize(Reader reader)
        {
            Keyword = reader.Read<string>();
            Emoticons = reader.ReadVector<string>();
        }
    }
}