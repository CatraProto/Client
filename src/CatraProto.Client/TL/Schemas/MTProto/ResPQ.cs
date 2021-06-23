using System.Collections.Generic;
using System.Numerics;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class ResPQ : ResPQBase
    {
        public static int ConstructorId { get; } = 85337187;
        public override BigInteger Nonce { get; set; }
        public override BigInteger ServerNonce { get; set; }
        public override byte[] Pq { get; set; }
        public override IList<long> ServerPublicKeyFingerprints { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            var sizeNonce = Nonce.GetByteCount();
            if (sizeNonce != 16)
            {
                throw new CatraProto.TL.Exceptions.SerializationException(
                    $"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes",
                    CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
            }

            writer.Write(Nonce);
            var sizeServerNonce = ServerNonce.GetByteCount();
            if (sizeServerNonce != 16)
            {
                throw new CatraProto.TL.Exceptions.SerializationException(
                    $"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes",
                    CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
            }

            writer.Write(ServerNonce);
            writer.Write(Pq);
            writer.Write(ServerPublicKeyFingerprints);
        }

        public override void Deserialize(Reader reader)
        {
            Nonce = reader.Read<BigInteger>(128);
            ServerNonce = reader.Read<BigInteger>(128);
            Pq = reader.Read<byte[]>();
            ServerPublicKeyFingerprints = reader.ReadVector<long>();
        }
    }
}