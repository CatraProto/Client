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
    public partial class UpdatePeerBlocked : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 610945826; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("blocked")]
        public bool Blocked { get; set; }


#nullable enable
        public UpdatePeerBlocked(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, bool blocked)
        {
            PeerId = peerId;
            Blocked = blocked;
        }
#nullable disable
        internal UpdatePeerBlocked()
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

            var checkblocked = writer.WriteBool(Blocked);
            if (checkblocked.IsError)
            {
                return checkblocked;
            }

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
            var tryblocked = reader.ReadBool();
            if (tryblocked.IsError)
            {
                return ReadResult<IObject>.Move(tryblocked);
            }

            Blocked = tryblocked.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updatePeerBlocked";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePeerBlocked();
            var clonePeerId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)PeerId.Clone();
            if (clonePeerId is null)
            {
                return null;
            }

            newClonedObject.PeerId = clonePeerId;
            newClonedObject.Blocked = Blocked;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdatePeerBlocked castedOther)
            {
                return true;
            }

            if (PeerId.Compare(castedOther.PeerId))
            {
                return true;
            }

            if (Blocked != castedOther.Blocked)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}