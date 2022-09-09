using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AcceptEncryption : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1035731989; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("g_b")] public byte[] GB { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public long KeyFingerprint { get; set; }


#nullable enable
        public AcceptEncryption(CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase peer, byte[] gB, long keyFingerprint)
        {
            Peer = peer;
            GB = gB;
            KeyFingerprint = keyFingerprint;
        }
#nullable disable

        internal AcceptEncryption()
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
            writer.WriteInt64(KeyFingerprint);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase>();
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
            var trykeyFingerprint = reader.ReadInt64();
            if (trykeyFingerprint.IsError)
            {
                return ReadResult<IObject>.Move(trykeyFingerprint);
            }

            KeyFingerprint = trykeyFingerprint.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.acceptEncryption";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AcceptEncryption();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedChatBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.GB = GB;
            newClonedObject.KeyFingerprint = KeyFingerprint;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AcceptEncryption castedOther)
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

            if (KeyFingerprint != castedOther.KeyFingerprint)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}