using System.IO;
using System.Linq;
using System.Security.Cryptography;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;

namespace CatraProto.Client.Crypto
{
    class Pfs
    {
        public static byte[] Encrypt(AuthKey permAuthKey, BindAuthKeyInner inner, long messageId)
        {
            using (var encryptedWriter = new BinaryWriter(new MemoryStream()))
            {
                using (var plainWriter = new BinaryWriter(new MemoryStream()))
                {
                    plainWriter.Write(CryptoTools.GenerateRandomBytes(16));
                    plainWriter.Write(messageId);
                    plainWriter.Write(0);
                    plainWriter.Write(40);
                    plainWriter.Write(inner.ToArray(MergedProvider.Singleton));
                
                    var plainToByte = ((MemoryStream)plainWriter.BaseStream).ToArray();
                    var msgKey = SHA1.HashData(plainToByte).Skip(4).Take(16).ToArray();
                    
                    CryptoTools.AddPadding(plainWriter.BaseStream, 16);
                    plainToByte = ((MemoryStream)plainWriter.BaseStream).ToArray();
                    
                    using var encryptor = permAuthKey.CreateEncryptorV1(msgKey, true);
                    var encryptedData = encryptor.Encrypt(plainToByte);

                    encryptedWriter.Write(permAuthKey.AuthKeyId);
                    encryptedWriter.Write(msgKey);
                    encryptedWriter.Write(encryptedData);
                }
                
                return ((MemoryStream)encryptedWriter.BaseStream).ToArray();
            }
        }
        
        
    }
}