using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class PQInnerDataDc : CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1443537003; }

        [Newtonsoft.Json.JsonProperty("pq")]
        public sealed override byte[] Pq { get; set; }

        [Newtonsoft.Json.JsonProperty("p")]
        public sealed override byte[] P { get; set; }

        [Newtonsoft.Json.JsonProperty("q")]
        public sealed override byte[] Q { get; set; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce")]
        public sealed override System.Numerics.BigInteger NewNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("dc")]
        public sealed override int Dc { get; set; }


#nullable enable
        public PQInnerDataDc(byte[] pq, byte[] p, byte[] q, System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonce, int dc)
        {
            Pq = pq;
            P = p;
            Q = q;
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonce = newNonce;
            Dc = dc;

        }
#nullable disable
        internal PQInnerDataDc()
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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "p_q_inner_data_dc";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}