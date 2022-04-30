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
    public partial class UpdatePhoneCallSignalingData : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 643940105; }

        [Newtonsoft.Json.JsonProperty("phone_call_id")]
        public long PhoneCallId { get; set; }

        [Newtonsoft.Json.JsonProperty("data")]
        public byte[] Data { get; set; }


#nullable enable
        public UpdatePhoneCallSignalingData(long phoneCallId, byte[] data)
        {
            PhoneCallId = phoneCallId;
            Data = data;

        }
#nullable disable
        internal UpdatePhoneCallSignalingData()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PhoneCallId);

            writer.WriteBytes(Data);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCallId = reader.ReadInt64();
            if (tryphoneCallId.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCallId);
            }
            PhoneCallId = tryphoneCallId.Value;
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }
            Data = trydata.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePhoneCallSignalingData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePhoneCallSignalingData
            {
                PhoneCallId = PhoneCallId,
                Data = Data
            };
            return newClonedObject;

        }
#nullable disable
    }
}