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
    public partial class AcceptCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1003664544; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("g_b")] public byte[] GB { get; set; }

        [Newtonsoft.Json.JsonProperty("protocol")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


#nullable enable
        public AcceptCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gB, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
        {
            Peer = peer;
            GB = gB;
            Protocol = protocol;
        }
#nullable disable

        internal AcceptCall()
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

            writer.WriteBytes(GB);
            var checkprotocol = writer.WriteObject(Protocol);
            if (checkprotocol.IsError)
            {
                return checkprotocol;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trygB = reader.ReadBytes();
            if (trygB.IsError)
            {
                return ReadResult<IObject>.Move(trygB);
            }

            GB = trygB.Value;
            var tryprotocol = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
            if (tryprotocol.IsError)
            {
                return ReadResult<IObject>.Move(tryprotocol);
            }

            Protocol = tryprotocol.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phone.acceptCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AcceptCall();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.GB = GB;
            var cloneProtocol = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase?)Protocol.Clone();
            if (cloneProtocol is null)
            {
                return null;
            }

            newClonedObject.Protocol = cloneProtocol;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AcceptCall castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (GB != castedOther.GB)
            {
                return true;
            }

            if (Protocol.Compare(castedOther.Protocol))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}