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

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class DropTempAuthKeys : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1907842680; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("except_auth_keys")]
        public List<long> ExceptAuthKeys { get; set; }


#nullable enable
        public DropTempAuthKeys(List<long> exceptAuthKeys)
        {
            ExceptAuthKeys = exceptAuthKeys;

        }
#nullable disable

        internal DropTempAuthKeys()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(ExceptAuthKeys, false);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexceptAuthKeys = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryexceptAuthKeys.IsError)
            {
                return ReadResult<IObject>.Move(tryexceptAuthKeys);
            }
            ExceptAuthKeys = tryexceptAuthKeys.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.dropTempAuthKeys";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DropTempAuthKeys
            {
                ExceptAuthKeys = new List<long>()
            };
            foreach (var exceptAuthKeys in ExceptAuthKeys)
            {
                newClonedObject.ExceptAuthKeys.Add(exceptAuthKeys);
            }
            return newClonedObject;

        }
#nullable disable
    }
}