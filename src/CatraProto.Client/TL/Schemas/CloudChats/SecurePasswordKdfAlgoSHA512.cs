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
    public partial class SecurePasswordKdfAlgoSHA512 : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2042159726; }

        [Newtonsoft.Json.JsonProperty("salt")]
        public byte[] Salt { get; set; }


#nullable enable
        public SecurePasswordKdfAlgoSHA512(byte[] salt)
        {
            Salt = salt;

        }
#nullable disable
        internal SecurePasswordKdfAlgoSHA512()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Salt);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysalt = reader.ReadBytes();
            if (trysalt.IsError)
            {
                return ReadResult<IObject>.Move(trysalt);
            }
            Salt = trysalt.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "securePasswordKdfAlgoSHA512";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecurePasswordKdfAlgoSHA512
            {
                Salt = Salt
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecurePasswordKdfAlgoSHA512 castedOther)
            {
                return true;
            }
            if (Salt != castedOther.Salt)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}