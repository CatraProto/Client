using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DhGenFail : CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase
    {
        public static int StaticConstructorId
        {
            get => -1499615742;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce_hash3")]
        public System.Numerics.BigInteger NewNonceHash3 { get; set; }


    #nullable enable
        public DhGenFail(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonceHash3)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonceHash3 = newNonceHash3;
        }
    #nullable disable
        internal DhGenFail()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Nonce);
            writer.Write(ServerNonce);
            writer.Write(NewNonceHash3);
        }

        public override void Deserialize(Reader reader)
        {
            Nonce = reader.Read<System.Numerics.BigInteger>(128);
            ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
            NewNonceHash3 = reader.Read<System.Numerics.BigInteger>(128);
        }

        public override string ToString()
        {
            return "dh_gen_fail";
        }
    }
}