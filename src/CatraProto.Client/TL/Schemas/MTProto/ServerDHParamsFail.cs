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
    public partial class ServerDHParamsFail : CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2043348061; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce_hash")]
        public System.Numerics.BigInteger NewNonceHash { get; set; }


#nullable enable
        public ServerDHParamsFail(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonceHash)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonceHash = newNonceHash;
        }
#nullable disable
        internal ServerDHParamsFail()
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

            var checkNewNonceHash = writer.WriteBigInteger(NewNonceHash);
            if (checkNewNonceHash.IsError) { return checkNewNonceHash; }

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
            var trynewNonceHash = reader.ReadBigInteger(128);
            if (trynewNonceHash.IsError)
            {
                return ReadResult<IObject>.Move(trynewNonceHash);
            }

            NewNonceHash = trynewNonceHash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "server_DH_params_fail";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ServerDHParamsFail();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.NewNonceHash = NewNonceHash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ServerDHParamsFail castedOther)
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

            if (NewNonceHash != castedOther.NewNonceHash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}