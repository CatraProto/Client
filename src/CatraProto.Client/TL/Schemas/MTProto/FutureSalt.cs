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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class FutureSalt : CatraProto.Client.TL.Schemas.MTProto.FutureSaltBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 155834844; }

        [Newtonsoft.Json.JsonProperty("valid_since")]
        public sealed override int ValidSince { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public sealed override int ValidUntil { get; set; }

        [Newtonsoft.Json.JsonProperty("salt")]
        public sealed override long Salt { get; set; }


#nullable enable
        public FutureSalt(int validSince, int validUntil, long salt)
        {
            ValidSince = validSince;
            ValidUntil = validUntil;
            Salt = salt;

        }
#nullable disable
        internal FutureSalt()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ValidSince);
            writer.WriteInt32(ValidUntil);
            writer.WriteInt64(Salt);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalidSince = reader.ReadInt32();
            if (tryvalidSince.IsError)
            {
                return ReadResult<IObject>.Move(tryvalidSince);
            }
            ValidSince = tryvalidSince.Value;
            var tryvalidUntil = reader.ReadInt32();
            if (tryvalidUntil.IsError)
            {
                return ReadResult<IObject>.Move(tryvalidUntil);
            }
            ValidUntil = tryvalidUntil.Value;
            var trysalt = reader.ReadInt64();
            if (trysalt.IsError)
            {
                return ReadResult<IObject>.Move(trysalt);
            }
            Salt = trysalt.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "future_salt";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FutureSalt
            {
                ValidSince = ValidSince,
                ValidUntil = ValidUntil,
                Salt = Salt
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not FutureSalt castedOther)
            {
                return true;
            }
            if (ValidSince != castedOther.ValidSince)
            {
                return true;
            }
            if (ValidUntil != castedOther.ValidUntil)
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