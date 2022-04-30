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
    public partial class SaveSecureValue : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1986010339; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("value")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase Value { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_secret_id")]
        public long SecureSecretId { get; set; }


#nullable enable
        public SaveSecureValue(CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase value, long secureSecretId)
        {
            Value = value;
            SecureSecretId = secureSecretId;

        }
#nullable disable

        internal SaveSecureValue()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkvalue = writer.WriteObject(Value);
            if (checkvalue.IsError)
            {
                return checkvalue;
            }
            writer.WriteInt64(SecureSecretId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase>();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }
            Value = tryvalue.Value;
            var trysecureSecretId = reader.ReadInt64();
            if (trysecureSecretId.IsError)
            {
                return ReadResult<IObject>.Move(trysecureSecretId);
            }
            SecureSecretId = trysecureSecretId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.saveSecureValue";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveSecureValue();
            var cloneValue = (CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase?)Value.Clone();
            if (cloneValue is null)
            {
                return null;
            }
            newClonedObject.Value = cloneValue;
            newClonedObject.SecureSecretId = SecureSecretId;
            return newClonedObject;

        }
#nullable disable
    }
}