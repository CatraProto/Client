using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class SaveDefaultGroupCallJoinAs : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1465786252; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("join_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase JoinAs { get; set; }


#nullable enable
        public SaveDefaultGroupCallJoinAs(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase joinAs)
        {
            Peer = peer;
            JoinAs = joinAs;
        }
#nullable disable

        internal SaveDefaultGroupCallJoinAs()
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

            var checkjoinAs = writer.WriteObject(JoinAs);
            if (checkjoinAs.IsError)
            {
                return checkjoinAs;
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
            var tryjoinAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryjoinAs.IsError)
            {
                return ReadResult<IObject>.Move(tryjoinAs);
            }

            JoinAs = tryjoinAs.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.saveDefaultGroupCallJoinAs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveDefaultGroupCallJoinAs();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneJoinAs = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)JoinAs.Clone();
            if (cloneJoinAs is null)
            {
                return null;
            }

            newClonedObject.JoinAs = cloneJoinAs;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveDefaultGroupCallJoinAs castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (JoinAs.Compare(castedOther.JoinAs))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}