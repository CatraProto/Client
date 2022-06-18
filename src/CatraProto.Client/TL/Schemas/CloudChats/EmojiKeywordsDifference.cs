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
    public partial class EmojiKeywordsDifference : CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordsDifferenceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1556570557; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public sealed override string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("from_version")]
        public sealed override int FromVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public sealed override int Version { get; set; }

        [Newtonsoft.Json.JsonProperty("keywords")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> Keywords { get; set; }


#nullable enable
        public EmojiKeywordsDifference(string langCode, int fromVersion, int version, List<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase> keywords)
        {
            LangCode = langCode;
            FromVersion = fromVersion;
            Version = version;
            Keywords = keywords;

        }
#nullable disable
        internal EmojiKeywordsDifference()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangCode);
            writer.WriteInt32(FromVersion);
            writer.WriteInt32(Version);
            var checkkeywords = writer.WriteVector(Keywords, false);
            if (checkkeywords.IsError)
            {
                return checkkeywords;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }
            LangCode = trylangCode.Value;
            var tryfromVersion = reader.ReadInt32();
            if (tryfromVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryfromVersion);
            }
            FromVersion = tryfromVersion.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }
            Version = tryversion.Value;
            var trykeywords = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trykeywords.IsError)
            {
                return ReadResult<IObject>.Move(trykeywords);
            }
            Keywords = trykeywords.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "emojiKeywordsDifference";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EmojiKeywordsDifference
            {
                LangCode = LangCode,
                FromVersion = FromVersion,
                Version = Version,
                Keywords = new List<CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase>()
            };
            foreach (var keywords in Keywords)
            {
                var clonekeywords = (CatraProto.Client.TL.Schemas.CloudChats.EmojiKeywordBase?)keywords.Clone();
                if (clonekeywords is null)
                {
                    return null;
                }
                newClonedObject.Keywords.Add(clonekeywords);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not EmojiKeywordsDifference castedOther)
            {
                return true;
            }
            if (LangCode != castedOther.LangCode)
            {
                return true;
            }
            if (FromVersion != castedOther.FromVersion)
            {
                return true;
            }
            if (Version != castedOther.Version)
            {
                return true;
            }
            var keywordssize = castedOther.Keywords.Count;
            if (keywordssize != Keywords.Count)
            {
                return true;
            }
            for (var i = 0; i < keywordssize; i++)
            {
                if (castedOther.Keywords[i].Compare(Keywords[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}