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

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UnregisterDevice : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1779249670; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("token_type")]
        public int TokenType { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }

        [Newtonsoft.Json.JsonProperty("other_uids")]
        public List<long> OtherUids { get; set; }


#nullable enable
        public UnregisterDevice(int tokenType, string token, List<long> otherUids)
        {
            TokenType = tokenType;
            Token = token;
            OtherUids = otherUids;

        }
#nullable disable

        internal UnregisterDevice()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(TokenType);

            writer.WriteString(Token);

            writer.WriteVector(OtherUids, false);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytokenType = reader.ReadInt32();
            if (trytokenType.IsError)
            {
                return ReadResult<IObject>.Move(trytokenType);
            }
            TokenType = trytokenType.Value;
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }
            Token = trytoken.Value;
            var tryotherUids = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryotherUids.IsError)
            {
                return ReadResult<IObject>.Move(tryotherUids);
            }
            OtherUids = tryotherUids.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.unregisterDevice";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UnregisterDevice
            {
                TokenType = TokenType,
                Token = Token,
                OtherUids = new List<long>()
            };
            foreach (var otherUids in OtherUids)
            {
                newClonedObject.OtherUids.Add(otherUids);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not UnregisterDevice castedOther)
            {
                return true;
            }
            if (TokenType != castedOther.TokenType)
            {
                return true;
            }
            if (Token != castedOther.Token)
            {
                return true;
            }
            var otherUidssize = castedOther.OtherUids.Count;
            if (otherUidssize != OtherUids.Count)
            {
                return true;
            }
            for (var i = 0; i < otherUidssize; i++)
            {
                if (castedOther.OtherUids[i] != OtherUids[i])
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}