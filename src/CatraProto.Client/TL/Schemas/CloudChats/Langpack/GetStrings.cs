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

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
    public partial class GetStrings : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -269862909; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("keys")]
        public List<string> Keys { get; set; }


#nullable enable
        public GetStrings(string langPack, string langCode, List<string> keys)
        {
            LangPack = langPack;
            LangCode = langCode;
            Keys = keys;

        }
#nullable disable

        internal GetStrings()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangPack);

            writer.WriteString(LangCode);

            writer.WriteVector(Keys, false);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangPack = reader.ReadString();
            if (trylangPack.IsError)
            {
                return ReadResult<IObject>.Move(trylangPack);
            }
            LangPack = trylangPack.Value;
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }
            LangCode = trylangCode.Value;
            var trykeys = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (trykeys.IsError)
            {
                return ReadResult<IObject>.Move(trykeys);
            }
            Keys = trykeys.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "langpack.getStrings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetStrings
            {
                LangPack = LangPack,
                LangCode = LangCode,
                Keys = new List<string>()
            };
            foreach (var keys in Keys)
            {
                newClonedObject.Keys.Add(keys);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetStrings castedOther)
            {
                return true;
            }
            if (LangPack != castedOther.LangPack)
            {
                return true;
            }
            if (LangCode != castedOther.LangCode)
            {
                return true;
            }
            var keyssize = castedOther.Keys.Count;
            if (keyssize != Keys.Count)
            {
                return true;
            }
            for (var i = 0; i < keyssize; i++)
            {
                if (castedOther.Keys[i] != Keys[i])
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}