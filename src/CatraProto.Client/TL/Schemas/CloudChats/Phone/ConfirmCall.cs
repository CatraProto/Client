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
    public partial class ConfirmCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 788404002; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a")] public byte[] GA { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public long KeyFingerprint { get; set; }

        [Newtonsoft.Json.JsonProperty("protocol")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


#nullable enable
        public ConfirmCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gA, long keyFingerprint, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
        {
            Peer = peer;
            GA = gA;
            KeyFingerprint = keyFingerprint;
            Protocol = protocol;
        }
#nullable disable

        internal ConfirmCall()
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

            writer.WriteBytes(GA);
            writer.WriteInt64(KeyFingerprint);
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
            var trygA = reader.ReadBytes();
            if (trygA.IsError)
            {
                return ReadResult<IObject>.Move(trygA);
            }

            GA = trygA.Value;
            var trykeyFingerprint = reader.ReadInt64();
            if (trykeyFingerprint.IsError)
            {
                return ReadResult<IObject>.Move(trykeyFingerprint);
            }

            KeyFingerprint = trykeyFingerprint.Value;
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
            return "phone.confirmCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ConfirmCall();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.GA = GA;
            newClonedObject.KeyFingerprint = KeyFingerprint;
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
            if (other is not ConfirmCall castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (GA != castedOther.GA)
            {
                return true;
            }

            if (KeyFingerprint != castedOther.KeyFingerprint)
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