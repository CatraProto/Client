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
    public partial class TopPeer : CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -305282981; }

        [Newtonsoft.Json.JsonProperty("peer")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("rating")]
        public sealed override double Rating { get; set; }


#nullable enable
        public TopPeer(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, double rating)
        {
            Peer = peer;
            Rating = rating;
        }
#nullable disable
        internal TopPeer()
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

            writer.WriteDouble(Rating);

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
            var tryrating = reader.ReadDouble();
            if (tryrating.IsError)
            {
                return ReadResult<IObject>.Move(tryrating);
            }

            Rating = tryrating.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "topPeer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TopPeer();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Rating = Rating;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TopPeer castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Rating != castedOther.Rating)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}