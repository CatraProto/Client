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
    public partial class JsonObjectValue : CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1059185703; }

        [Newtonsoft.Json.JsonProperty("key")]
        public sealed override string Key { get; set; }

        [Newtonsoft.Json.JsonProperty("value")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }


#nullable enable
        public JsonObjectValue(string key, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase value)
        {
            Key = key;
            Value = value;

        }
#nullable disable
        internal JsonObjectValue()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Key);
            var checkvalue = writer.WriteObject(Value);
            if (checkvalue.IsError)
            {
                return checkvalue;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykey = reader.ReadString();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }
            Key = trykey.Value;
            var tryvalue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }
            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "jsonObjectValue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonObjectValue
            {
                Key = Key
            };
            var cloneValue = (CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase?)Value.Clone();
            if (cloneValue is null)
            {
                return null;
            }
            newClonedObject.Value = cloneValue;
            return newClonedObject;

        }
#nullable disable
    }
}