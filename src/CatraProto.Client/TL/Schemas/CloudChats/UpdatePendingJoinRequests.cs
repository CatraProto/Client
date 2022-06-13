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
    public partial class UpdatePendingJoinRequests : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1885586395; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("requests_pending")]
        public int RequestsPending { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_requesters")]
        public List<long> RecentRequesters { get; set; }


#nullable enable
        public UpdatePendingJoinRequests(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int requestsPending, List<long> recentRequesters)
        {
            Peer = peer;
            RequestsPending = requestsPending;
            RecentRequesters = recentRequesters;

        }
#nullable disable
        internal UpdatePendingJoinRequests()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(RequestsPending);

            writer.WriteVector(RecentRequesters, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryrequestsPending = reader.ReadInt32();
            if (tryrequestsPending.IsError)
            {
                return ReadResult<IObject>.Move(tryrequestsPending);
            }
            RequestsPending = tryrequestsPending.Value;
            var tryrecentRequesters = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryrecentRequesters.IsError)
            {
                return ReadResult<IObject>.Move(tryrecentRequesters);
            }
            RecentRequesters = tryrecentRequesters.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePendingJoinRequests";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePendingJoinRequests();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.RequestsPending = RequestsPending;
            newClonedObject.RecentRequesters = new List<long>();
            foreach (var recentRequesters in RecentRequesters)
            {
                newClonedObject.RecentRequesters.Add(recentRequesters);
            }
            return newClonedObject;

        }
#nullable disable
    }
}