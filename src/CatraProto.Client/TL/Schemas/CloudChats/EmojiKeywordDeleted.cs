/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EmojiKeywordDeleted : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 594408994; }

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
            var newClonedObject = new EmojiKeywordDeleted
            {
                Keyword = Keyword,
                Emoticons = new List<string>()
            };
            foreach (var emoticons in Emoticons)
            {
                newClonedObject.Emoticons.Add(emoticons);
            }
            return newClonedObject;

        }
#nullable disable
    }
}