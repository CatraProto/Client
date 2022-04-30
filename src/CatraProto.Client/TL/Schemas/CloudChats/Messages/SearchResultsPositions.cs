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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SearchResultsPositions : CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchResultsPositionsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1404185519; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("positions")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> Positions { get; set; }


#nullable enable
        public SearchResultsPositions(int count, List<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase> positions)
        {
            Count = count;
            Positions = positions;

        }
#nullable disable
        internal SearchResultsPositions()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkpositions = writer.WriteVector(Positions, false);
            if (checkpositions.IsError)
            {
                return checkpositions;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            var trypositions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypositions.IsError)
            {
                return ReadResult<IObject>.Move(trypositions);
            }
            Positions = trypositions.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.searchResultsPositions";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SearchResultsPositions
            {
                Count = Count
            };
            foreach (var positions in Positions)
            {
                var clonepositions = (CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase?)positions.Clone();
                if (clonepositions is null)
                {
                    return null;
                }
                newClonedObject.Positions.Add(clonepositions);
            }
            return newClonedObject;

        }
#nullable disable
    }
}