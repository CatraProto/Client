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
    public partial class GetSearchCounters : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1932455680; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("filters")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> Filters { get; set; }


#nullable enable
        public GetSearchCounters(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> filters)
        {
            Peer = peer;
            Filters = filters;

        }
#nullable disable

        internal GetSearchCounters()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            var checkfilters = writer.WriteVector(Filters, false);
            if (checkfilters.IsError)
            {
                return checkfilters;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryfilters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryfilters.IsError)
            {
                return ReadResult<IObject>.Move(tryfilters);
            }
            Filters = tryfilters.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getSearchCounters";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetSearchCounters();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.Filters = new List<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
            foreach (var filters in Filters)
            {
                var clonefilters = (CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase?)filters.Clone();
                if (clonefilters is null)
                {
                    return null;
                }
                newClonedObject.Filters.Add(clonefilters);
            }
            return newClonedObject;

        }
#nullable disable
    }
}