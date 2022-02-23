using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class ResPQ : CatraProto.Client.TL.Schemas.MTProto.ResPQBase
    {
        public static int StaticConstructorId
        {
            get => 85337187;
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

        [Newtonsoft.Json.JsonProperty("pq")] public sealed override byte[] Pq { get; set; }

        [Newtonsoft.Json.JsonProperty("server_public_key_fingerprints")]
        public sealed override IList<long> ServerPublicKeyFingerprints { get; set; }


    #nullable enable
        public ResPQ(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] pq, IList<long> serverPublicKeyFingerprints)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            Pq = pq;
            ServerPublicKeyFingerprints = serverPublicKeyFingerprints;
        }
    #nullable disable
        internal ResPQ()
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
            writer.Write(Pq);
            writer.Write(ServerPublicKeyFingerprints);
        }

        public override void Deserialize(Reader reader)
        {
            Nonce = reader.Read<System.Numerics.BigInteger>(128);
            ServerNonce = reader.Read<System.Numerics.BigInteger>(128);
            Pq = reader.Read<byte[]>();
            ServerPublicKeyFingerprints = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "resPQ";
        }
    }
}