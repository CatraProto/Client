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

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
    public partial class GetUsers : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 227648840; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("id")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Id { get; set; }


#nullable enable
        public GetUsers(List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> id)
        {
            Id = id;

        }
#nullable disable

        internal GetUsers()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteVector(Id, false);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "users.getUsers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetUsers
            {
                Id = new List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>()
            };
            foreach (var id in Id)
            {
                var cloneid = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)id.Clone();
                if (cloneid is null)
                {
                    return null;
                }
                newClonedObject.Id.Add(cloneid);
            }
            return newClonedObject;

        }
#nullable disable
    }
}