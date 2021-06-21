using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Exceptions;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DhGenFail : SetClientDHParamsAnswerBase
    {
        public static int ConstructorId { get; } = -1499615742;
        public override BigInteger Nonce { get; set; }
        public override BigInteger ServerNonce { get; set; }
        public BigInteger NewNonceHash3 { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            var sizeNonce = Nonce.GetByteCount();
            if (sizeNonce != 16)
            {
                throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
            }

            writer.Write(Nonce);
            var sizeServerNonce = ServerNonce.GetByteCount();
            if (sizeServerNonce != 16)
            {
                throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeServerNonce}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
            }

            writer.Write(ServerNonce);
            var sizeNewNonceHash3 = NewNonceHash3.GetByteCount();
            if (sizeNewNonceHash3 != 16)
            {
                throw new SerializationException($"ByteSize mismatch, should be 16bytes got {sizeNewNonceHash3}bytes", SerializationException.SerializationErrors.BitSizeMismatch);
            }

            writer.Write(NewNonceHash3);
        }

        public override void Deserialize(Reader reader)
        {
            Nonce = reader.Read<BigInteger>(128);
            ServerNonce = reader.Read<BigInteger>(128);
            NewNonceHash3 = reader.Read<BigInteger>(128);
        }
    }
}