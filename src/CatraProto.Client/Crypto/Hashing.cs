using System;
using System.IO;
using System.Security.Cryptography;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Crypto
{
    class Hashing
    {
        public static byte[] ComputeShaHash(IObject obj, IObjectProvider provider, int length = 255)
        {
            using var ms = new MemoryStream(length);
            var random = new Random();

            var serToBytes = obj.ToArray(provider);
            var serToSha1 = SHA1.HashData(serToBytes);

            ms.Write(serToSha1);
            ms.Write(serToBytes);

            if (ms.Length < length)
            {
                var b = new byte[length - ms.Length];
                random.NextBytes(b);
                ms.Write(b);
            }

            return ms.ToArray();
        }
    }
}