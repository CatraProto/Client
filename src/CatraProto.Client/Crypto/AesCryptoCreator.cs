using System.Linq;
using System.Security.Cryptography;
using CatraProto.Client.Crypto.Aes;

namespace CatraProto.Client.Crypto
{
    internal static class AesCryptoCreator
    {
        public static IgeEncryptor CreateEncryptorV2(byte[] authKey, byte[] msgKey, bool fromClient)
        {
            var x = fromClient ? 0 : 8;
            var sha256A = SHA256.HashData(msgKey.Concat(authKey.Skip(x).Take(36)).ToArray());
            var sha256B = SHA256.HashData(authKey.Skip(40 + x).Take(36).Concat(msgKey).ToArray());

            var aesKey = sha256A.Take(8).Concat(sha256B.Skip(8).Take(16).Concat(sha256A.Skip(24).Take(8))).ToArray();
            var aesIv = sha256B.Take(8).Concat(sha256A.Skip(8).Take(16).Concat(sha256B.Skip(24).Take(8))).ToArray();
            return new IgeEncryptor(aesKey, aesIv);
        }

        public static IgeEncryptor CreateEncryptorV1(byte[] authKey, byte[] msgKey, bool fromClient)
        {
            var x = fromClient ? 0 : 8;

            var sha1A = SHA1.HashData(msgKey.Concat(authKey.Skip(x).Take(32)).ToArray());
            var sha1B = SHA1.HashData(authKey.Skip(32 + x).Take(16).Concat(msgKey).Concat(authKey.Skip(48 + x).Take(16)).ToArray());
            var sha1C = SHA1.HashData(authKey.Skip(64 + x).Take(32).Concat(msgKey).ToArray());
            var sha1D = SHA1.HashData(msgKey.Concat(authKey.Skip(96 + x).Take(32)).ToArray());

            var aesKey = sha1A.Take(8).Concat(sha1B.Skip(8).Take(12).Concat(sha1C.Skip(4).Take(12))).ToArray();
            var aesIv = sha1A.Skip(8).Take(12).Concat(sha1B.Take(8)).Concat(sha1C.Skip(16).Take(4)).Concat(sha1D.Take(8)).ToArray();
            return new IgeEncryptor(aesKey, aesIv);
        }
    }
}