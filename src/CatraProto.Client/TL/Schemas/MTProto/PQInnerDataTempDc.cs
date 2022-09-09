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
    public partial class PQInnerDataTempDc : CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1459478408; }

        [Newtonsoft.Json.JsonProperty("pq")] public sealed override byte[] Pq { get; set; }

        [Newtonsoft.Json.JsonProperty("p")] public sealed override byte[] P { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public sealed override byte[] Q { get; set; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce")]
        public sealed override System.Numerics.BigInteger NewNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("dc")] public sealed override int Dc { get; set; }

        [Newtonsoft.Json.JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }


#nullable enable
        public PQInnerDataTempDc(byte[] pq, byte[] p, byte[] q, System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonce, int dc, int expiresIn)
        {
            Pq = pq;
            P = p;
            Q = q;
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonce = newNonce;
            Dc = dc;
            ExpiresIn = expiresIn;
        }
#nullable disable
        internal PQInnerDataTempDc()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Pq);

            writer.WriteBytes(P);

            writer.WriteBytes(Q);
            var checkNonce = writer.WriteBigInteger(Nonce);
            if (checkNonce.IsError) { return checkNonce; }

            var checkServerNonce = writer.WriteBigInteger(ServerNonce);
            if (checkServerNonce.IsError) { return checkServerNonce; }

            var checkNewNonce = writer.WriteBigInteger(NewNonce);
            if (checkNewNonce.IsError) { return checkNewNonce; }

            writer.WriteInt32(Dc);
            writer.WriteInt32(ExpiresIn);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypq = reader.ReadBytes();
            if (trypq.IsError)
            {
                return ReadResult<IObject>.Move(trypq);
            }

            Pq = trypq.Value;
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
            var trynewNonce = reader.ReadBigInteger(256);
            if (trynewNonce.IsError)
            {
                return ReadResult<IObject>.Move(trynewNonce);
            }

            NewNonce = trynewNonce.Value;
            var trydc = reader.ReadInt32();
            if (trydc.IsError)
            {
                return ReadResult<IObject>.Move(trydc);
            }

            Dc = trydc.Value;
            var tryexpiresIn = reader.ReadInt32();
            if (tryexpiresIn.IsError)
            {
                return ReadResult<IObject>.Move(tryexpiresIn);
            }

            ExpiresIn = tryexpiresIn.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "p_q_inner_data_temp_dc";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PQInnerDataTempDc();
            newClonedObject.Pq = Pq;
            newClonedObject.P = P;
            newClonedObject.Q = Q;
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.NewNonce = NewNonce;
            newClonedObject.Dc = Dc;
            newClonedObject.ExpiresIn = ExpiresIn;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PQInnerDataTempDc castedOther)
            {
                return true;
            }

            if (Pq != castedOther.Pq)
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

            if (Nonce != castedOther.Nonce)
            {
                return true;
            }

            if (ServerNonce != castedOther.ServerNonce)
            {
                return true;
            }

            if (NewNonce != castedOther.NewNonce)
            {
                return true;
            }

            if (Dc != castedOther.Dc)
            {
                return true;
            }

            if (ExpiresIn != castedOther.ExpiresIn)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}