using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using CatraProto.Client.TL.Schemas.CloudChats.Contacts;

namespace CatraProto.Client.Crypto.Aes
{
    class IgeEncryptor : IDisposable
    {
        private AesManaged _aesManaged;
        private ICryptoTransform _encryptor;
        private ICryptoTransform _decryptor;
        private byte[] _iv1;
        private byte[] _iv2;

        public IgeEncryptor(byte[] key, byte[] iv)
        {
            _aesManaged = new AesManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.None,
                Key = key,
            };

            _encryptor = _aesManaged.CreateEncryptor();
            _decryptor = _aesManaged.CreateDecryptor();

            _iv1 = iv.Take(16).ToArray();
            _iv2 = iv.TakeLast(16).ToArray();
        }

        public byte[] Encrypt(byte[] plainText)
        {
            return Process(plainText, true);
        }

        public byte[] Decrypt(byte[] encryptedText)
        {
            return Process(encryptedText, false);
        }

        private byte[] Process(byte[] from, bool encrypt)
        {
            if (from.Length % 16 != 0)
            {
                throw new ArgumentException("Plaintext must be a multiple of 16");
            }

            GetParameters(encrypt, out var transformer, out var oldCleanBlock, out var oldProcessedBlock);

            var output = new byte[from.Length];
            for (int i = 0; i < from.Length; i += 16)
            {
                var cleanBlock = new byte[16];
                Array.Copy(from, i, cleanBlock, 0, 16);

                var xoredToEncrypt = XorBlock(cleanBlock, oldProcessedBlock);
                var blockResult = transformer.TransformFinalBlock(xoredToEncrypt, 0, 16);
                var xoredEncrypted = XorBlock(blockResult, oldCleanBlock);

                var currentI = i;
                for (int j = 0; j < xoredEncrypted.Length; j++)
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

        private static byte[] XorBlock(byte[] first, byte[] second)
        {
            if (first.Length != second.Length)
            {
                throw new ArgumentException("First byte array and second must have the same length");
            }

            var output = new byte[first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                output[i] = (byte)(first[i] ^ second[i]);
            }

            return output;
        }

        public void Dispose()
        {
            _aesManaged?.Dispose();
            _encryptor?.Dispose();
            _decryptor?.Dispose();
        }
    }
}