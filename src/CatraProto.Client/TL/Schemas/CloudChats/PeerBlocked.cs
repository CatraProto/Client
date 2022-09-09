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
    public partial class PeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -386039788; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }


#nullable enable
        public PeerBlocked(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, int date)
        {
            PeerId = peerId;
            Date = date;
        }
#nullable disable
        internal PeerBlocked()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeerId = writer.WriteObject(PeerId);
            if (checkpeerId.IsError)
            {
                return checkpeerId;
            }

            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeerId.IsError)
            {
                return ReadResult<IObject>.Move(trypeerId);
            }

            PeerId = trypeerId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "peerBlocked";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerBlocked();
            var clonePeerId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)PeerId.Clone();
            if (clonePeerId is null)
            {
                return null;
            }

            newClonedObject.PeerId = clonePeerId;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerBlocked castedOther)
            {
                return true;
            }

            if (PeerId.Compare(castedOther.PeerId))
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}