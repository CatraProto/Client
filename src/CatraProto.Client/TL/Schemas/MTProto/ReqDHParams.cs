using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class ReqDHParams : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -686627650; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("nonce")]
        public System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("p")] public byte[] P { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public byte[] Q { get; set; }

        [Newtonsoft.Json.JsonProperty("public_key_fingerprint")]
        public long PublicKeyFingerprint { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_data")]
        public byte[] EncryptedData { get; set; }


#nullable enable
        public ReqDHParams(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] p, byte[] q, long publicKeyFingerprint, byte[] encryptedData)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            P = p;
            Q = q;
            PublicKeyFingerprint = publicKeyFingerprint;
            EncryptedData = encryptedData;
        }
#nullable disable

        internal ReqDHParams()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkNonce = writer.WriteBigInteger(Nonce);
            if (checkNonce.IsError) { return checkNonce; }

            var checkServerNonce = writer.WriteBigInteger(ServerNonce);
            if (checkServerNonce.IsError) { return checkServerNonce; }

            writer.WriteBytes(P);

            writer.WriteBytes(Q);
            writer.WriteInt64(PublicKeyFingerprint);

            writer.WriteBytes(EncryptedData);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynonce = reader.ReadBigInteger(128);
            if (trynonce.IsError)
            {
                return ReadResult<IObject>.Move(trynonce);
            }

            Nonce = trynonce.Value;
            var tryserverNonce = reader.ReadBigInteger(128);
            if (tryserverNonce.IsError)
            {
                return ReadResult<IObject>.Move(tryserverNonce);
            }

            ServerNonce = tryserverNonce.Value;
            var tryp = reader.ReadBytes();
            if (tryp.IsError)
            {
                return ReadResult<IObject>.Move(tryp);
            }

            P = tryp.Value;
            var tryq = reader.ReadBytes();
            if (tryq.IsError)
            {
                return ReadResult<IObject>.Move(tryq);
            }

            Q = tryq.Value;
            var trypublicKeyFingerprint = reader.ReadInt64();
            if (trypublicKeyFingerprint.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKeyFingerprint);
            }

            PublicKeyFingerprint = trypublicKeyFingerprint.Value;
            var tryencryptedData = reader.ReadBytes();
            if (tryencryptedData.IsError)
            {
                return ReadResult<IObject>.Move(tryencryptedData);
            }

            EncryptedData = tryencryptedData.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "req_DH_params";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReqDHParams();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.P = P;
            newClonedObject.Q = Q;
            newClonedObject.PublicKeyFingerprint = PublicKeyFingerprint;
            newClonedObject.EncryptedData = EncryptedData;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReqDHParams castedOther)
            {
                return true;
            }

            if (Nonce != castedOther.Nonce)
            {
                return true;
            }

            if (ServerNonce != castedOther.ServerNonce)
            {
                return true;
            }

            if (P != castedOther.P)
            {
                return true;
            }

            if (Q != castedOther.Q)
            {
                return true;
            }

            if (PublicKeyFingerprint != castedOther.PublicKeyFingerprint)
            {
                return true;
            }

            if (EncryptedData != castedOther.EncryptedData)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}