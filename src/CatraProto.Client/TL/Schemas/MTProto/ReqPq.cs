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
    public partial class ReqPq : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1615239032; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("nonce")]
        public System.Numerics.BigInteger Nonce { get; set; }


#nullable enable
        public ReqPq(System.Numerics.BigInteger nonce)
        {
            Nonce = nonce;
        }
#nullable disable

        internal ReqPq()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "req_pq";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReqPq();
            newClonedObject.Nonce = Nonce;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReqPq castedOther)
            {
                return true;
            }

            if (Nonce != castedOther.Nonce)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}