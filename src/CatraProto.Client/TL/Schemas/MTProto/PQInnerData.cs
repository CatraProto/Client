using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class PQInnerData : CatraProto.Client.TL.Schemas.MTProto.PQInnerDataBase
    {
        public static int StaticConstructorId
        {
            get => -2083955988;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("pq")] public sealed override byte[] Pq { get; set; }

        [Newtonsoft.Json.JsonProperty("p")] public sealed override byte[] P { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public sealed override byte[] Q { get; set; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce")]
        public sealed override System.Numerics.BigInteger NewNonce { get; set; }


    #nullable enable
        public PQInnerData(byte[] pq, byte[] p, byte[] q, System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonce)
        {
            Pq = pq;
            P = p;
            Q = q;
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonce = newNonce;
        }
    #nullable disable
        internal PQInnerData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Pq);
            writer.Write(P);
            writer.Write(Q);
            writer.Write(Nonce);
            writer.Write(ServerNonce);
            writer.Write(NewNonce);
        }

        public override void Deserialize(Reader reader)
        {
            Pq = reader.Read<byte[]>();
            P = reader.Read<byte[]>();
            Q = reader.Read<byte[]>();
            Nonce = reader.Read<System.Numerics.BigInteger>(128);
            ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
            NewNonce = reader.Read<System.Numerics.BigInteger>(256);
        }

        public override string ToString()
        {
            return "p_q_inner_data";
        }
    }
}