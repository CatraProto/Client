using System.IO;
using System.Linq;
using System.Numerics;

namespace CatraProto.Client.Crypto
{
    public class MTProto
    {
        public static byte[] ComputeAesKeyV2(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var newNonceFirst = Hashing.ShaBigIntegers(newNonce, serverNonce);
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);

            ms.Write(newNonceFirst);
            ms.Write(serverNonceFirst.Take(12).ToArray());
            return ms.ToArray();
        }

        public static byte[] ComputeAesIvV2(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);
            var newNonceOnly = Hashing.ShaBigIntegers(newNonce, newNonce);

            ms.Write(serverNonceFirst.Skip(12).Take(8).ToArray());
            ms.Write(newNonceOnly);
            ms.Write(newNonce.ToByteArray().Take(4).ToArray());
            return ms.ToArray();
        }
    }
}