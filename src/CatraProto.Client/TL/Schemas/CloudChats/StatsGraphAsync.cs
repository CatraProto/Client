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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGraphAsync : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1244130093; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }


#nullable enable
        public StatsGraphAsync(string token)
        {
            Token = token;

        }
#nullable disable
        internal StatsGraphAsync()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Token);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }
            Token = trytoken.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsGraphAsync";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGraphAsync
            {
                Token = Token
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGraphAsync castedOther)
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