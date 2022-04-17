using System;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto
{
    internal static class Hashing
    {
        public static byte[] ComputeDataHashedPadding(byte[] array, int padding = 16)
        {
            var ms = new MemoryStream();
            var serToSha1 = SHA1.HashData(array);
            ms.Write(serToSha1);
            ms.Write(array);
            if (ms.Length % padding == 0)
            {
                return ms.ToArray();
            }

            var b = new byte[padding - ms.Length % padding];
            new Random().NextBytes(b);
            ms.Write(b);

            return ms.ToArray();
        }

        public static byte[] ShaBigIntegers(BigInteger bigInteger, BigInteger otherBigInteger)
        {
            using var ms = new MemoryStream();
            ms.Write(bigInteger.ToByteArray());
            ms.Write(otherBigInteger.ToByteArray());
            return SHA1.HashData(ms.ToArray());
        }
    }
}