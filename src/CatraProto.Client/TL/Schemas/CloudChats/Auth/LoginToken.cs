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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginToken : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1654593920; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public byte[] Token { get; set; }


#nullable enable
        public LoginToken(int expires, byte[] token)
        {
            Expires = expires;
            Token = token;

        }
#nullable disable
        internal LoginToken()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Expires);

            writer.WriteBytes(Token);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }
            Expires = tryexpires.Value;
            var trytoken = reader.ReadBytes();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }
            Token = trytoken.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.loginToken";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LoginToken
            {
                Expires = Expires,
                Token = Token
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not LoginToken castedOther)
            {
                return true;
            }
            if (Expires != castedOther.Expires)
            {
                return true;
            }
            if (Token != castedOther.Token)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}