using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiKeyword : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -709641735; }

        [Newtonsoft.Json.JsonProperty("keyword")]
        public sealed override string Keyword { get; set; }

        [Newtonsoft.Json.JsonProperty("emoticons")]
        public sealed override List<string> Emoticons { get; set; }


#nullable enable
        public EmojiKeyword(string keyword, List<string> emoticons)
        {
            Keyword = keyword;
            Emoticons = emoticons;

        }
#nullable disable
        internal EmojiKeyword()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Keyword);

            writer.WriteVector(Emoticons, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykeyword = reader.ReadString();
            if (trykeyword.IsError)
            {
                return ReadResult<IObject>.Move(trykeyword);
            }
            Keyword = trykeyword.Value;
            var tryemoticons = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (tryemoticons.IsError)
            {
                return ReadResult<IObject>.Move(tryemoticons);
            }
            Emoticons = tryemoticons.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "emojiKeyword";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}