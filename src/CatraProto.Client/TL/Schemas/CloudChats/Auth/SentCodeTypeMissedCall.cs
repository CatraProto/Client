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
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SentCodeTypeMissedCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2113903484; }

        [Newtonsoft.Json.JsonProperty("prefix")]
        public string Prefix { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public int Length { get; set; }


#nullable enable
        public SentCodeTypeMissedCall(string prefix, int length)
        {
            Prefix = prefix;
            Length = length;

        }
#nullable disable
        internal SentCodeTypeMissedCall()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Prefix);
            writer.WriteInt32(Length);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryprefix = reader.ReadString();
            if (tryprefix.IsError)
            {
                return ReadResult<IObject>.Move(tryprefix);
            }
            Prefix = tryprefix.Value;
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }
            Length = trylength.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.sentCodeTypeMissedCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentCodeTypeMissedCall
            {
                Prefix = Prefix,
                Length = Length
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SentCodeTypeMissedCall castedOther)
            {
                return true;
            }
            if (Prefix != castedOther.Prefix)
            {
                return true;
            }
            if (Length != castedOther.Length)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}