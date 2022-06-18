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
    public partial class JsonString : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1222740358; }

        [Newtonsoft.Json.JsonProperty("value")]
        public string Value { get; set; }


#nullable enable
        public JsonString(string value)
        {
            Value = value;

        }
#nullable disable
        internal JsonString()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Value);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadString();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }
            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "jsonString";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonString
            {
                Value = Value
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not JsonString castedOther)
            {
                return true;
            }
            if (Value != castedOther.Value)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}