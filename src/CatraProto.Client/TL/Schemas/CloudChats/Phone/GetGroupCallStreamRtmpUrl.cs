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
    public partial class GetGroupCallStreamRtmpUrl : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -558650433; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke")]
        public bool Revoke { get; set; }


#nullable enable
        public GetGroupCallStreamRtmpUrl(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool revoke)
        {
            Peer = peer;
            Revoke = revoke;
        }
#nullable disable

        internal GetGroupCallStreamRtmpUrl()
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

            var checkrevoke = writer.WriteBool(Revoke);
            if (checkrevoke.IsError)
            {
                return checkrevoke;
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
            var tryrevoke = reader.ReadBool();
            if (tryrevoke.IsError)
            {
                return ReadResult<IObject>.Move(tryrevoke);
            }

            Revoke = tryrevoke.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.getGroupCallStreamRtmpUrl";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetGroupCallStreamRtmpUrl();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Revoke = Revoke;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetGroupCallStreamRtmpUrl castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Revoke != castedOther.Revoke)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}