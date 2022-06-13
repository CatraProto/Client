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
    public partial class GroupCallParticipantVideoSourceGroup : CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantVideoSourceGroupBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -592373577; }

        [Newtonsoft.Json.JsonProperty("semantics")]
        public sealed override string Semantics { get; set; }

        [Newtonsoft.Json.JsonProperty("sources")]
        public sealed override List<int> Sources { get; set; }


#nullable enable
        public GroupCallParticipantVideoSourceGroup(string semantics, List<int> sources)
        {
            Semantics = semantics;
            Sources = sources;

        }
#nullable disable
        internal GroupCallParticipantVideoSourceGroup()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Semantics);

            writer.WriteVector(Sources, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysemantics = reader.ReadString();
            if (trysemantics.IsError)
            {
                return ReadResult<IObject>.Move(trysemantics);
            }
            Semantics = trysemantics.Value;
            var trysources = reader.ReadVector<int>(ParserTypes.Int);
            if (trysources.IsError)
            {
                return ReadResult<IObject>.Move(trysources);
            }
            Sources = trysources.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "groupCallParticipantVideoSourceGroup";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallParticipantVideoSourceGroup
            {
                Semantics = Semantics,
                Sources = new List<int>()
            };
            foreach (var sources in Sources)
            {
                newClonedObject.Sources.Add(sources);
            }
            return newClonedObject;

        }
#nullable disable
    }
}