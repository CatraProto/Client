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
    public partial class ClientDHInnerData : CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerDataBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1715713620; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("retry_id")]
        public sealed override long RetryId { get; set; }

        [Newtonsoft.Json.JsonProperty("g_b")] public sealed override byte[] GB { get; set; }


#nullable enable
        public ClientDHInnerData(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, long retryId, byte[] gB)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            RetryId = retryId;
            GB = gB;
        }
#nullable disable
        internal ClientDHInnerData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkNonce = writer.WriteBigInteger(Nonce);
            if (checkNonce.IsError) { return checkNonce; }

            var checkServerNonce = writer.WriteBigInteger(ServerNonce);
            if (checkServerNonce.IsError) { return checkServerNonce; }

            writer.WriteInt64(RetryId);

            writer.WriteBytes(GB);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
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
            var tryretryId = reader.ReadInt64();
            if (tryretryId.IsError)
            {
                return ReadResult<IObject>.Move(tryretryId);
            }

            RetryId = tryretryId.Value;
            var trygB = reader.ReadBytes();
            if (trygB.IsError)
            {
                return ReadResult<IObject>.Move(trygB);
            }

            GB = trygB.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "client_DH_inner_data";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ClientDHInnerData();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.RetryId = RetryId;
            newClonedObject.GB = GB;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ClientDHInnerData castedOther)
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

            if (RetryId != castedOther.RetryId)
            {
                return true;
            }

            if (GB != castedOther.GB)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}