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
    public partial class InputCheckPasswordSRP : CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -763367294; }

        [Newtonsoft.Json.JsonProperty("srp_id")]
        public long SrpId { get; set; }

        [Newtonsoft.Json.JsonProperty("A")]
        public byte[] A { get; set; }

        [Newtonsoft.Json.JsonProperty("M1")]
        public byte[] M1 { get; set; }


#nullable enable
        public InputCheckPasswordSRP(long srpId, byte[] a, byte[] m1)
        {
            SrpId = srpId;
            A = a;
            M1 = m1;

        }
#nullable disable
        internal InputCheckPasswordSRP()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(SrpId);

            writer.WriteBytes(A);

            writer.WriteBytes(M1);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysrpId = reader.ReadInt64();
            if (trysrpId.IsError)
            {
                return ReadResult<IObject>.Move(trysrpId);
            }
            SrpId = trysrpId.Value;
            var trya = reader.ReadBytes();
            if (trya.IsError)
            {
                return ReadResult<IObject>.Move(trya);
            }
            A = trya.Value;
            var trym1 = reader.ReadBytes();
            if (trym1.IsError)
            {
                return ReadResult<IObject>.Move(trym1);
            }
            M1 = trym1.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputCheckPasswordSRP";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputCheckPasswordSRP
            {
                SrpId = SrpId,
                A = A,
                M1 = M1
            };
            return newClonedObject;

        }
#nullable disable
    }
}