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
    public partial class UpdatePeerHistoryTTL : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TtlPeriod = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1147422299; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }


#nullable enable
        public UpdatePeerHistoryTTL(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer)
        {
            Peer = peer;
        }
#nullable disable
        internal UpdatePeerHistoryTTL()
        {
        }

        public override void UpdateFlags()
        {
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(TtlPeriod.Value);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryttlPeriod = reader.ReadInt32();
                if (tryttlPeriod.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlPeriod);
                }

                TtlPeriod = tryttlPeriod.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updatePeerHistoryTTL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePeerHistoryTTL();
            newClonedObject.Flags = Flags;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.TtlPeriod = TtlPeriod;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdatePeerHistoryTTL castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (TtlPeriod != castedOther.TtlPeriod)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}