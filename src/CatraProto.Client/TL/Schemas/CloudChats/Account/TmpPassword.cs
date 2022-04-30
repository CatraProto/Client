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
    public partial class TmpPassword : CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -614138572; }

        [Newtonsoft.Json.JsonProperty("tmp_password")]
        public sealed override byte[] TmpPasswordField { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public sealed override int ValidUntil { get; set; }


#nullable enable
        public TmpPassword(byte[] tmpPasswordField, int validUntil)
        {
            TmpPasswordField = tmpPasswordField;
            ValidUntil = validUntil;

        }
#nullable disable
        internal TmpPassword()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(TmpPasswordField);
            writer.WriteInt32(ValidUntil);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytmpPasswordField = reader.ReadBytes();
            if (trytmpPasswordField.IsError)
            {
                return ReadResult<IObject>.Move(trytmpPasswordField);
            }
            TmpPasswordField = trytmpPasswordField.Value;
            var tryvalidUntil = reader.ReadInt32();
            if (tryvalidUntil.IsError)
            {
                return ReadResult<IObject>.Move(tryvalidUntil);
            }
            ValidUntil = tryvalidUntil.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.tmpPassword";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TmpPassword
            {
                TmpPasswordField = TmpPasswordField,
                ValidUntil = ValidUntil
            };
            return newClonedObject;

        }
#nullable disable
    }
}