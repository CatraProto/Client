using System;
using System.Linq;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto.Aes
{
    class IgeEncryptor : IDisposable
    {
        private AesManaged _aesManaged;
        private ICryptoTransform _decryptor;
        private ICryptoTransform _encryptor;
        private byte[] _iv1;
        private byte[] _iv2;

        public IgeEncryptor(byte[] key, byte[] iv)
        {
            _aesManaged = new AesManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.None,
                Key = key
            };

            _encryptor = _aesManaged.CreateEncryptor();
            _decryptor = _aesManaged.CreateDecryptor();

            _iv1 = iv.Take(16).ToArray();
            _iv2 = iv.TakeLast(16).ToArray();
        }


        private byte[] Process(byte[] from, bool encrypt)
        {
            GetParameters(encrypt, out var transformer, out var oldCleanBlock, out var oldProcessedBlock);

            var output = new byte[from.Length];
            for (var i = 0; i < from.Length; i += 16)
            {
                var cleanBlock = new byte[16];
                Array.Copy(from, i, cleanBlock, 0, 16);

                var xoredToEncrypt = CryptoTools.XorBlock(cleanBlock, oldProcessedBlock);
                var blockResult = transformer.TransformFinalBlock(xoredToEncrypt, 0, 16);
                var xoredEncrypted = CryptoTools.XorBlock(blockResult, oldCleanBlock);

                var currentI = i;
                for (var j = 0; j < xoredEncrypted.Length; j++)
                {
                    output[currentI] = xoredEncrypted[j];
                    currentI++;
                }

                oldProcessedBlock = xoredEncrypted;
                oldCleanBlock = cleanBlock;
            }

            return output;
        }

        private void GetParameters(bool encrypt, out ICryptoTransform transformer, out byte[] oldCleanBlock, out byte[] oldProcessedBlock)
        {
            if (encrypt)
            {
                transformer = _encryptor;
                oldCleanBlock = _iv2;
                oldProcessedBlock = _iv1;
            }
            else
            {
                transformer = _decryptor;
                oldCleanBlock = _iv1;
                oldProcessedBlock = _iv2;
            }
        }

        public byte[] Encrypt(byte[] plainText)
        {
            return Process(plainText, true);
        }

        public byte[] Decrypt(byte[] encryptedText)
        {
            return Process(encryptedText, false);
        }

        public void Dispose()
        {
            _aesManaged?.Dispose();
            _encryptor?.Dispose();
            _decryptor?.Dispose();
        }
    }
}