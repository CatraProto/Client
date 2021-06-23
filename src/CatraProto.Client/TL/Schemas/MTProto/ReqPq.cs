using System.Numerics;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class ReqPq : IMethod
    {
        public static int ConstructorId { get; } = 1615239032;

        public System.Type Type { get; init; } = typeof(ResPQBase);
        public bool IsVector { get; init; } = false;
        public BigInteger Nonce { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
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
        }

        public void Deserialize(Reader reader)
        {
            Nonce = reader.Read<BigInteger>(128);
        }
    }
}