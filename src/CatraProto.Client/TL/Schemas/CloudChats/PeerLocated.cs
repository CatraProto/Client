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
    public partial class PeerLocated : CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -901375139; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("distance")]
        public int Distance { get; set; }


#nullable enable
        public PeerLocated(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int expires, int distance)
        {
            Peer = peer;
            Expires = expires;
            Distance = distance;

        }
#nullable disable
        internal PeerLocated()
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
            writer.WriteInt32(Expires);
            writer.WriteInt32(Distance);

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
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }
            Expires = tryexpires.Value;
            var trydistance = reader.ReadInt32();
            if (trydistance.IsError)
            {
                return ReadResult<IObject>.Move(trydistance);
            }
            Distance = trydistance.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "peerLocated";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerLocated();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.Expires = Expires;
            newClonedObject.Distance = Distance;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerLocated castedOther)
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            if (Expires != castedOther.Expires)
            {
                return true;
            }
            if (Distance != castedOther.Distance)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}