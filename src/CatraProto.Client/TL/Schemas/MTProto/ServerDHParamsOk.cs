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
    public partial class ServerDHParamsOk : CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -790100132; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_answer")]
        public byte[] EncryptedAnswer { get; set; }


#nullable enable
        public ServerDHParamsOk(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] encryptedAnswer)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            EncryptedAnswer = encryptedAnswer;
        }
#nullable disable
        internal ServerDHParamsOk()
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

            writer.WriteBytes(EncryptedAnswer);

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
            var tryencryptedAnswer = reader.ReadBytes();
            if (tryencryptedAnswer.IsError)
            {
                return ReadResult<IObject>.Move(tryencryptedAnswer);
            }

            EncryptedAnswer = tryencryptedAnswer.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "server_DH_params_ok";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ServerDHParamsOk();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.EncryptedAnswer = EncryptedAnswer;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ServerDHParamsOk castedOther)
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

            if (EncryptedAnswer != castedOther.EncryptedAnswer)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}