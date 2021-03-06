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
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class Support : CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 398898678; }

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public sealed override string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("user")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }


#nullable enable
        public Support(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.UserBase user)
        {
            PhoneNumber = phoneNumber;
            User = user;

        }
#nullable disable
        internal Support()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);
            var checkuser = writer.WriteObject(User);
            if (checkuser.IsError)
            {
                return checkuser;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneNumber = reader.ReadString();
            if (tryphoneNumber.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneNumber);
            }
            PhoneNumber = tryphoneNumber.Value;
            var tryuser = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            if (tryuser.IsError)
            {
                return ReadResult<IObject>.Move(tryuser);
            }
            User = tryuser.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.support";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Support
            {
                PhoneNumber = PhoneNumber
            };
            var cloneUser = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)User.Clone();
            if (cloneUser is null)
            {
                return null;
            }
            newClonedObject.User = cloneUser;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Support castedOther)
            {
                return true;
            }
            if (PhoneNumber != castedOther.PhoneNumber)
            {
                return true;
            }
            if (User.Compare(castedOther.User))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}