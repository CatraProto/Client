/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Linq;
using System.Security.Cryptography;

namespace CatraProto.Client.Crypto.Aes
{
    internal class IgeEncryptor : IDisposable
    {
        private readonly AesManaged _aesManaged;
        private readonly ICryptoTransform _decryptor;
        private readonly ICryptoTransform _encryptor;
        private readonly byte[] _iv1;
        private readonly byte[] _iv2;

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