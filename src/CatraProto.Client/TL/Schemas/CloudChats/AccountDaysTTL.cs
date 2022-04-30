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
    public partial class AccountDaysTTL : CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1194283041; }

        [Newtonsoft.Json.JsonProperty("days")]
        public sealed override int Days { get; set; }


#nullable enable
        public AccountDaysTTL(int days)
        {
            Days = days;

        }
#nullable disable
        internal AccountDaysTTL()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Days);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydays = reader.ReadInt32();
            if (trydays.IsError)
            {
                return ReadResult<IObject>.Move(trydays);
            }
            Days = trydays.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "accountDaysTTL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AccountDaysTTL
            {
                Days = Days
            };
            return newClonedObject;

        }
#nullable disable
    }
}