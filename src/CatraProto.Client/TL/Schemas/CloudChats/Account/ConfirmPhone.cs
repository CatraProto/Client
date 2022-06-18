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
    public partial class ConfirmPhone : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1596029123; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public string PhoneCodeHash { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code")]
        public string PhoneCode { get; set; }


#nullable enable
        public ConfirmPhone(string phoneCodeHash, string phoneCode)
        {
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;

        }
#nullable disable

        internal ConfirmPhone()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneCodeHash);

            writer.WriteString(PhoneCode);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCodeHash = reader.ReadString();
            if (tryphoneCodeHash.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCodeHash);
            }
            PhoneCodeHash = tryphoneCodeHash.Value;
            var tryphoneCode = reader.ReadString();
            if (tryphoneCode.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCode);
            }
            PhoneCode = tryphoneCode.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.confirmPhone";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ConfirmPhone
            {
                PhoneCodeHash = PhoneCodeHash,
                PhoneCode = PhoneCode
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ConfirmPhone castedOther)
            {
                return true;
            }
            if (PhoneCodeHash != castedOther.PhoneCodeHash)
            {
                return true;
            }
            if (PhoneCode != castedOther.PhoneCode)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}