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
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ResetPasswordRequestedWait : CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -370148227; }

        [Newtonsoft.Json.JsonProperty("until_date")]
        public int UntilDate { get; set; }


#nullable enable
        public ResetPasswordRequestedWait(int untilDate)
        {
            UntilDate = untilDate;

        }
#nullable disable
        internal ResetPasswordRequestedWait()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(UntilDate);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuntilDate = reader.ReadInt32();
            if (tryuntilDate.IsError)
            {
                return ReadResult<IObject>.Move(tryuntilDate);
            }
            UntilDate = tryuntilDate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.resetPasswordRequestedWait";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ResetPasswordRequestedWait
            {
                UntilDate = UntilDate
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ResetPasswordRequestedWait castedOther)
            {
                return true;
            }
            if (UntilDate != castedOther.UntilDate)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}