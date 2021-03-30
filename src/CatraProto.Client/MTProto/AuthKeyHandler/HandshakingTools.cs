using System;
using System.IO;
using System.Security.Cryptography;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.AuthKeyHandler
{
    static class HandshakingTools
    {
        public static byte[] GenerateHash(IObject obj, int length = 255)
        {
            using var ms = new MemoryStream(length);
            var random = new Random();
            var serToBytes = obj.ToArray(MergedProvider.DefaultInstance);
            
            var serToSha1 = SHA1.HashData(serToBytes);

            ms.Write(serToSha1);
            ms.Write(serToBytes);
            if (ms.Length < length)
            {
                var missing = length - ms.Length;
                var b = new byte[missing];
                random.NextBytes(b);
                ms.Write(b);
            }
            
            var toBytes = ms.ToArray();
            return toBytes;
        }
    }
}
