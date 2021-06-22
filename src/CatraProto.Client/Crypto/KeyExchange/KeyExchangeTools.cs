using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.Extensions;

namespace CatraProto.Client.Crypto
{
    class KeyExchangeTools
    {
        public static byte[] ComputeAesKey(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var newNonceFirst = Hashing.ShaBigIntegers(newNonce, serverNonce);
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);
            
            ms.Write(newNonceFirst);
            ms.Write(serverNonceFirst.Take(12).ToArray());
            return ms.ToArray();
        }

        public static byte[] ComputeAesIv(BigInteger serverNonce, BigInteger newNonce)
        {
            using var ms = new MemoryStream();
            var serverNonceFirst = Hashing.ShaBigIntegers(serverNonce, newNonce);
            var newNonceOnly = Hashing.ShaBigIntegers(newNonce, newNonce);
            
            ms.Write(serverNonceFirst.Skip(12).Take(8).ToArray());
            ms.Write(newNonceOnly);
            ms.Write(newNonce.ToByteArray().Take(4).ToArray());
            return ms.ToArray();
        }

        public static byte[] DecryptMessage(IgeEncryptor encryptor, byte[] data)
        {
            var decrypted = encryptor.Decrypt(data);
            var reader = new BinaryReader(decrypted.ToMemoryStream());
            reader.BaseStream.Position += 20;
            var answer = reader.ReadBytes(decrypted.Length - 20);
            return answer;
        }
    }
}