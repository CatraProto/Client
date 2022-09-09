using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiKeywordDeleted : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 594408994; }

        [Newtonsoft.Json.JsonProperty("keyword")]
        public sealed override string Keyword { get; set; }

        [Newtonsoft.Json.JsonProperty("emoticons")]
        public sealed override List<string> Emoticons { get; set; }


#nullable enable
        public EmojiKeywordDeleted(string keyword, List<string> emoticons)
        {
            Keyword = keyword;
            Emoticons = emoticons;
        }
#nullable disable
        internal EmojiKeywordDeleted()
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
            return "emojiKeywordDeleted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EmojiKeywordDeleted();
            newClonedObject.Keyword = Keyword;
            newClonedObject.Emoticons = new List<string>();
            foreach (var emoticons in Emoticons)
            {
                newClonedObject.Emoticons.Add(emoticons);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EmojiKeywordDeleted castedOther)
            {
                return true;
            }

            if (Keyword != castedOther.Keyword)
            {
                return true;
            }

            var emoticonssize = castedOther.Emoticons.Count;
            if (emoticonssize != Emoticons.Count)
            {
                return true;
            }

            for (var i = 0; i < emoticonssize; i++)
            {
                if (castedOther.Emoticons[i] != Emoticons[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}