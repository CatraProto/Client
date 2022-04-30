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
    public partial class UpdatePhoneCall : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1425052898; }

        [Newtonsoft.Json.JsonProperty("phone_call")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCall { get; set; }


#nullable enable
        public UpdatePhoneCall(CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase phoneCall)
        {
            PhoneCall = phoneCall;

        }
#nullable disable
        internal UpdatePhoneCall()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkphoneCall = writer.WriteObject(PhoneCall);
            if (checkphoneCall.IsError)
            {
                return checkphoneCall;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();
            if (tryphoneCall.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCall);
            }
            PhoneCall = tryphoneCall.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePhoneCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePhoneCall();
            var clonePhoneCall = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase?)PhoneCall.Clone();
            if (clonePhoneCall is null)
            {
                return null;
            }
            newClonedObject.PhoneCall = clonePhoneCall;
            return newClonedObject;

        }
#nullable disable
    }
}