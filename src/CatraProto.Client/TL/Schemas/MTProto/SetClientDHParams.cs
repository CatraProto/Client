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
    public partial class SetClientDHParams : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -184262881; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("nonce")]
        public System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_data")]
        public byte[] EncryptedData { get; set; }


#nullable enable
        public SetClientDHParams(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] encryptedData)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            EncryptedData = encryptedData;
        }
#nullable disable

        internal SetClientDHParams()
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
            return "set_client_DH_params";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetClientDHParams();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.EncryptedData = EncryptedData;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetClientDHParams castedOther)
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

            if (EncryptedData != castedOther.EncryptedData)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}