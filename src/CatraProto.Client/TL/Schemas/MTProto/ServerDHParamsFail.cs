using System.Numerics;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class ServerDHParamsFail : ServerDHParamsBase
    {
        public static int ConstructorId { get; } = 2043348061;
        public override BigInteger Nonce { get; set; }
        public override BigInteger ServerNonce { get; set; }
        public BigInteger NewNonceHash { get; set; }

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
            var sizeNewNonceHash = NewNonceHash.GetByteCount();
            if (sizeNewNonceHash != 16)
            {
                throw new CatraProto.TL.Exceptions.SerializationException(
                    $"ByteSize mismatch, should be 16bytes got {sizeNewNonceHash}bytes",
                    CatraProto.TL.Exceptions.SerializationException.SerializationErrors.BitSizeMismatch);
            }

            writer.Write(NewNonceHash);
        }

        public override void Deserialize(Reader reader)
        {
            Nonce = reader.Read<BigInteger>(128);
            ServerNonce = reader.Read<BigInteger>(128);
            NewNonceHash = reader.Read<BigInteger>(128);
        }
    }
}