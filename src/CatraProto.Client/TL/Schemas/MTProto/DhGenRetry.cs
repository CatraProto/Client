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
    public partial class DhGenRetry : CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1188831161; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce_hash2")]
        public System.Numerics.BigInteger NewNonceHash2 { get; set; }


#nullable enable
        public DhGenRetry(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonceHash2)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonceHash2 = newNonceHash2;
        }
#nullable disable
        internal DhGenRetry()
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

            var checkNewNonceHash2 = writer.WriteBigInteger(NewNonceHash2);
            if (checkNewNonceHash2.IsError) { return checkNewNonceHash2; }

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
            var trynewNonceHash2 = reader.ReadBigInteger(128);
            if (trynewNonceHash2.IsError)
            {
                return ReadResult<IObject>.Move(trynewNonceHash2);
            }

            NewNonceHash2 = trynewNonceHash2.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "dh_gen_retry";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DhGenRetry();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.NewNonceHash2 = NewNonceHash2;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DhGenRetry castedOther)
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

            if (NewNonceHash2 != castedOther.NewNonceHash2)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}