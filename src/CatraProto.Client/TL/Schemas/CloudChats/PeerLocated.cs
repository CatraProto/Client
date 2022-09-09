using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerLocated : CatraProto.Client.TL.Schemas.CloudChats.PeerLocatedBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -901375139; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

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