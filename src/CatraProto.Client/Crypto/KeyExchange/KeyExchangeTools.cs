using System.IO;
using System.Linq;
using System.Numerics;
using CatraProto.Client.Crypto.Aes;
using CatraProto.TL;

namespace CatraProto.Client.Crypto.KeyExchange
{
    static class KeyExchangeTools
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

        public static byte[] DecryptMessage(IgeEncryptor encryptor, byte[] data, out byte[] sha)
        {
            var decrypted = encryptor.Decrypt(data);
            var reader = new BinaryReader(decrypted.ToMemoryStream());
            sha = reader.ReadBytes(20);
            return reader.ReadBytes(decrypted.Length - 20);
        }

        public static byte[] ComputeServerSalt(BigInteger serverNonce, BigInteger newNonce)
        {
            return CryptoTools.XorBlock(newNonce.ToByteArray().Take(8).ToArray(), serverNonce.ToByteArray().Take(8).ToArray());
        }
    }
}