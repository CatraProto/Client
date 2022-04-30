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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class JsonObject : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1715350371; }

        [Newtonsoft.Json.JsonProperty("value")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> Value { get; set; }


#nullable enable
        public JsonObject(List<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase> value)
        {
            Value = value;

        }
#nullable disable
        internal JsonObject()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkvalue = writer.WriteVector(Value, false);
            if (checkvalue.IsError)
            {
                return checkvalue;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }
            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "jsonObject";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonObject();
            foreach (var value in Value)
            {
                var clonevalue = (CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase?)value.Clone();
                if (clonevalue is null)
                {
                    return null;
                }
                newClonedObject.Value.Add(clonevalue);
            }
            return newClonedObject;

        }
#nullable disable
    }
}